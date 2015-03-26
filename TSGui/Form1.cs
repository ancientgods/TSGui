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

namespace TSGui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TShock.Utils.StopServer(true);
            this.Close();
        }

        private void noSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TShock.Utils.StopServer(false);
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                TextBox tb = (sender as TextBox);
                string msg = tb.Text;
                tb.Clear();

                if (msg.StartsWith(TShock.Config.CommandSpecifier) || msg.StartsWith(TShock.Config.CommandSilentSpecifier) || msg.StartsWith("say") || msg.Equals("who") || msg.Equals("online") || msg.Equals("playing"))
                    Commands.HandleCommand(TSPlayer.Server, msg);

                else if (msg.Equals("cls") || msg.Equals("clear"))
                    richTextBox1.Clear();

                else
                    TShock.Utils.Broadcast("(Server Broadcast) " + msg, Convert.ToByte(TShock.Config.BroadcastRGB[0]), Convert.ToByte(TShock.Config.BroadcastRGB[1]), Convert.ToByte(TShock.Config.BroadcastRGB[2]));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.ForeColor = System.Drawing.Color.FromArgb(Convert.ToByte(TShock.Config.BroadcastRGB[0]), Convert.ToByte(TShock.Config.BroadcastRGB[1]), Convert.ToByte(TShock.Config.BroadcastRGB[2]));

            Action<string> WriteToTextbox = (s) =>
            {
                if (s.Length > 0)
                {
                    richTextBox1.MainThreadInvoke(() =>
                    {
                        richTextBox1.Append(s);
                    });
                }
            };
            Console.SetOut(new InterceptingWriter(Console.Out, WriteToTextbox));
        }
    }
}
