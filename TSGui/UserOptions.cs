using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TShockAPI;

namespace TSGui
{
    public partial class UserOptions : Form
    {
        public TSPlayer TSPlayer;
        public UserOptions()
        {
            InitializeComponent();
        }

        private void UserOptions_Load(object sender, EventArgs e)
        {
            this.UserOPtionsSkin.Text = TSPlayer.Name;
            this.UserOPtionsSkin.Invalidate();
            Label_Account.Text = TSPlayer.Name;
            Label_Group.Text = TSPlayer.Group.Name;
            Label_Ip.Text = TSPlayer.IP;
        }

        private void Btn_Kick_Click(object sender, EventArgs e)
        {
            main.ConsoleInput.SendText(string.Format("kick {0} {1}", TSPlayer.Name, Tb_Reason.Text));
            this.Close();
        }

        private void Btn_Ban_Click(object sender, EventArgs e)
        {
            main.ConsoleInput.SendText(string.Format("ban add {0} {1}", TSPlayer.Name, Tb_Reason.Text));
            this.Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            BtnExit.IsReallyQuitting = false;
            this.Close();
        }
    }
}
