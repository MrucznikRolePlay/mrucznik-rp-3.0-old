using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;

namespace Mrucznik
{
    class Vehicle : GtaVehicle
    {
        public Vehicle(int id) : base(id)
        {
        }

        #region Overrided

        public override void OnDeath(PlayerEventArgs e)
        {
            base.OnDeath(e);
        }

        public override void OnStreamIn(PlayerEventArgs e)
        {
            base.OnStreamIn(e);
        }

        public override void OnStreamOut(PlayerEventArgs e)
        {
            base.OnStreamOut(e);
        }

        public override void OnDamageStatusUpdated(PlayerEventArgs e)
        {
            base.OnDamageStatusUpdated(e);
        }

        public override void OnMod(VehicleModEventArgs e)
        {
            base.OnMod(e);
        }

        public override void OnPaintjobApplied(VehiclePaintjobEventArgs e)
        {
            base.OnPaintjobApplied(e);
        }

        public override void OnPlayerEnter(EnterVehicleEventArgs e)
        {
            base.OnPlayerEnter(e);
        }

        public override void OnPlayerExit(PlayerVehicleEventArgs e)
        {
            base.OnPlayerExit(e);
        }

        public override void OnResprayed(VehicleResprayedEventArgs e)
        {
            base.OnResprayed(e);
        }

        public override void OnSirenStateChanged(SirenStateEventArgs args)
        {
            base.OnSirenStateChanged(args);
        }

        public override void OnSpawn(EventArgs e)
        {
            base.OnSpawn(e);
        }

        public override void OnTrailerUpdate(TrailerEventArgs args)
        {
            base.OnTrailerUpdate(args);
        }

        public override void OnUnoccupiedUpdate(UnoccupiedVehicleEventArgs e)
        {
            base.OnUnoccupiedUpdate(e);
        }

        #endregion Overrided
    }
}
