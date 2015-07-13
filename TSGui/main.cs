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
            get { return "My code works, and I know why! :)"; }
        }

        public override void Initialize()
        {
            main.SetConsoleState(SW_HIDE);
            LaunchInterface();
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

