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
            this.Btn_Kick = new System.Windows.Forms.Button();
            this.Btn_Ban = new System.Windows.Forms.Button();
            this.Tb_Reason = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Label_Account = new System.Windows.Forms.Label();
            this.Label_Group = new System.Windows.Forms.Label();
            this.Label_Ip = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Kick
            // 
            this.Btn_Kick.Location = new System.Drawing.Point(199, 111);
            this.Btn_Kick.Name = "Btn_Kick";
            this.Btn_Kick.Size = new System.Drawing.Size(50, 23);
            this.Btn_Kick.TabIndex = 0;
            this.Btn_Kick.Text = "Kick";
            this.Btn_Kick.UseVisualStyleBackColor = true;
            this.Btn_Kick.Click += new System.EventHandler(this.Btn_Kick_Click);
            // 
            // Btn_Ban
            // 
            this.Btn_Ban.Location = new System.Drawing.Point(255, 111);
            this.Btn_Ban.Name = "Btn_Ban";
            this.Btn_Ban.Size = new System.Drawing.Size(50, 23);
            this.Btn_Ban.TabIndex = 1;
            this.Btn_Ban.Text = "Ban";
            this.Btn_Ban.UseVisualStyleBackColor = true;
            this.Btn_Ban.Click += new System.EventHandler(this.Btn_Ban_Click);
            // 
            // Tb_Reason
            // 
            this.Tb_Reason.Location = new System.Drawing.Point(63, 113);
            this.Tb_Reason.Name = "Tb_Reason";
            this.Tb_Reason.Size = new System.Drawing.Size(130, 20);
            this.Tb_Reason.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Reason:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.Label_Account);
            this.panel1.Controls.Add(this.Label_Group);
            this.panel1.Controls.Add(this.Label_Ip);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 82);
            this.panel1.TabIndex = 4;
            // 
            // Label_Account
            // 
            this.Label_Account.AutoSize = true;
            this.Label_Account.Location = new System.Drawing.Point(59, 10);
            this.Label_Account.Name = "Label_Account";
            this.Label_Account.Size = new System.Drawing.Size(79, 13);
            this.Label_Account.TabIndex = 9;
            this.Label_Account.Text = "Label_Account";
            // 
            // Label_Group
            // 
            this.Label_Group.AutoSize = true;
            this.Label_Group.Location = new System.Drawing.Point(48, 57);
            this.Label_Group.Name = "Label_Group";
            this.Label_Group.Size = new System.Drawing.Size(68, 13);
            this.Label_Group.TabIndex = 8;
            this.Label_Group.Text = "Label_Group";
            // 
            // Label_Ip
            // 
            this.Label_Ip.AutoSize = true;
            this.Label_Ip.Location = new System.Drawing.Point(28, 33);
            this.Label_Ip.Name = "Label_Ip";
            this.Label_Ip.Size = new System.Drawing.Size(48, 13);
            this.Label_Ip.TabIndex = 5;
            this.Label_Ip.Text = "Label_Ip";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Ip:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Group:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Account:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "User info:";
            // 
            // UserOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 142);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Tb_Reason);
            this.Controls.Add(this.Btn_Ban);
            this.Controls.Add(this.Btn_Kick);
            this.MaximumSize = new System.Drawing.Size(333, 180);
            this.MinimumSize = new System.Drawing.Size(333, 180);
            this.Name = "UserOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UserOptions";
            this.Load += new System.EventHandler(this.UserOptions_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Kick;
        private System.Windows.Forms.Button Btn_Ban;
        private System.Windows.Forms.TextBox Tb_Reason;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Label_Account;
        private System.Windows.Forms.Label Label_Group;
        private System.Windows.Forms.Label Label_Ip;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}