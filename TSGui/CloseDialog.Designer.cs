namespace TSGui.Extensions
{
    partial class CloseDialog
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
            this.CloseDialogSkin = new magnusi.FormSkin();
            this.BtnClose = new magnusi.FlatClose();
            this.BtnExitnosave = new magnusi.FlatButton();
            this.BtnSave = new magnusi.FlatButton();
            this.CloseDialogSkin.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseDialogSkin
            // 
            this.CloseDialogSkin.BackColor = System.Drawing.Color.White;
            this.CloseDialogSkin.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.CloseDialogSkin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.CloseDialogSkin.Controls.Add(this.BtnClose);
            this.CloseDialogSkin.Controls.Add(this.BtnExitnosave);
            this.CloseDialogSkin.Controls.Add(this.BtnSave);
            this.CloseDialogSkin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CloseDialogSkin.FlatColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.CloseDialogSkin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.CloseDialogSkin.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.CloseDialogSkin.HeaderMaximize = false;
            this.CloseDialogSkin.Location = new System.Drawing.Point(0, 0);
            this.CloseDialogSkin.Name = "CloseDialogSkin";
            this.CloseDialogSkin.Size = new System.Drawing.Size(253, 107);
            this.CloseDialogSkin.TabIndex = 0;
            this.CloseDialogSkin.Text = "Close Dialog";
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClose.BackColor = System.Drawing.Color.White;
            this.BtnClose.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.BtnClose.Font = new System.Drawing.Font("Marlett", 10F);
            this.BtnClose.Location = new System.Drawing.Point(232, 3);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(18, 18);
            this.BtnClose.TabIndex = 2;
            this.BtnClose.Text = "flatClose1";
            this.BtnClose.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnExitnosave
            // 
            this.BtnExitnosave.BackColor = System.Drawing.Color.Transparent;
            this.BtnExitnosave.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.BtnExitnosave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExitnosave.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtnExitnosave.Location = new System.Drawing.Point(134, 62);
            this.BtnExitnosave.Name = "BtnExitnosave";
            this.BtnExitnosave.Rounded = false;
            this.BtnExitnosave.Size = new System.Drawing.Size(106, 32);
            this.BtnExitnosave.TabIndex = 1;
            this.BtnExitnosave.Text = "Exit-nosave";
            this.BtnExitnosave.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.BtnExitnosave.Click += new System.EventHandler(this.BtnNosave_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.Transparent;
            this.BtnSave.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSave.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtnSave.Location = new System.Drawing.Point(12, 62);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Rounded = false;
            this.BtnSave.Size = new System.Drawing.Size(106, 32);
            this.BtnSave.TabIndex = 0;
            this.BtnSave.Text = "Save";
            this.BtnSave.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // CloseDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 107);
            this.Controls.Add(this.CloseDialogSkin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CloseDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.CloseDialogSkin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private magnusi.FormSkin CloseDialogSkin;
        private magnusi.FlatClose BtnClose;
        private magnusi.FlatButton BtnExitnosave;
        private magnusi.FlatButton BtnSave;
    }
}