using Mrucznik.World;
using SampSharp.GameMode.Controllers;

namespace Mrucznik.Controllers
{
    public class PlayerController : GtaPlayerController
    {
        public override void RegisterTypes()
        {
            Player.Register<Player>();
        }
    }
}
