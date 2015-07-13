using System;
using System.Collections.Generic;
using System.Reflection;
using TShockAPI;
using Terraria;
using System.Timers;
using TerrariaApi.Server;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using TShockAPI.Hooks;
using TSGui.Extensions;

namespace TSGui
{
    [ApiVersion(1, 19)]
    public class main : TerrariaPlugin
    {
        public static TaskReader ConsoleInput;


        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public const int SW_HIDE = 0;
        public const int SW_SHOW = 5;
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
            get { return ""; }
        }

        public override void Initialize()
        {
            LaunchInterface();
            //ServerApi.Hooks.GamePostInitialize.Register(this, PostInitialize);
        }

        private void PostInitialize(EventArgs e)
        {
           // LaunchInterface();
        }

        public void LaunchInterface()
        {
            Thread t = new Thread(() =>
            {
                Gui gui = new Gui();
                try
                {
                    ServerApi.Hooks.ServerJoin.Register(this, gui.ServerJoin);
                    ServerApi.Hooks.ServerLeave.Register(this, gui.ServerLeave);
                    main.SetConsoleState(main.SW_HIDE);
                    
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
            var handle = GetConsoleWindow();
            ShowWindow(handle, i);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }

        public main(Main game)
            : base(game)
        {
            Order = 0;
        }
    }
}

