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
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using TShockAPI;
using Terraria;
using TerrariaApi.Server;
using TSGui.Extensions;
using magnusi;


namespace TSGui
{
    public partial class Gui : Form
    {
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
    }
}
