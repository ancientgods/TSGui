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
using System.Reflection;
using TShockAPI;
using Terraria;
using TerrariaApi.Server;
using System.Threading;
using System.Runtime.InteropServices;
using TSGui.Extensions;

namespace TSGui
{
    [ApiVersion(1, 20)]
    public class main : TerrariaPlugin
    {
        Gui gui;
        public static TaskReader ConsoleInput;
        public static bool HasWorldInitialized;

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public const int SW_HIDE = 0;
        public const int SW_SHOW = 5;
        public bool mapEnabled;
        private delegate void UpdateMapGui();
        private UpdateMapGui delegate_for_updating;
        private static System.Drawing.Bitmap worldchunk;
        private static volatile bool mutex = false;
        public static volatile int x_offset = 0;
        public static volatile int y_offset = 0;
        public static volatile int zoom_offset = 1;
        public static volatile int x1 = Terraria.Main.spawnTileX + x_offset - 600;
        public static volatile int y1 = Terraria.Main.spawnTileX + y_offset - 600;
        public static volatile int x2 = Terraria.Main.spawnTileX + x_offset + 600;
        public static volatile int y2 = Terraria.Main.spawnTileX + y_offset + 600;

        public override Version Version
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version; }
        }
        public override string Author
        {
            get { return "Ancientgods"; }
        }
        public override string Name
        {
            get { return "TSGui"; }
        }

        public override string Description
        {
            get { return "My code works, and I know why! :)"; }
        }

        public override void Initialize()
        {
            ServerApi.Hooks.GamePostInitialize.Register(this, OnPostInitialize);
            main.SetConsoleState(SW_HIDE);
            LaunchInterface();
        }

        public void OnPostInitialize(EventArgs e)
        {
            HasWorldInitialized = true;

            //check to see if the map plugin assembly has been loaded.
            AppDomain currentDomain = AppDomain.CurrentDomain;
            Assembly[] assems = currentDomain.GetAssemblies();
            mapEnabled = false;
            foreach (Assembly a in assems)
            {
                if (a.FullName.Contains("Map_TShock"))
                {
                    TShock.Log.Info("<TSGui> Found Map Plugin. Using Map.API.");
                    mapEnabled = true;
                    Thread mapupdatethread;
                    mapupdatethread = new Thread(mapupdate);
                    mapupdatethread.Name = "Map Update Thread";
                    mapupdatethread.Start();
                    while (!mapupdatethread.IsAlive) ;
                    gui.removeInfoBox();
                }
            }

            if(!mapEnabled)
            {
                gui.removeMapTab();
            }
        }

        //this function runs in the UI thread because is is being invoked as a delegate.
        public void updategui()
        {
            gui.pictureBox1.Image = (System.Drawing.Bitmap)worldchunk.Clone();
            mutex = false;
        }

        //this is running in the Map Update Thread.
        void mapupdate()
        {
            while(mapEnabled)
            {
                if (gui.isMapTabSelected() && !mutex)
                {
                    gui.check_bounds(x_offset,y_offset);
                    if(worldchunk != null)
                    {
                        worldchunk.Dispose();
                    }
                    worldchunk = Map.API.Mapper.map(x1, y1, x2, y2);
                    mutex = true;
                    delegate_for_updating = new UpdateMapGui(updategui);
                    gui.pictureBox1.Invoke(delegate_for_updating);
                }
                Thread.Sleep(10);
            }
        }

        public void LaunchInterface()
        {
            Thread t = new Thread(() =>
            {
                gui = new Gui();
                try
                {
                    ServerApi.Hooks.ServerJoin.Register(this, gui.ServerJoin);
                    ServerApi.Hooks.ServerLeave.Register(this, gui.ServerLeave);
                    ServerApi.Hooks.GameUpdate.Register(this, gui.OnUpdate);
                    ServerApi.Hooks.GamePostInitialize.Register(this, gui.OnPostInit);
                    gui.ShowDialog();                                   
                }
                catch (Exception ex)
                {
                    TShock.Log.ConsoleError("TSGui closed because it crashed: " + ex.ToString());
                }
                Environment.Exit(0);
            });
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        public static void SetConsoleState(int i)
        {
            ShowWindow(GetConsoleWindow(), i);
        }

        protected override void Dispose(bool disposing)
        {
            mapEnabled = false;
            if (disposing)
            {
                ServerApi.Hooks.GamePostInitialize.Deregister(this, OnPostInitialize);
            }
            base.Dispose(disposing);
            gui.Close();
        }

        public main(Main game)
            : base(game)
        {
            Order = 0;
        }
    }
}

