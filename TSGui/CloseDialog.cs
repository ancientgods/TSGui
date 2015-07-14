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
using System.Threading.Tasks;
using System.Windows.Forms;
using TShockAPI;
using System.Threading;

namespace TSGui.Extensions
{
    public partial class CloseDialog : Form
    {
        ManualResetEvent resetEvent = new ManualResetEvent(false);
        public CloseDialog()
        {
            InitializeComponent();
        }

        private void flatClose1_Click(object sender, EventArgs e)
        {
            this.flatClose1.IsReallyQuitting = false;
            this.Close();
        }

        private void flatButton2_Click(object sender, EventArgs e)
        {
            main.ConsoleInput.SendText("exit");
            this.Close();
        }

        private void flatButton1_Click(object sender, EventArgs e)
        {
            main.ConsoleInput.SendText("exit-nosave");
            this.Close();
        }
    }
}
