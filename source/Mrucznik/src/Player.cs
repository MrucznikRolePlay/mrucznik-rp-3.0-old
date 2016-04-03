using System;
using System.Text.RegularExpressions;
using SampSharp.GameMode;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.Tools;
using SampSharp.GameMode.World;

namespace Mrucznik
{
    public class Player : GtaPlayer
    {
        public Player(int id) : base(id)
        {
        }

        #region Overrided
        public override void OnConnected(EventArgs e)
        {
            base.OnConnected(e);

            ClearChat();
            SendClientMessage(Color.White, "SERVER: Witaj {0}", Name);
            
            if (!IsNickCorrect())
            {
                SendClientMessage("Nick {0} jest niepoprawny!", Name);
                Kick();
                return;
            }
            
            Delay.Run(100, () => //Wybierałka
            {
                Position = new Vector3(-2819.9297f, 1134.0607f, 26.0766f);
                Angle = 326.0f;
                CameraPosition = new Vector3(-2801.6691f, 1151.7545f, 31.5482f);
                SetCameraLookAt(new Vector3(-2819.05078f, 1141.4909f, 23.3147f));
                PlaySound(1062, new Vector3(-2818.0f, 1100.0f, 0.0f));
            });
        }

        public override void OnDisconnected(DisconnectEventArgs e)
        {
            base.OnDisconnected(e);
        }

        public override void OnRequestClass(RequestClassEventArgs e)
        {
            base.OnRequestClass(e);

            ApplyAnimation("ON_LOOKERS", "wave_loop", 3.5f, true, false, false, false, 0, false);
            SendInfoMessage("OnRequestClass");
        }

        public override void OnRequestSpawn(RequestSpawnEventArgs e)
        {
            base.OnRequestSpawn(e);

            SendInfoMessage("OnRequestSpawn");
        }

        public override void OnSpawned(SpawnEventArgs e)
        {
            base.OnSpawned(e);

            SendInfoMessage("OnSpawned");
        }

        public override void OnUpdate(PlayerUpdateEventArgs e)
        {
            base.OnUpdate(e);
        }

        public override void OnText(TextEventArgs e)
        {
            base.OnText(e);
        }

        public override void OnStateChanged(StateEventArgs e)
        {
            base.OnStateChanged(e);

            SendInfoMessage("OnStateChanged");
        }

        public override void OnDeath(DeathEventArgs e)
        {
            base.OnDeath(e);

            SendInfoMessage("OnDeath");
        }

        public override void OnDialogResponse(DialogResponseEventArgs e)
        {
            base.OnDialogResponse(e);
        }

        public override void OnEnterVehicle(EnterVehicleEventArgs e)
        {
            base.OnEnterVehicle(e);

            SendInfoMessage("OnEnterVehicle");
        }

        public override void OnExitVehicle(PlayerVehicleEventArgs e)
        {
            base.OnExitVehicle(e);

            SendInfoMessage("OnExitVehicle");
        }

        public override void OnEnterCheckpoint(EventArgs e)
        {
            base.OnEnterCheckpoint(e);

            SendInfoMessage("OnEnterCheckpoint");
        }

        public override void OnLeaveCheckpoint(EventArgs e)
        {
            base.OnLeaveCheckpoint(e);

            SendInfoMessage("OnLeaveCheckpoint");
        }

        public override void OnEnterRaceCheckpoint(EventArgs e)
        {
            base.OnEnterRaceCheckpoint(e);

            SendInfoMessage("OnEnterRaceCheckpoint");
        }

        public override void OnLeaveRaceCheckpoint(EventArgs e)
        {
            base.OnLeaveRaceCheckpoint(e);

            SendInfoMessage("OnLeaveRaceCheckpoint");
        }

        public override void OnEnterExitModShop(EnterModShopEventArgs e)
        {
            base.OnEnterExitModShop(e);

            SendInfoMessage("OnEnterExitModShop");
        }

        public override void OnSelectedMenuRow(MenuRowEventArgs e)
        {
            base.OnSelectedMenuRow(e);

            SendInfoMessage("OnSelectedMenuRow");
        }

        public override void OnExitedMenu(EventArgs e)
        {
            base.OnExitedMenu(e);

            SendInfoMessage("OnExitedMenu");
        }

        public override void OnClickPlayer(ClickPlayerEventArgs e)
        {
            base.OnClickPlayer(e);

            SendInfoMessage("OnClickPlayer");
        }

        public override void OnClickMap(PositionEventArgs e)
        {
            base.OnClickMap(e);

            SendInfoMessage("OnSpawned");
        }

        public override void OnKeyStateChanged(KeyStateChangedEventArgs e)
        {
            base.OnKeyStateChanged(e);
        }

        public override void OnInteriorChanged(InteriorChangedEventArgs e)
        {
            base.OnInteriorChanged(e);
        }

        public override void OnStreamIn(PlayerEventArgs e)
        {
            base.OnStreamIn(e);
        }

        public override void OnStreamOut(PlayerEventArgs e)
        {
            base.OnStreamOut(e);
        }

        public override void Ban()
        {
            Delay.Run(100, base.Ban);
        }

        public override void Kick()
        {
            Delay.Run(100, base.Kick);
        }

        #endregion Overrided

        #region Utils
        private bool IsNickCorrect()
        {
            return Regex.IsMatch(Name, "^[A-Z]{1}[a-z]{1,}(_[A-Z]{1}[a-z]{1,}([A-HJ-Z]{1}[a-z]{1,})?){1,2}$");
        }

        private void ClearChat()
        {
            for (int i = 0; i < 200; i++)
            {
                SendClientMessage(" ");
            }
        }
        #endregion Utils

        #region Messages
        //Error
        public virtual void SendErrorMessage(string message)
        {
            SendClientMessage(Colors.Error, "[ERROR] {C00010}" + message);
        }
        public virtual void SendErrorMessage(string messageFormat, params object[] args)
        {
            SendClientMessage(Colors.Error, "[ERROR] {C00010} " + string.Format(messageFormat, args));
        }

        //Fail
        public virtual void SendFailureMessage(string message)
        {
            SendClientMessage(Colors.Failure, message);
        }
        public virtual void SendFailureMessage(string messageFormat, params object[] args)
        {
            SendClientMessage(Colors.Failure, string.Format(messageFormat, args));
        }

        //Warning
        public virtual void SendWarningMessage(string message)
        {
            SendClientMessage(Colors.Warning, message);
        }
        public virtual void SendWarningMessage(string messageFormat, params object[] args)
        {
            SendClientMessage(Colors.Warning, string.Format(messageFormat, args));
        }

        //Info
        public virtual void SendInfoMessage(string message)
        {
            SendClientMessage(Colors.Info, message);
        }
        public virtual void SendInfoMessage(string messageFormat, params object[] args)
        {
            SendClientMessage(Colors.Info, string.Format(messageFormat, args));
        }

        //Good info
        public virtual void SendGoodInfoMessage(string message)
        {
            SendClientMessage(Colors.GoodInfo, message);
        }
        public virtual void SendGoodInfoMessage(string messageFormat, params object[] args)
        {
            SendClientMessage(Colors.GoodInfo, string.Format(messageFormat, args));
        }

        //Bad info
        public virtual void SendBadInfoMessage(string message)
        {
            SendClientMessage(Colors.BadInfo, message);
        }
        public virtual void SendBadInfoMessage(string messageFormat, params object[] args)
        {
            SendClientMessage(Colors.BadInfo, string.Format(messageFormat, args));
        }

        //Offer
        public virtual void SendOfferMessage(string message)
        {
            SendClientMessage(Colors.Offer, message);
        }
        public virtual void SendOfferMessage(string messageFormat, params object[] args)
        {
            SendClientMessage(Colors.Offer, string.Format(messageFormat, args));
        }

        //Punishment
        public virtual void SendPunishmentMessage(string message)
        {
            SendClientMessage(Colors.Punishment, message);
        }
        public virtual void SendPunishmentMessage(string messageFormat, params object[] args)
        {
            SendClientMessage(Colors.Punishment, string.Format(messageFormat, args));
        }

        //Command help
        public virtual void SendCommandHelpMessage(string message)
        {
            SendClientMessage(Colors.CommandHelp, message);
        }
        public virtual void SendCommandHelpMessage(string messageFormat, params object[] args)
        {
            SendClientMessage(Colors.CommandHelp, string.Format(messageFormat, args));
        }

        //Command help
        public virtual void SendCommandInfoMessage(string message)
        {
            SendClientMessage(Colors.CommandInfo, message);
        }
        public virtual void SendCommandInfoMessage(string messageFormat, params object[] args)
        {
            SendClientMessage(Colors.CommandInfo, string.Format(messageFormat, args));
        }

        #endregion Messages

    }
}