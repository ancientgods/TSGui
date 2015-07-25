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
using System.Threading.Tasks;
using TShockAPI;
using Terraria;
using TerrariaApi.Server;

namespace TSGui
{
    public class Utils
    {
        public static string GetTitle(bool empty)
        {
            var playcount = TShock.Players.Where(p => p != null && p.Active).Count();
            return string.Format("{0}{1}/{2} @ {3}:{4} (TShock for Terraria v{5}) - TSGui by Ancientgods & magnusi",
                        !string.IsNullOrWhiteSpace(TShock.Config.ServerName) ? TShock.Config.ServerName + " - " : "",
                        empty ? 0 : playcount,
                        TShock.Config.MaxSlots, Netplay.ServerIP.ToString(), Netplay.ListenPort, TShock.VersionNum);
        }
    }
}
