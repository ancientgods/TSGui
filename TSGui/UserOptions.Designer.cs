namespace TSGui
{
    partial class UserOptions
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
            this.formSkin1 = new magnusi.FormSkin();
            this.flatClose1 = new magnusi.FlatClose();
            this.Btn_Ban = new magnusi.FlatButton();
            this.Btn_Kick = new magnusi.FlatButton();
            this.flatLabel5 = new magnusi.FlatLabel();
            this.Label_Group = new magnusi.FlatLabel();
            this.Label_Ip = new magnusi.FlatLabel();
            this.Label_Account = new magnusi.FlatLabel();
            this.flatLabel4 = new magnusi.FlatLabel();
            this.flatLabel3 = new magnusi.FlatLabel();
            this.flatLabel2 = new magnusi.FlatLabel();
            this.flatLabel1 = new magnusi.FlatLabel();
            this.Tb_Reason = new System.Windows.Forms.TextBox();
            this.formSkin1.SuspendLayout();
            this.SuspendLayout();
            // 
            // formSkin1
            // 
            this.formSkin1.BackColor = System.Drawing.Color.White;
            this.formSkin1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.formSkin1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.formSkin1.Controls.Add(this.flatClose1);
            this.formSkin1.Controls.Add(this.Btn_Ban);
            this.formSkin1.Controls.Add(this.Btn_Kick);
            this.formSkin1.Controls.Add(this.flatLabel5);
            this.formSkin1.Controls.Add(this.Label_Group);
            this.formSkin1.Controls.Add(this.Label_Ip);
            this.formSkin1.Controls.Add(this.Label_Account);
            this.formSkin1.Controls.Add(this.flatLabel4);
            this.formSkin1.Controls.Add(this.flatLabel3);
            this.formSkin1.Controls.Add(this.flatLabel2);
            this.formSkin1.Controls.Add(this.flatLabel1);
            this.formSkin1.Controls.Add(this.Tb_Reason);
            this.formSkin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formSkin1.FlatColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.formSkin1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.formSkin1.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.formSkin1.HeaderMaximize = false;
            this.formSkin1.Location = new System.Drawing.Point(0, 0);
            this.formSkin1.Name = "formSkin1";
            this.formSkin1.Size = new System.Drawing.Size(384, 202);
            this.formSkin1.TabIndex = 0;
            this.formSkin1.Text = "Name Placeholder";
            // 
            // flatClose1
            // 
            this.flatClose1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flatClose1.BackColor = System.Drawing.Color.White;
            this.flatClose1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.flatClose1.Font = new System.Drawing.Font("Marlett", 10F);
            this.flatClose1.Location = new System.Drawing.Point(363, 3);
            this.flatClose1.Name = "flatClose1";
            this.flatClose1.Size = new System.Drawing.Size(18, 18);
            this.flatClose1.TabIndex = 26;
            this.flatClose1.Text = "flatClose1";
            this.flatClose1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.flatClose1.Click += new System.EventHandler(this.flatClose1_Click);
            // 
            // Btn_Ban
            // 
            this.Btn_Ban.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Ban.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.Btn_Ban.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Ban.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Btn_Ban.Location = new System.Drawing.Point(303, 163);
            this.Btn_Ban.Name = "Btn_Ban";
            this.Btn_Ban.Rounded = false;
            this.Btn_Ban.Size = new System.Drawing.Size(72, 30);
            this.Btn_Ban.TabIndex = 25;
            this.Btn_Ban.Text = "Ban";
            this.Btn_Ban.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.Btn_Ban.Click += new System.EventHandler(this.Btn_Ban_Click);
            // 
            // Btn_Kick
            // 
            this.Btn_Kick.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Kick.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.Btn_Kick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Kick.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Btn_Kick.Location = new System.Drawing.Point(230, 163);
            this.Btn_Kick.Name = "Btn_Kick";
            this.Btn_Kick.Rounded = false;
            this.Btn_Kick.Size = new System.Drawing.Size(67, 30);
            this.Btn_Kick.TabIndex = 24;
            this.Btn_Kick.Text = "Kick";
            this.Btn_Kick.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.Btn_Kick.Click += new System.EventHandler(this.Btn_Kick_Click);
            // 
            // flatLabel5
            // 
            this.flatLabel5.AutoSize = true;
            this.flatLabel5.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel5.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel5.ForeColor = System.Drawing.Color.White;
            this.flatLabel5.Location = new System.Drawing.Point(9, 167);
            this.flatLabel5.Name = "flatLabel5";
            this.flatLabel5.Size = new System.Drawing.Size(79, 26);
            this.flatLabel5.TabIndex = 23;
            this.flatLabel5.Text = "Reason:";
            // 
            // Label_Group
            // 
            this.Label_Group.AutoSize = true;
            this.Label_Group.BackColor = System.Drawing.Color.Transparent;
            this.Label_Group.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Group.ForeColor = System.Drawing.Color.White;
            this.Label_Group.Location = new System.Drawing.Point(79, 126);
            this.Label_Group.Name = "Label_Group";
            this.Label_Group.Size = new System.Drawing.Size(86, 18);
            this.Label_Group.TabIndex = 22;
            this.Label_Group.Text = "Label_Group";
            // 
            // Label_Ip
            // 
            this.Label_Ip.AutoSize = true;
            this.Label_Ip.BackColor = System.Drawing.Color.Transparent;
            this.Label_Ip.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Ip.ForeColor = System.Drawing.Color.White;
            this.Label_Ip.Location = new System.Drawing.Point(79, 109);
            this.Label_Ip.Name = "Label_Ip";
            this.Label_Ip.Size = new System.Drawing.Size(60, 18);
            this.Label_Ip.TabIndex = 21;
            this.Label_Ip.Text = "Label_Ip";
            // 
            // Label_Account
            // 
            this.Label_Account.AutoSize = true;
            this.Label_Account.BackColor = System.Drawing.Color.Transparent;
            this.Label_Account.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Account.ForeColor = System.Drawing.Color.White;
            this.Label_Account.Location = new System.Drawing.Point(79, 91);
            this.Label_Account.Name = "Label_Account";
            this.Label_Account.Size = new System.Drawing.Size(98, 18);
            this.Label_Account.TabIndex = 20;
            this.Label_Account.Text = "Label_Account";
            // 
            // flatLabel4
            // 
            this.flatLabel4.AutoSize = true;
            this.flatLabel4.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel4.ForeColor = System.Drawing.Color.White;
            this.flatLabel4.Location = new System.Drawing.Point(11, 126);
            this.flatLabel4.Name = "flatLabel4";
            this.flatLabel4.Size = new System.Drawing.Size(50, 18);
            this.flatLabel4.TabIndex = 19;
            this.flatLabel4.Text = "Group:";
            // 
            // flatLabel3
            // 
            this.flatLabel3.AutoSize = true;
            this.flatLabel3.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel3.ForeColor = System.Drawing.Color.White;
            this.flatLabel3.Location = new System.Drawing.Point(11, 109);
            this.flatLabel3.Name = "flatLabel3";
            this.flatLabel3.Size = new System.Drawing.Size(24, 18);
            this.flatLabel3.TabIndex = 18;
            this.flatLabel3.Text = "Ip:";
            // 
            // flatLabel2
            // 
            this.flatLabel2.AutoSize = true;
            this.flatLabel2.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel2.ForeColor = System.Drawing.Color.White;
            this.flatLabel2.Location = new System.Drawing.Point(11, 91);
            this.flatLabel2.Name = "flatLabel2";
            this.flatLabel2.Size = new System.Drawing.Size(62, 18);
            this.flatLabel2.TabIndex = 17;
            this.flatLabel2.Text = "Account:";
            // 
            // flatLabel1
            // 
            this.flatLabel1.AutoSize = true;
            this.flatLabel1.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel1.ForeColor = System.Drawing.Color.White;
            this.flatLabel1.Location = new System.Drawing.Point(10, 56);
            this.flatLabel1.Name = "flatLabel1";
            this.flatLabel1.Size = new System.Drawing.Size(85, 23);
            this.flatLabel1.TabIndex = 10;
            this.flatLabel1.Text = "User info:";
            // 
            // Tb_Reason
            // 
            this.Tb_Reason.Location = new System.Drawing.Point(94, 164);
            this.Tb_Reason.Name = "Tb_Reason";
            this.Tb_Reason.Size = new System.Drawing.Size(130, 29);
            this.Tb_Reason.TabIndex = 8;
            // 
            // UserOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 202);
            this.Controls.Add(this.formSkin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserOptions";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.UserOptions_Load);
            this.formSkin1.ResumeLayout(false);
            this.formSkin1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private magnusi.FormSkin formSkin1;
        private magnusi.FlatLabel Label_Group;
        private magnusi.FlatLabel Label_Ip;
        private magnusi.FlatLabel Label_Account;
        private magnusi.FlatLabel flatLabel4;
        private magnusi.FlatLabel flatLabel3;
        private magnusi.FlatLabel flatLabel2;
        private magnusi.FlatLabel flatLabel1;
        private System.Windows.Forms.TextBox Tb_Reason;
        private magnusi.FlatButton Btn_Kick;
        private magnusi.FlatLabel flatLabel5;
        private magnusi.FlatButton Btn_Ban;
        private magnusi.FlatClose flatClose1;

    }
}