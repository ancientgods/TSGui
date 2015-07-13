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
                        this.Text = Console.Title;
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
        }
        //private void InputBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyData == Keys.Enter)
        //    {
        //        e.SuppressKeyPress = true;
        //        TextBox tb = (sender as TextBox);

        //        main.ConsoleInput.SendText(tb.Text);
        //        tb.Clear();
        //    }
        //}


        #region Hooks
        public void ServerJoin(JoinEventArgs e)
        {
            listBox1.MainThreadInvoke(() =>
                {
                    listBox1.Clear();
                    listBox1.AddRange((from tsplr in TShock.Players where tsplr != null select tsplr.Name).ToArray());
                });
        }

        public void ServerLeave(LeaveEventArgs e)
        {
            listBox1.MainThreadInvoke(() =>
            {
                listBox1.Clear();
                listBox1.AddRange((from tsplr in TShock.Players where tsplr != null && tsplr.Index != e.Who select tsplr.Name).ToArray());
            });
            if (TShock.Utils.ActivePlayers() == 1)
            {
                this.Text = Utils.GetTitle(true);
            }
        }

        public void OnPostInit(EventArgs e)
        {
            this.Text = Utils.GetTitle(false);
        }

        DateTime LastCheck = DateTime.UtcNow;
        public void OnUpdate(EventArgs e)
        {
            if ((DateTime.UtcNow - LastCheck).TotalSeconds >= 1)
            {
                this.Text = Utils.GetTitle(false);
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

        private void flatClose1_Click(object sender, EventArgs e)
        {
            Form1 CloseDialog = new Form1();
            CloseDialog.ShowDialog();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FlatTextBox tb = (sender as FlatTextBox);

                main.ConsoleInput.SendText(tb.Text);
                tb.Text = "";
            }
        }
    }
}
