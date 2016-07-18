﻿using System;
using System.Reflection;
using Mrucznik.Controllers;
using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using SampSharp.GameMode.World;

//using SampSharp.Streamer;

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

            //TODO: Pogoda - system pogody
            SetWeather(2);
            SetWorldTime(11);

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

            controllers.Remove<GtaPlayerController>();
            controllers.Remove<GtaVehicleController>();
            controllers.Add(new PlayerController());
            controllers.Add(new VehicleController());

            //Streamer.Load(this, controllers);
        }

        #endregion

        #region commands
        [Command("veh")]
        public static void KillMe(GtaPlayer player, VehicleModelType type, int color1=-1, int color2=-1)
        {
            GtaVehicle.Create(type, player.Position, color1, color2, 60);
        }

        [Command("me")]
        [Text("message")]
        public static void MeCommand(Player player, string message)
        {
            player.MeMessage(message);
        }

        [Command("do")]
        [Text("message")]
        public static void DoCommand(Player player, string message)
        {
            player.DoMessage(message);
        }
        #endregion
    }
}