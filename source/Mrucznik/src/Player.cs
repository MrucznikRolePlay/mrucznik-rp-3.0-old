using System;
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

            Console.WriteLine(Name + " is connected.");

            SendClientMessage("Welcome to {88AA88}M{FFFFFF}rucznik {88AA88}R{FFFFFF}ole{88AA88}P{FFFFFF}lay");
            GameText("~w~Mrucznik Role Play", 4000, 4);
        }
    }
}