using System;
using System.Reflection;
using Mrucznik.Controllers;
using Mrucznik.Items;
using Mrucznik.World;
using NLog;
using SampSharp.GameMode;
using SampSharp.GameMode.API;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using SampSharp.GameMode.World;
using SampSharp.Streamer;
using SampSharp.Streamer.Definitions;
using SampSharp.Streamer.World;

//using SampSharp.Streamer;

namespace Mrucznik
{
    public class GameMode : BaseMode
    {
        private static Logger logger = LogManager.GetLogger("testlog");
        
        private static GlobalObject dynamicObject;
        private static TextLabel dynamicTextLabel;
        private static Item item;

        #region Overrides of BaseMode

        protected override void OnInitialized(EventArgs e)
        {
            string version = "Mrucznik - RP " + Assembly.GetExecutingAssembly().GetName().Version + " - alpha";
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine("M | --- Mrucznik Role Play --- | M");
            Console.WriteLine("R | ---        ****        --- | R");
            Console.WriteLine("U | ---        v3.0        --- | U");
            Console.WriteLine("C | ---        ****        --- | C");
            Console.WriteLine("Z | ---    by Mrucznik     --- | Z");
            Console.WriteLine("N | ---                    --- | N");
            Console.WriteLine("I | ---       /\\_/\\        --- | I");
            Console.WriteLine("K | ---   ===( *.* )===    --- | K");
            Console.WriteLine("  | ---       \\_^_/        --- |  ");
            Console.WriteLine("R | ---         |          --- | R");
            Console.WriteLine("P | ---         O          --- | P");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Wersja: {0}", version);

            //Ustawienia SAMP'a
            SetGameModeText(version);
            AllowInteriorWeapons(true);
            ShowPlayerMarkers(PlayerMarkersMode.Off);
            DisableInteriorEnterExits();
            EnableStuntBonusForAll(false);
            ManualVehicleEngineAndLights();
            ShowNameTags(true);
            SetNameTagDrawDistance(20.0f);

            //TODO: Pogoda - system pogody (http://wiki.sa-mp.com/wiki/TogglePlayerClock - ToggleClock(true);)
            Server.SetWeather(2);
            Server.SetWorldTime(11);

            //Klasy:
            for(int i=0; i<311; i++)
                AddPlayerClass(i, new Vector3(1759.0189f, -1898.1260f, 13.5622f), 266.4503f);

            base.OnInitialized(e);
        }

        protected override void OnExited(EventArgs e)
        {
            base.OnExited(e);

            Console.WriteLine("----------------------------------");
            Console.WriteLine("---------- GAMEMODE OFF ----------");
            Console.WriteLine("----------------------------------");
        }

        protected override void OnIncomingConnection(ConnectionEventArgs e)
        {
            base.OnIncomingConnection(e);
        }

        protected override void OnRconCommand(RconEventArgs e)
        {
            base.OnRconCommand(e);
        }

        protected override void OnRconLoginAttempt(RconLoginAttemptEventArgs e)
        {
            base.OnRconLoginAttempt(e);
        }

        protected override void OnTick(EventArgs e)
        {
            base.OnTick(e);
        }

        protected override void LoadControllers(ControllerCollection controllers)
        {
            base.LoadControllers(controllers); //first

            controllers.Override(new PlayerController());
            controllers.Override(new VehicleController());
            
            //Streamer.Load(this, controllers);
        }

        #endregion

        #region commands
        [Command("vehicle", "veh", Shortcut = "v", DisplayName = "vehicle")]
        public static void VehicleCommand(Player player, VehicleModelType model, int color1=-1, int color2=-1)
        {
            BaseVehicle.Create(model, player.Position, color1, color2, 60);
        }
        [Command("vehicle", "veh", Shortcut = "v", DisplayName = "vehicle")]
        public static void VehicleCommand(Player player, int model, int color1 = -1, int color2 = -1)
        {
            BaseVehicle.Create((VehicleModelType)model, player.Position, color1, color2, 60);
        }

        [Command("me")]
        public static void MeCommand(Player player, string message)
        {
            player.MeMessage(message);
        }

        [Command("do")]
        public static void DoCommand(Player player, string message)
        {
            player.DoMessage(message);
        }

        [Command("object")]
        public static void ObjectCommand(Player player, int model)
        {
            player.SendInfoMessage($"Stworzono obiekt o modelu {model}");
            dynamicObject = new GlobalObject(model, player.Position, player.Rotation);
        }

        [Command("label")]
        public static void LabelCommand(Player player, string text)
        {
            player.SendInfoMessage($"Stworzono 3DText o zawartości {text}");
            dynamicTextLabel = new TextLabel(text, Color.Peru, player.Position, 25.0f, 0, false);
        }

        [Command("gunitem")]
        public static void GunItemCommand(Player player, Weapon weapon)
        {
            item = new GunItem(weapon, 100) {Position = player.Position};
        }

        [Command("movegunitem")]
        public static void MoveGunItemCommand(Player player)
        {
            if(item != null)
                item.Position = player.Position;
        }
        #endregion
    }
}