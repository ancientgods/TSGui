﻿namespace TSGui
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
            this.UserOPtionsSkin = new magnusi.FormSkin();
            this.BtnExit = new magnusi.FlatClose();
            this.Btn_Ban = new magnusi.FlatButton();
            this.Btn_Kick = new magnusi.FlatButton();
            this.Label_Reason = new magnusi.FlatLabel();
            this.Label_Group = new magnusi.FlatLabel();
            this.Label_Ip = new magnusi.FlatLabel();
            this.Label_Account = new magnusi.FlatLabel();
            this.LabelGroup = new magnusi.FlatLabel();
            this.LabelIp = new magnusi.FlatLabel();
            this.LabelAcc = new magnusi.FlatLabel();
            this.Label_Userinfo = new magnusi.FlatLabel();
            this.Tb_Reason = new System.Windows.Forms.TextBox();
            this.UserOPtionsSkin.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserOPtionsSkin
            // 
            this.UserOPtionsSkin.BackColor = System.Drawing.Color.White;
            this.UserOPtionsSkin.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.UserOPtionsSkin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.UserOPtionsSkin.Controls.Add(this.BtnExit);
            this.UserOPtionsSkin.Controls.Add(this.Btn_Ban);
            this.UserOPtionsSkin.Controls.Add(this.Btn_Kick);
            this.UserOPtionsSkin.Controls.Add(this.Label_Reason);
            this.UserOPtionsSkin.Controls.Add(this.Label_Group);
            this.UserOPtionsSkin.Controls.Add(this.Label_Ip);
            this.UserOPtionsSkin.Controls.Add(this.Label_Account);
            this.UserOPtionsSkin.Controls.Add(this.LabelGroup);
            this.UserOPtionsSkin.Controls.Add(this.LabelIp);
            this.UserOPtionsSkin.Controls.Add(this.LabelAcc);
            this.UserOPtionsSkin.Controls.Add(this.Label_Userinfo);
            this.UserOPtionsSkin.Controls.Add(this.Tb_Reason);
            this.UserOPtionsSkin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserOPtionsSkin.FlatColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.UserOPtionsSkin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.UserOPtionsSkin.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.UserOPtionsSkin.HeaderMaximize = false;
            this.UserOPtionsSkin.Location = new System.Drawing.Point(0, 0);
            this.UserOPtionsSkin.Name = "UserOPtionsSkin";
            this.UserOPtionsSkin.Size = new System.Drawing.Size(384, 202);
            this.UserOPtionsSkin.TabIndex = 0;
            this.UserOPtionsSkin.Text = "Name Placeholder";
            // 
            // BtnExit
            // 
            this.BtnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExit.BackColor = System.Drawing.Color.White;
            this.BtnExit.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.BtnExit.Font = new System.Drawing.Font("Marlett", 10F);
            this.BtnExit.Location = new System.Drawing.Point(363, 3);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(18, 18);
            this.BtnExit.TabIndex = 26;
            this.BtnExit.Text = "flatClose1";
            this.BtnExit.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.BtnExit.Click += new System.EventHandler(this.BtnClose_Click);
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
            // Label_Reason
            // 
            this.Label_Reason.AutoSize = true;
            this.Label_Reason.BackColor = System.Drawing.Color.Transparent;
            this.Label_Reason.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Reason.ForeColor = System.Drawing.Color.White;
            this.Label_Reason.Location = new System.Drawing.Point(9, 167);
            this.Label_Reason.Name = "Label_Reason";
            this.Label_Reason.Size = new System.Drawing.Size(79, 26);
            this.Label_Reason.TabIndex = 23;
            this.Label_Reason.Text = "Reason:";
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
            // LabelGroup
            // 
            this.LabelGroup.AutoSize = true;
            this.LabelGroup.BackColor = System.Drawing.Color.Transparent;
            this.LabelGroup.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGroup.ForeColor = System.Drawing.Color.White;
            this.LabelGroup.Location = new System.Drawing.Point(11, 126);
            this.LabelGroup.Name = "LabelGroup";
            this.LabelGroup.Size = new System.Drawing.Size(50, 18);
            this.LabelGroup.TabIndex = 19;
            this.LabelGroup.Text = "Group:";
            // 
            // LabelIp
            // 
            this.LabelIp.AutoSize = true;
            this.LabelIp.BackColor = System.Drawing.Color.Transparent;
            this.LabelIp.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelIp.ForeColor = System.Drawing.Color.White;
            this.LabelIp.Location = new System.Drawing.Point(11, 109);
            this.LabelIp.Name = "LabelIp";
            this.LabelIp.Size = new System.Drawing.Size(24, 18);
            this.LabelIp.TabIndex = 18;
            this.LabelIp.Text = "Ip:";
            // 
            // LabelAcc
            // 
            this.LabelAcc.AutoSize = true;
            this.LabelAcc.BackColor = System.Drawing.Color.Transparent;
            this.LabelAcc.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAcc.ForeColor = System.Drawing.Color.White;
            this.LabelAcc.Location = new System.Drawing.Point(11, 91);
            this.LabelAcc.Name = "LabelAcc";
            this.LabelAcc.Size = new System.Drawing.Size(62, 18);
            this.LabelAcc.TabIndex = 17;
            this.LabelAcc.Text = "Account:";
            // 
            // Label_Userinfo
            // 
            this.Label_Userinfo.AutoSize = true;
            this.Label_Userinfo.BackColor = System.Drawing.Color.Transparent;
            this.Label_Userinfo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Userinfo.ForeColor = System.Drawing.Color.White;
            this.Label_Userinfo.Location = new System.Drawing.Point(10, 56);
            this.Label_Userinfo.Name = "Label_Userinfo";
            this.Label_Userinfo.Size = new System.Drawing.Size(85, 23);
            this.Label_Userinfo.TabIndex = 10;
            this.Label_Userinfo.Text = "User info:";
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
            this.Controls.Add(this.UserOPtionsSkin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserOptions";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.UserOptions_Load);
            this.UserOPtionsSkin.ResumeLayout(false);
            this.UserOPtionsSkin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private magnusi.FormSkin UserOPtionsSkin;
        private magnusi.FlatLabel Label_Group;
        private magnusi.FlatLabel Label_Ip;
        private magnusi.FlatLabel Label_Account;
        private magnusi.FlatLabel LabelGroup;
        private magnusi.FlatLabel LabelIp;
        private magnusi.FlatLabel LabelAcc;
        private magnusi.FlatLabel Label_Userinfo;
        private System.Windows.Forms.TextBox Tb_Reason;
        private magnusi.FlatButton Btn_Kick;
        private magnusi.FlatLabel Label_Reason;
        private magnusi.FlatButton Btn_Ban;
        private magnusi.FlatClose BtnExit;

    }
}