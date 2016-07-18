using System;
using System.Text.RegularExpressions;
using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
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
                SendBadInfoMessage("Twój nick jest niepoprawny! Musisz posiadać nick zgodny z Listą Kar i Zasad (znajdziesz ją na naszym forum na stronie www.Mrucznik-RP.pl).");
                SendBadInfoMessage("Poprawny nick powinien być zgodny z formatem: Imię_Nazwisko lub Imię_Nazwisko_Nazwisko. Nazwisko może zawierać przedrostki (De, La) np. DiCaprio");
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
        }

        public override void OnSpawned(SpawnEventArgs e)
        {
            base.OnSpawned(e);
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
        }

        public override void OnDeath(DeathEventArgs e)
        {
            base.OnDeath(e);
        }

        public override void OnDialogResponse(DialogResponseEventArgs e)
        {
            base.OnDialogResponse(e);
        }

        public override void OnEnterVehicle(EnterVehicleEventArgs e)
        {
            base.OnEnterVehicle(e);
        }

        public override void OnExitVehicle(PlayerVehicleEventArgs e)
        {
            base.OnExitVehicle(e);
        }

        public override void OnEnterCheckpoint(EventArgs e)
        {
            base.OnEnterCheckpoint(e);
        }

        public override void OnLeaveCheckpoint(EventArgs e)
        {
            base.OnLeaveCheckpoint(e);
        }

        public override void OnEnterRaceCheckpoint(EventArgs e)
        {
            base.OnEnterRaceCheckpoint(e);
        }

        public override void OnLeaveRaceCheckpoint(EventArgs e)
        {
            base.OnLeaveRaceCheckpoint(e);
        }

        public override void OnEnterExitModShop(EnterModShopEventArgs e)
        {
            base.OnEnterExitModShop(e);
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
        }

        public override void OnClickMap(PositionEventArgs e)
        {
            base.OnClickMap(e);
        }

        public override void OnKeyStateChanged(KeyStateChangedEventArgs e)
        {
            base.OnKeyStateChanged(e);

            if (e.NewKeys == Keys.Yes)
            {
                if (State == PlayerState.Driving)
                {
                    Vehicle.Engine = true;
                    MeMessage("odpala silnik.");
                }
            }
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

        public override void OnClickTextDraw(ClickTextDrawEventArgs e)
        {
            base.OnClickTextDraw(e);
        }

        public override void OnClickPlayerTextDraw(ClickPlayerTextDrawEventArgs e)
        {
            base.OnClickPlayerTextDraw(e);
        }

        public override void OnCancelClickTextDraw(EventArgs e)
        {
            base.OnCancelClickTextDraw(e);
        }

        public override void OnSelectGlobalObject(SelectGlobalObjectEventArgs e)
        {
            base.OnSelectGlobalObject(e);
        }

        public override void OnSelectPlayerObject(SelectPlayerObjectEventArgs e)
        {
            base.OnSelectPlayerObject(e);
        }

        public override void OnEditGlobalObject(EditGlobalObjectEventArgs e)
        {
            base.OnEditGlobalObject(e);
        }

        public override void OnEditPlayerObject(EditPlayerObjectEventArgs e)
        {
            base.OnEditPlayerObject(e);
        }

        public override void OnEditAttachedObject(EditAttachedObjectEventArgs e)
        {
            base.OnEditAttachedObject(e);
        }

        public override void OnWeaponShot(WeaponShotEventArgs e)
        {
            base.OnWeaponShot(e);
        }

        public override void OnTakeDamage(DamageEventArgs e)
        {
            base.OnTakeDamage(e);
        }

        public override void OnGiveDamage(DamageEventArgs e)
        {
            base.OnGiveDamage(e);
        }

        public override void OnCleanup(DisconnectEventArgs e)
        {
            base.OnCleanup(e);
        }

        public override void OnCommandText(CommandTextEventArgs e)
        {
            base.OnCommandText(e);

            if (!e.Success)
            {
                SendCommandFeedbackMessage("Nieprawidłowa komenda! Wpisz /komendy aby zobaczyć listę komend.");
                return;
            }
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
        /// <summary>
        /// 
        /// </summary>
        public virtual void SendErrorMessage(string message)
        {
            SendClientMessage(Colors.Error, "[ERROR] {C00010}" + message);
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual void SendErrorMessage(string messageFormat, params object[] args)
        {
            SendClientMessage(Colors.Error, "[ERROR] {C00010} " + string.Format(messageFormat, args));
        }

        //Warning
        /// <summary>
        /// Używać do komunikowania upływu czasu, ktoś dał /q itd.
        /// </summary>
        public virtual void SendWarningMessage(string message)
        {
            SendClientMessage(Colors.Warning, message);
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual void SendWarningMessage(string messageFormat, params object[] args)
        {
            SendClientMessage(Colors.Warning, string.Format(messageFormat, args));
        }

        //Info
        /// <summary>
        /// Używać do komunikowania informacji
        /// </summary>
        public virtual void SendInfoMessage(string message)
        {
            SendClientMessage(Colors.Info, message);
        }
        /// <summary>
        /// Używać do komunikowania informacji
        /// </summary>
        public virtual void SendInfoMessage(string messageFormat, params object[] args)
        {
            SendClientMessage(Colors.Info, string.Format(messageFormat, args));
        }

        //Good info
        /// <summary>
        /// Używać do komunikowania pozytywnych informacji
        /// </summary>
        public virtual void SendGoodInfoMessage(string message)
        {
            SendClientMessage(Colors.GoodInfo, message);
        }
        /// <summary>
        /// Używać do komunikowania pozytywnych informacji
        /// </summary>
        public virtual void SendGoodInfoMessage(string messageFormat, params object[] args)
        {
            SendClientMessage(Colors.GoodInfo, string.Format(messageFormat, args));
        }

        //Bad info
        /// <summary>
        /// Używać do komunikowania negatywnych informacji
        /// </summary>
        public virtual void SendBadInfoMessage(string message)
        {
            SendClientMessage(Colors.BadInfo, message);
        }
        /// <summary>
        /// Używać do komunikowania negatywnych informacji
        /// </summary>
        public virtual void SendBadInfoMessage(string messageFormat, params object[] args)
        {
            SendClientMessage(Colors.BadInfo, string.Format(messageFormat, args));
        }

        //Offer
        /// <summary>
        /// Używać do wyświetlania ofert
        /// </summary>
        public virtual void SendOfferMessage(string message)
        {
            SendClientMessage(Colors.Offer, message);
        }
        /// <summary>
        /// Używać do wyświetlania ofert
        /// </summary>
        public virtual void SendOfferMessage(string messageFormat, params object[] args)
        {
            SendClientMessage(Colors.Offer, string.Format(messageFormat, args));
        }

        //Punishment
        /// <summary>
        /// Używać do wyświetlania kar
        /// </summary>
        public virtual void SendPunishmentMessage(string message)
        {
            SendClientMessage(Colors.Punishment, message);
        }
        /// <summary>
        /// Używać do wyświetlania kar
        /// </summary>
        public virtual void SendPunishmentMessage(string messageFormat, params object[] args)
        {
            SendClientMessage(Colors.Punishment, string.Format(messageFormat, args));
        }

        //Command help
        /// <summary>
        /// Używać do wyświetlania wiadomości zwrotnych komendy (takie, które przerywają jej wykonanie)
        /// </summary>
        public virtual void SendCommandFeedbackMessage(string message)
        {
            SendClientMessage(Colors.CommandFeedback, message);
        }
        /// <summary>
        /// Używać do wyświetlania wiadomości zwrotnych komendy (takie, które przerywają jej wykonanie)
        /// </summary>
        public virtual void SendCommandFeedbackMessage(string messageFormat, params object[] args)
        {
            SendClientMessage(Colors.CommandFeedback, string.Format(messageFormat, args));
        }

        //Me message
        public virtual void MeMessage(string message)
        {
            SendClientMessage(Colors.Me, "* {0} {1}", Name, message);
            SetChatBubble($"* {message} *", Colors.Me, 25.0f, 30);
        }

        public virtual void MeMessage(string messageFormat, params object[] args)
        {
            SendClientMessage(Colors.Me, string.Format(messageFormat, args));
        }

        //Do message
        public virtual void DoMessage(string message)
        {
            SendClientMessage(Colors.Do, "* {0} (({1}))", message, Name);
            SetChatBubble($"** {message} **", Colors.Me, 25.0f, 30);
        }

        public virtual void DoMessage(string messageFormat, params object[] args)
        {
            SendClientMessage(Colors.Do, string.Format(messageFormat, args));
        }

        #endregion Messages

    }
}