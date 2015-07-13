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
            this.formSkin1 = new magnusi.FormSkin();
            this.flatClose1 = new magnusi.FlatClose();
            this.flatMax1 = new magnusi.FlatMax();
            this.flatMini1 = new magnusi.FlatMini();
            this.tabControl1 = new magnusi.FlatTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flatLabel1 = new magnusi.FlatLabel();
            this.listBox1 = new magnusi.FlatListBox();
            this.textBox1 = new magnusi.FlatTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox2 = new magnusi.FlatTextBox();
            this.formSkin1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // formSkin1
            // 
            this.formSkin1.BackColor = System.Drawing.Color.White;
            this.formSkin1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.formSkin1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.formSkin1.Controls.Add(this.flatClose1);
            this.formSkin1.Controls.Add(this.flatMax1);
            this.formSkin1.Controls.Add(this.flatMini1);
            this.formSkin1.Controls.Add(this.tabControl1);
            this.formSkin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formSkin1.FlatColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.formSkin1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.formSkin1.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.formSkin1.HeaderMaximize = false;
            this.formSkin1.Location = new System.Drawing.Point(0, 0);
            this.formSkin1.Name = "formSkin1";
            this.formSkin1.Size = new System.Drawing.Size(808, 464);
            this.formSkin1.TabIndex = 0;
            this.formSkin1.Text = "formSkin1";
            // 
            // flatClose1
            // 
            this.flatClose1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flatClose1.BackColor = System.Drawing.Color.White;
            this.flatClose1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.flatClose1.Font = new System.Drawing.Font("Marlett", 10F);
            this.flatClose1.Location = new System.Drawing.Point(777, 3);
            this.flatClose1.Name = "flatClose1";
            this.flatClose1.Size = new System.Drawing.Size(18, 18);
            this.flatClose1.TabIndex = 7;
            this.flatClose1.Text = "flatClose1";
            this.flatClose1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.flatClose1.Click += new System.EventHandler(this.flatClose1_Click);
            // 
            // flatMax1
            // 
            this.flatMax1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flatMax1.BackColor = System.Drawing.Color.White;
            this.flatMax1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.flatMax1.Font = new System.Drawing.Font("Marlett", 12F);
            this.flatMax1.Location = new System.Drawing.Point(754, 3);
            this.flatMax1.Name = "flatMax1";
            this.flatMax1.Size = new System.Drawing.Size(18, 18);
            this.flatMax1.TabIndex = 6;
            this.flatMax1.Text = "flatMax1";
            this.flatMax1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // flatMini1
            // 
            this.flatMini1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flatMini1.BackColor = System.Drawing.Color.White;
            this.flatMini1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.flatMini1.Font = new System.Drawing.Font("Marlett", 12F);
            this.flatMini1.Location = new System.Drawing.Point(730, 3);
            this.flatMini1.Name = "flatMini1";
            this.flatMini1.Size = new System.Drawing.Size(18, 18);
            this.flatMini1.TabIndex = 5;
            this.flatMini1.Text = "flatMini1";
            this.flatMini1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // tabControl1
            // 
            this.tabControl1.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl1.ItemSize = new System.Drawing.Size(120, 40);
            this.tabControl1.Location = new System.Drawing.Point(0, 48);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(808, 413);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tabPage1.Controls.Add(this.flatLabel1);
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 44);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(800, 365);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Console";
            // 
            // flatLabel1
            // 
            this.flatLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flatLabel1.AutoSize = true;
            this.flatLabel1.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.flatLabel1.ForeColor = System.Drawing.Color.White;
            this.flatLabel1.Location = new System.Drawing.Point(657, 8);
            this.flatLabel1.Name = "flatLabel1";
            this.flatLabel1.Size = new System.Drawing.Size(99, 19);
            this.flatLabel1.TabIndex = 6;
            this.flatLabel1.Text = "Online Players:";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.listBox1.items = new string[] {
        ""};
            this.listBox1.Location = new System.Drawing.Point(657, 30);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.listBox1.Size = new System.Drawing.Size(135, 300);
            this.listBox1.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InfoText;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Location = new System.Drawing.Point(3, 333);
            this.textBox1.MaxLength = 32767;
            this.textBox1.Multiline = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = false;
            this.textBox1.Size = new System.Drawing.Size(794, 29);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBox1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.textBox1.UseSystemPasswordChar = false;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.SystemColors.InfoText;
            this.richTextBox1.Location = new System.Drawing.Point(6, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(645, 325);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 44);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(800, 365);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Transparent;
            this.textBox2.Location = new System.Drawing.Point(147, 80);
            this.textBox2.MaxLength = 32767;
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(320, 129);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "This tab is still empty! \r\nIf you have an (awesome) idea for this tab, feel free " +
    "to post it in the discussion thread on the TShock forums for this plugin!";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBox2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.textBox2.UseSystemPasswordChar = false;
            // 
            // Gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 464);
            this.Controls.Add(this.formSkin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Gui";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.Gui_Load);
            this.formSkin1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private magnusi.FormSkin formSkin1;
        private magnusi.FlatTabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private FlatListBox listBox1;
        private FlatTextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private FlatTextBox textBox2;
        private FlatLabel flatLabel1;
        private FlatClose flatClose1;
        private FlatMax flatMax1;
        private FlatMini flatMini1;


    }
}