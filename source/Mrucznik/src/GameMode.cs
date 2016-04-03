using System;
using System.Reflection;
using Mrucznik.Controllers;
using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Events;
using SampSharp.Streamer;

namespace Mrucznik
{
    public class GameMode : BaseMode
    {
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

            //TODO: Pogoda
            SetWeather(2);
            SetWorldTime(11);

            //Klasy:
            AddPlayerClass(1, new Vector3(1759.0189f, -1898.1260f, 13.5622f), 266.4503f);
            AddPlayerClass(2, new Vector3(1759.0189f, -1898.1260f, 13.5622f), 266.4503f);
            AddPlayerClass(3, new Vector3(1759.0189f, -1898.1260f, 13.5622f), 266.4503f);
            AddPlayerClass(4, new Vector3(1759.0189f, -1898.1260f, 13.5622f), 266.4503f);

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

            controllers.Remove<GtaPlayerController>();
            controllers.Remove<GtaVehicleController>();
            controllers.Add(new PlayerController());
            controllers.Add(new VehicleController());

            Streamer.Load(this, controllers);
        }
        
        #endregion
    }
}