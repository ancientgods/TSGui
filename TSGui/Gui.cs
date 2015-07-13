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


namespace TSGui
{
    public partial class Gui : Form
    {
        public Gui()
        {
            InitializeComponent();
        }

        public void ServerJoin(JoinEventArgs e)
        {
            this.Text = Console.Title;
        }

        public void ServerLeave(LeaveEventArgs e)
        {
            this.Text = Console.Title;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                TextBox tb = (sender as TextBox);

                main.ConsoleInput.SendText(tb.Text);
                tb.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
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
            this.Text = Console.Title;
        }
    }
}
