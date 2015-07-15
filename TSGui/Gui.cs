/*
TSGui, a Graphical User Interface that replaces the TShock Console
Copyright (C) 2015 Ancientgods & magnusi
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using TShockAPI;
using Terraria;
using TerrariaApi.Server;
using TSGui.Extensions;
using magnusi;


namespace TSGui
{
    public partial class Gui : Form
    {
        DateTime launchTime = new DateTime();
        public System.Timers.Timer refreshTimer;
        public bool handleCreated = false;
        
        public Gui()
        {
            InitializeComponent();
        }

        private void Gui_Load(object sender, EventArgs e)
        {
            bool HackyWorkAround = true;
            Process p = Process.GetCurrentProcess();

            textBox1.ForeColor = System.Drawing.Color.FromArgb(Convert.ToByte(TShock.Config.BroadcastRGB[0]), Convert.ToByte(TShock.Config.BroadcastRGB[1]), Convert.ToByte(TShock.Config.BroadcastRGB[2]));

            Action<string> WriteToTextbox = (s) =>
            {
                bool HasCleared = false;
                if (s.Length > 0)
                {
                    if ((int)s[s.Length - 1] == 52) //Clear console
                    {
                        richTextBox1.MainThreadInvoke(() =>
                            {
                                HasCleared = true;
                                if (HackyWorkAround)
                                {
                                    HackyWorkAround = false;
                                    richTextBox1.AppendText("");
                                    return;
                                }
                                richTextBox1.Clear();
                            });
                        formSkin1.Text = Console.Title;
                        formSkin1.Invalidate();
                    }
                    richTextBox1.MainThreadInvoke(() =>
                    {
                        richTextBox1.Append(s, Console.ForegroundColor);
                        if (HasCleared)
                            richTextBox1.Append("");
                    });
                }
            };
            main.ConsoleInput = new TaskReader(Console.In);
            Console.SetOut(new TaskWriter(Console.Out, WriteToTextbox));
            Console.SetIn(main.ConsoleInput);
            listBox1.ListBx.MouseDoubleClick += ListBx_MouseDoubleClick; //Add here because the designer removes the code (because of the .ListBX).
            textBox1.HandleCreated += ListBx_HandleCreated; //Add here because designer is a bitch.
            refreshTimer.Interval = 1000;
            System.Threading.Thread.Sleep(100);
            refreshTimer.Elapsed += refreshTimer_Elapsed;
            statsTab.HandleCreated += handleiscreated;
        }

        private void handleiscreated(object sender, EventArgs e)
        {
            handleCreated = true;
        }

        void refreshTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            if (handleCreated)
            {
                //Computer Info
                flatLabel9.Text = System.Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
                flatLabel10.Text = getCPUCounter().ToString();
                flatLabel11.Text = getRAMCounter().ToString();
                flatLabel12.Text = GetOSFriendlyName();
                flatLabel13.Text = Environment.MachineName;
                flatLabel14.Text = Environment.UserName;

                //TShock Info
                flatLabel17.Text = TShock.Players.Count().ToString();
                //flatLabel19.Text = TShockAPI.
                flatLabel21.Text = getHoursRunning();
                flatLabel22.Text = System.IO.Directory.GetFiles(Environment.CurrentDirectory + "\\ServerPlugins").Count().ToString();
                flatLabel23.Text = TShock.Groups.Count().ToString();
                flatLabel24.Text = TShockAPI.Commands.ChatCommands.Count().ToString();
            }

        }

        private string getHoursRunning()
        {
            DateTime currentTime = new DateTime();
            return currentTime.Subtract(launchTime).TotalMinutes.ToString();
        }
        public static string GetOSFriendlyName()
        {
            string result = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
            foreach (ManagementObject os in searcher.Get())
            {
                result = os["Caption"].ToString();
                break;
            }
            return result;
        }

        public object getCPUCounter()
        {

            PerformanceCounter cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";

            // will always start at 0
            dynamic firstValue = cpuCounter.NextValue();
            System.Threading.Thread.Sleep(1000);
            // now matches task manager reading
            dynamic secondValue = cpuCounter.NextValue();

            return secondValue;

        }
        public object getRAMCounter()
        {

            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes", true);

            // will always start at 0
            dynamic firstValue = ramCounter.NextValue();
            System.Threading.Thread.Sleep(1000);
            // now matches task manager reading
            dynamic secondValue = ramCounter.NextValue();

            return secondValue;

        }
        private void ListBx_HandleCreated(object sender, EventArgs e)
        {
            listBox1.Focus();
        }



        void ListBx_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            UserOptions options = new UserOptions();
            ListBox lb = (sender as ListBox);

            List<TSPlayer> tsplrs = TShock.Utils.FindPlayer(lb.Items[lb.SelectedIndex].ToString());

            if (tsplrs.Count == 0)
                return;

            options.TSPlayer = tsplrs[0];
            options.ShowDialog();
        }

        #region Hooks
        public void ServerJoin(JoinEventArgs e)
        {
            listBox1.MainThreadInvoke(() =>
                {
                    listBox1.Clear();
                    listBox1.AddRange((from tsplr in TShock.Players where tsplr != null orderby tsplr.Name select tsplr.Name).ToArray());
                });
        }

        public void ServerLeave(LeaveEventArgs e)
        {
            listBox1.MainThreadInvoke(() =>
            {
                listBox1.Clear();
                listBox1.AddRange((from tsplr in TShock.Players where tsplr != null && tsplr.Index != e.Who orderby tsplr.Name select tsplr.Name).ToArray());
            });
            if (TShock.Utils.ActivePlayers() == 1)
            {
                formSkin1.Text = Utils.GetTitle(true);
                formSkin1.Invalidate();
            }
        }

        public void OnPostInit(EventArgs e)
        {
            formSkin1.Text = Utils.GetTitle(false);
            formSkin1.Invalidate();
        }

        DateTime LastCheck = DateTime.UtcNow;
        public void OnUpdate(EventArgs e)
        {
            if ((DateTime.UtcNow - LastCheck).TotalSeconds >= 1)
            {
                formSkin1.Text = Utils.GetTitle(false);
                formSkin1.Invalidate();
            }
        }
        #endregion Hooks

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            UserOptions options = new UserOptions();
            ListBox lb = (sender as ListBox);
            List<TSPlayer> tsplrs = TShock.Utils.FindPlayer(lb.Items[lb.SelectedIndex].ToString());
            if (tsplrs.Count == 0)
                return;
            options.TSPlayer = tsplrs[0];
            options.ShowDialog();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            flatClose1.IsReallyQuitting = false;
            CloseDialog CloseDialog = new CloseDialog();
            CloseDialog.ShowDialog();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FlatTextBox tb = (sender as FlatTextBox);
                main.ConsoleInput.SendText(tb.Text);
                tb.Text = "";              
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Added here because people are retarded and we want to runtime exception.
            try
            {
                System.Windows.Forms.Clipboard.SetText(listBox1.ListBx.SelectedItem.ToString());
            }
            catch { }
        }

        private void flatComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (flatComboBox1.SelectedIndex)
            {
                case 0:
                    refreshTimer.Interval = 1000;
                    break;
                case 1:
                    refreshTimer.Interval = 3000;
                    break;
                case 2:
                    refreshTimer.Interval = 5000;
                    break;
                case 3:
                    refreshTimer.Interval = 30000;
                    break;
            }
        }
    }
}
