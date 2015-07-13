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
            return string.Format("{0}{1}/{2} @ {3}:{4} (TShock for Terraria v{5}) - TSGui by Ancientgods",
                        !string.IsNullOrWhiteSpace(TShock.Config.ServerName) ? TShock.Config.ServerName + " - " : "",
                        empty ? 0 : TShock.Utils.ActivePlayers(),
                        TShock.Config.MaxSlots, Netplay.ServerIP.ToString(), Netplay.ListenPort, TShock.VersionNum);
        }
    }
}
