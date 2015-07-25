using magnusi;
namespace TSGui
{
    partial class Gui
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gui));
            this.GuiSkin = new magnusi.FormSkin();
            this.GuiClose = new magnusi.FlatClose();
            this.GuiMax = new magnusi.FlatMax();
            this.GuiMin = new magnusi.FlatMini();
            this.TabControl = new magnusi.FlatTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LabelPlayers = new magnusi.FlatLabel();
            this.ListBoxUsernames = new magnusi.FlatListBox();
            this.ListBoxUsernamesContextMenu = new magnusi.FlatContextMenuStrip();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextBox_Input = new magnusi.FlatTextBox();
            this.TextBoxConsoleOutput = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.GuiSkin.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.ListBoxUsernamesContextMenu.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GuiSkin
            // 
            this.GuiSkin.BackColor = System.Drawing.Color.White;
            this.GuiSkin.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.GuiSkin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.GuiSkin.Controls.Add(this.GuiClose);
            this.GuiSkin.Controls.Add(this.GuiMax);
            this.GuiSkin.Controls.Add(this.GuiMin);
            this.GuiSkin.Controls.Add(this.TabControl);
            this.GuiSkin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GuiSkin.FlatColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.GuiSkin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.GuiSkin.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.GuiSkin.HeaderMaximize = false;
            this.GuiSkin.Location = new System.Drawing.Point(0, 0);
            this.GuiSkin.Name = "GuiSkin";
            this.GuiSkin.Size = new System.Drawing.Size(808, 464);
            this.GuiSkin.TabIndex = 0;
            this.GuiSkin.Text = "Gui - by Ancientgods & magnusi";
            // 
            // GuiClose
            // 
            this.GuiClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GuiClose.BackColor = System.Drawing.Color.White;
            this.GuiClose.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.GuiClose.Font = new System.Drawing.Font("Marlett", 10F);
            this.GuiClose.Location = new System.Drawing.Point(787, 3);
            this.GuiClose.Name = "GuiClose";
            this.GuiClose.Size = new System.Drawing.Size(18, 18);
            this.GuiClose.TabIndex = 7;
            this.GuiClose.Text = "flatClose1";
            this.GuiClose.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.GuiClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // GuiMax
            // 
            this.GuiMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GuiMax.BackColor = System.Drawing.Color.White;
            this.GuiMax.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.GuiMax.Font = new System.Drawing.Font("Marlett", 12F);
            this.GuiMax.Location = new System.Drawing.Point(764, 3);
            this.GuiMax.Name = "GuiMax";
            this.GuiMax.Size = new System.Drawing.Size(18, 18);
            this.GuiMax.TabIndex = 6;
            this.GuiMax.Text = "flatMax1";
            this.GuiMax.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // GuiMin
            // 
            this.GuiMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GuiMin.BackColor = System.Drawing.Color.White;
            this.GuiMin.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.GuiMin.Font = new System.Drawing.Font("Marlett", 12F);
            this.GuiMin.Location = new System.Drawing.Point(740, 3);
            this.GuiMin.Name = "GuiMin";
            this.GuiMin.Size = new System.Drawing.Size(18, 18);
            this.GuiMin.TabIndex = 5;
            this.GuiMin.Text = "flatMini1";
            this.GuiMin.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // TabControl
            // 
            this.TabControl.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Controls.Add(this.tabPage2);
            this.TabControl.Controls.Add(this.tabPage3);
            this.TabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TabControl.ItemSize = new System.Drawing.Size(120, 40);
            this.TabControl.Location = new System.Drawing.Point(0, 48);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(808, 413);
            this.TabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabControl.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tabPage1.Controls.Add(this.LabelPlayers);
            this.tabPage1.Controls.Add(this.ListBoxUsernames);
            this.tabPage1.Controls.Add(this.TextBox_Input);
            this.tabPage1.Controls.Add(this.TextBoxConsoleOutput);
            this.tabPage1.Location = new System.Drawing.Point(4, 44);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(800, 365);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Console";
            // 
            // LabelPlayers
            // 
            this.LabelPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelPlayers.AutoSize = true;
            this.LabelPlayers.BackColor = System.Drawing.Color.Transparent;
            this.LabelPlayers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.LabelPlayers.ForeColor = System.Drawing.Color.White;
            this.LabelPlayers.Location = new System.Drawing.Point(657, 3);
            this.LabelPlayers.Name = "LabelPlayers";
            this.LabelPlayers.Size = new System.Drawing.Size(99, 19);
            this.LabelPlayers.TabIndex = 6;
            this.LabelPlayers.Text = "Online Players:";
            // 
            // ListBoxUsernames
            // 
            this.ListBoxUsernames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBoxUsernames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.ListBoxUsernames.ContextMenuStrip = this.ListBoxUsernamesContextMenu;
            this.ListBoxUsernames.items = new string[] {
        ""};
            this.ListBoxUsernames.Location = new System.Drawing.Point(657, 27);
            this.ListBoxUsernames.Name = "ListBoxUsernames";
            this.ListBoxUsernames.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.ListBoxUsernames.Size = new System.Drawing.Size(135, 300);
            this.ListBoxUsernames.TabIndex = 4;
            // 
            // ListBoxUsernamesContextMenu
            // 
            this.ListBoxUsernamesContextMenu.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.ListBoxUsernamesContextMenu.ForeColor = System.Drawing.Color.White;
            this.ListBoxUsernamesContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.ListBoxUsernamesContextMenu.Name = "ListBoxUsernamesContextMenu";
            this.ListBoxUsernamesContextMenu.ShowImageMargin = false;
            this.ListBoxUsernamesContextMenu.Size = new System.Drawing.Size(76, 26);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(75, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // TextBox_Input
            // 
            this.TextBox_Input.BackColor = System.Drawing.SystemColors.InfoText;
            this.TextBox_Input.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TextBox_Input.Location = new System.Drawing.Point(3, 333);
            this.TextBox_Input.MaxLength = 32767;
            this.TextBox_Input.Multiline = true;
            this.TextBox_Input.Name = "TextBox_Input";
            this.TextBox_Input.ReadOnly = false;
            this.TextBox_Input.Size = new System.Drawing.Size(794, 29);
            this.TextBox_Input.TabIndex = 3;
            this.TextBox_Input.Text = "Enter text";
            this.TextBox_Input.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBox_Input.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.TextBox_Input.UseSystemPasswordChar = false;
            this.TextBox_Input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxInput_KeyDown);
            this.TextBox_Input.MouseEnter += new System.EventHandler(this.TextBox_Input_MouseEnter);
            // 
            // TextBoxConsoleOutput
            // 
            this.TextBoxConsoleOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxConsoleOutput.BackColor = System.Drawing.SystemColors.InfoText;
            this.TextBoxConsoleOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxConsoleOutput.Location = new System.Drawing.Point(6, 8);
            this.TextBoxConsoleOutput.Name = "TextBoxConsoleOutput";
            this.TextBoxConsoleOutput.ReadOnly = true;
            this.TextBoxConsoleOutput.Size = new System.Drawing.Size(645, 319);
            this.TextBoxConsoleOutput.TabIndex = 2;
            this.TextBoxConsoleOutput.Text = "";
            this.TextBoxConsoleOutput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxConsoleOutput_KeyPress);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 44);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(800, 365);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Map";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(8, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(784, 353);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tabPage3.Location = new System.Drawing.Point(4, 44);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(800, 365);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            // 
            // Gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 464);
            this.Controls.Add(this.GuiSkin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Gui";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.Gui_Load);
            this.GuiSkin.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ListBoxUsernamesContextMenu.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private magnusi.FormSkin GuiSkin;
        public magnusi.FlatTabControl TabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private FlatListBox ListBoxUsernames;
        private FlatTextBox TextBox_Input;
        private System.Windows.Forms.RichTextBox TextBoxConsoleOutput;
        private System.Windows.Forms.TabPage tabPage2;
        private FlatLabel LabelPlayers;
        private FlatClose GuiClose;
        private FlatMax GuiMax;
        private FlatMini GuiMin;
        private FlatContextMenuStrip ListBoxUsernamesContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage3;


    }
}