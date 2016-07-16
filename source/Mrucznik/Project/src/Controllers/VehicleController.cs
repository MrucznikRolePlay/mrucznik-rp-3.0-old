using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.World;

namespace Mrucznik.Controllers
{
    class VehicleController : GtaVehicleController
    {
        public override void RegisterTypes()
        {
            Vehicle.Register<Vehicle>();
        }
    }
}
