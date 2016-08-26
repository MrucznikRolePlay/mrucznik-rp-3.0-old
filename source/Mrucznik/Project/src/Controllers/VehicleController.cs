using Mrucznik.World;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.World;

namespace Mrucznik.Controllers
{
    class VehicleController : BaseVehicleController
    {
        public override void RegisterTypes()
        {
            Vehicle.Register<Vehicle>();
        }
    }
}
