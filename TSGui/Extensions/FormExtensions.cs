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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TShockAPI;

namespace TSGui.Extensions
{
    public static class FormExtensions
    {
        
        public static void MainThreadInvoke(this Control control, Action func)
        {
            if (control.InvokeRequired)
                control.Invoke(func);
            else
                func();
        }

        public static void Append(this RichTextBox rtb, string text)
        {
            Append(rtb, text, Convert.ToByte(TShock.Config.BroadcastRGB[0]), Convert.ToByte(TShock.Config.BroadcastRGB[1]), Convert.ToByte(TShock.Config.BroadcastRGB[2]));
        }

        public static void Append(this RichTextBox rtb, string text, int r, int g, int b)
        {
            Append(rtb, text, System.Drawing.Color.FromArgb(r, g, b));
        }

        public static void Append(this RichTextBox rtb, string text, ConsoleColor c)
        {
            System.Drawing.Color systemColor = System.Drawing.Color.FromName(c.ToString());
            if (systemColor.R + systemColor.G + systemColor.B < 100) //Too dark to be visible in the console
                systemColor = System.Drawing.Color.FromArgb(128, 128, 128); //Gray
            Append(rtb, text, systemColor);
        }

        public static void Append(this RichTextBox rtb, string text, System.Drawing.Color c)
        {
            rtb.SelectionColor = c;
            rtb.AppendText(text + "\r\n");
            rtb.ScrollToCaret();
        }  
    }
}
