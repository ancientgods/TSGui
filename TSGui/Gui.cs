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
using Map.API;


namespace TSGui
{
    public partial class Gui : Form
    {
        private bool dragging = false;
        private System.Drawing.Point start;

        public Gui()
        {
            InitializeComponent();
        }

        private void Gui_Load(object sender, EventArgs e)
        {
            bool HackyWorkAround = true;

            TextBox_Input.ForeColor = System.Drawing.Color.FromArgb(Convert.ToByte(TShock.Config.BroadcastRGB[0]), Convert.ToByte(TShock.Config.BroadcastRGB[1]), Convert.ToByte(TShock.Config.BroadcastRGB[2]));

            Action<string> WriteToTextbox = (s) =>
            {
                bool HasConsoleCleared = false;
                if (s.Length > 0)
                {
                    if (s == ": ")
                        return;

                    if ((int)s[s.Length - 1] == 52) //Clear console
                    {
                        TextBoxConsoleOutput.MainThreadInvoke(() =>
                            {
                                HasConsoleCleared = true;
                                if (HackyWorkAround)
                                {
                                    HackyWorkAround = false;
                                    TextBoxConsoleOutput.AppendText(string.Empty);
                                    return;
                                }
                                TextBoxConsoleOutput.Clear();
                            });
                        GuiSkin.Text = Console.Title;
                        GuiSkin.Invalidate();
                    }
                    TextBoxConsoleOutput.MainThreadInvoke(() =>
                    {
                        TextBoxConsoleOutput.Append(s, Console.ForegroundColor);
                        if (HasConsoleCleared)
                            TextBoxConsoleOutput.Append(string.Empty);
                    });
                }
            };
            main.ConsoleInput = new TaskReader(Console.In);
            Console.SetOut(new TaskWriter(Console.Out, WriteToTextbox)); //Redirect console output to RichTextBox
            Console.SetIn(main.ConsoleInput); //Redirect console input to textbox

            ListBoxUsernames.ListBoxSkin.MouseDoubleClick += ListBoxUsernames_MouseDoubleClick; //Add here because the designer removes the code (because of the .ListBX).
            pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
            pictureBox1.MouseUp += new MouseEventHandler(pictureBox1_MouseUp);
            pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
            pictureBox1.MouseWheel += new MouseEventHandler(pictureBox1_MouseWheel);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        #region Hooks
        public void ServerJoin(JoinEventArgs e)
        {
            ListBoxUsernames.MainThreadInvoke(() =>
            {
                ListBoxUsernames.Clear();
                ListBoxUsernames.AddRange((from tsplr in TShock.Players where tsplr != null orderby tsplr.Name select tsplr.Name).ToArray());
            });
        }

        public void ServerLeave(LeaveEventArgs e)
        {
            ListBoxUsernames.MainThreadInvoke(() =>
            {
                ListBoxUsernames.Clear();
                ListBoxUsernames.AddRange((from tsplr in TShock.Players where tsplr != null && tsplr.Index != e.Who orderby tsplr.Name select tsplr.Name).ToArray());
            });
            if (TShock.Utils.ActivePlayers() == 1)
            {
                GuiSkin.Text = Utils.GetTitle(true);
                GuiSkin.Invalidate();
            }
        }

        public void OnPostInit(EventArgs e)
        {
            GuiSkin.Text = Utils.GetTitle(false);
            GuiSkin.Invalidate();
        }

        DateTime LastCheck = DateTime.UtcNow;
        public void OnUpdate(EventArgs e)
        {
            if ((DateTime.UtcNow - LastCheck).TotalSeconds >= 1)
            {
                GuiSkin.Text = Utils.GetTitle(false);
                GuiSkin.Invalidate();
            }
        }
        #endregion Hooks

        void ListBoxUsernames_MouseDoubleClick(object sender, MouseEventArgs e)
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
            if (main.HasWorldInitialized)
            {
                GuiClose.IsReallyQuitting = false;
                CloseDialog CloseDialog = new CloseDialog();
                CloseDialog.ShowDialog();
            }
            else
                GuiClose.IsReallyQuitting = true;
        }

        private void TextBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FlatTextBox tb = (sender as FlatTextBox);
                string[] input = tb.Text.Split(';');
                for (int i = 0; i < input.Length; i++)
                {
                    TextBoxConsoleOutput.Append(input[i]);
                    main.ConsoleInput.SendText(input[i]);
                }
                tb.Text = string.Empty;
            }
        }

        private void TextBox_Input_MouseEnter(object sender, EventArgs e)
        {
            if (TextBox_Input.Text == "Enter text")
                TextBox_Input.Text = "";
        }

        private void TextBoxConsoleOutput_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (TextBox_Input.Text == "Enter text")
                TextBox_Input.Text = "";
            TextBox_Input.Text += e.KeyChar;
            TextBox_Input.TB.Focus();
            TextBox_Input.TB.Select(1, 0);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListBoxUsernames.ListBoxSkin.SelectedIndex >= 0 && ListBoxUsernames.ListBoxSkin.SelectedIndex < ListBoxUsernames.ListBoxSkin.Items.Count)
            {
                string text = ListBoxUsernames.ListBoxSkin.Items[ListBoxUsernames.ListBoxSkin.SelectedIndex].ToString();
                if (!string.IsNullOrEmpty(text))
                {
                    System.Windows.Forms.Clipboard.SetText(ListBoxUsernames.ListBoxSkin.SelectedItem.ToString());
                    TextBoxConsoleOutput.Append("Copied \"" + ListBoxUsernames.ListBoxSkin.SelectedItem.ToString() + "\" to clipboard.");
                    return;
                }
            }
            TextBoxConsoleOutput.Append("Failed to copy username to clipboard! (No item selected)");
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                start = e.Location;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                int temp_x_offset = main.x_offset;
                int temp_y_offset = main.y_offset;

                temp_x_offset += (start.X - e.X);
                temp_y_offset += (start.Y - e.Y);
                start = e.Location;

                check_bounds(temp_x_offset, temp_y_offset);
            }
        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                main.zoom_offset++;
            }
            else
            {
                main.zoom_offset--;
            }

            if (main.zoom_offset < 1)
            {
                main.zoom_offset = 1;
            }
            if (main.zoom_offset > 4)
            {
                main.zoom_offset = 4;
            }

            check_bounds(main.x_offset, main.y_offset);
        }

        public void check_bounds(int temp_x_offset, int temp_y_offset)
        {
            int imagecenter_x = Terraria.Main.spawnTileX + temp_x_offset;
            int imagecenter_y = Terraria.Main.spawnTileY + temp_y_offset;

            main.x1 = imagecenter_x - ((pictureBox1.Width / 2) / main.zoom_offset);
            main.y1 = imagecenter_y - ((pictureBox1.Height / 2) / main.zoom_offset);
            main.x2 = imagecenter_x + ((pictureBox1.Width / 2) / main.zoom_offset);
            main.y2 = imagecenter_y + ((pictureBox1.Height / 2) / main.zoom_offset);

            //x bounds
            if (main.x1 < 2)
            {
                temp_x_offset = -(Terraria.Main.spawnTileX - (pictureBox1.Width / (2 * main.zoom_offset))) + 2;
            }
            if (main.x2 >= Terraria.Main.maxTilesX)
            {
                temp_x_offset = Terraria.Main.maxTilesX - (Terraria.Main.spawnTileX + (pictureBox1.Width / (2 * main.zoom_offset))) - 1;
            }

            //y bounds
            if (main.y1 < 1)
            {
                temp_y_offset = -(Terraria.Main.spawnTileY - (pictureBox1.Height / (2 * main.zoom_offset))) + 1;
            }
            if (main.y2 >= Main.maxTilesY)
            {
                temp_y_offset = Terraria.Main.maxTilesY - (Terraria.Main.spawnTileY + (pictureBox1.Height / (2 * main.zoom_offset))) - 1;
            }

            main.x_offset = temp_x_offset;
            main.y_offset = temp_y_offset;
        }
    }
}
