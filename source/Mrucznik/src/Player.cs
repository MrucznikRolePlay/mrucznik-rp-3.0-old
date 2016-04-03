using System;
using System.Text.RegularExpressions;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.World;

namespace Mrucznik
{
    public class Player : GtaPlayer
    {
        public Player(int id) : base(id)
        {
        }

        public override void OnConnected(EventArgs e)
        {
            base.OnConnected(e);

            ClearChat();
            SendClientMessage(Color.White, "SERVER: Witaj {0}", Name);
            
            if (!IsNickCorrect())
            {
                SendClientMessage(Color.White, "Nick {0} jest niepoprawny!", Name);
                Delay.Run(100, Kick);
                SendClientMessage(Color.White, "Zostałeś skickowany!", Name);
                return;
            }
        }

        public override void OnSpawned(SpawnEventArgs e)
        {
            base.OnSpawned(e);

            SendClientMessage(Color.AliceBlue, "Elo");
        }

        #region Utils

        private bool IsNickCorrect()
        {
            string kox = Name;
            return Regex.IsMatch(kox, "^[A-Z]{1}[a-z]{1,}(_[A-Z]{1}[a-z]{1,}([A-HJ-Z]{1}[a-z]{1,})?){1,2}$");
        }

        private void ClearChat()
        {
            for (int i = 0; i < 200; i++)
            {
                SendClientMessage(Color.Red, " ");
            }
        }
        #endregion

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

        #endregion
        
    }
}