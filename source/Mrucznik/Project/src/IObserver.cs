using System;
using Mrucznik.Items;
using SampSharp.GameMode;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.World;
using SampSharp.Streamer.World;

namespace Mrucznik
{
    interface IObserver
    {
        void Update(IObservable sender);
    }

    interface IObservable
    {
        void InformObservers();
    }

    public abstract class WorldExposion //or Physic Exposion
    {
    }

    class ObjectExposion : IObserver
    {
        private GlobalObject _object;
        private int _model;

        public ObjectExposion(int model, Vector3 position, Vector3 rotation)
        {
            _model = model;
            _object = new GlobalObject(model, position, rotation);
        }

        public void Update(IObservable o)
        {
            var item = o as Item;
            if (item != null)
            {
                _object.Position = item.Position;
                _object.Rotation = item.Rotation;
            }

        }
    }

    class OnPlayerExposion : IObserver
    {
        private DynamicObject _object;
        private int _model;

        public OnPlayerExposion(int model, Vector3 position, Vector3 rotation, BasePlayer player)
        {
            _model = model;
            _object = new DynamicObject(model, position, rotation);
        }

        public void Update(IObservable sender)
        {
            throw new NotImplementedException();
        }
    }

    class OnVehicleExposion : IObserver
    {
        private DynamicObject _object;
        private int _model;

        public OnVehicleExposion(int model, Vector3 position, Vector3 rotation, BaseVehicle vehicle)
        {
            _model = model;
            _object = new DynamicObject(model, default(Vector3));
            _object.AttachTo(vehicle, position, rotation);
        }

        public void Update(IObservable sender)
        {
            throw new NotImplementedException();
        }
    }

    class OnObjectExposion : IObserver
    {
        public void Expose()
        {
            throw new NotImplementedException();
        }

        public void UnExpose()
        {
            throw new NotImplementedException();
        }

        public void Update(IObservable sender)
        {
            throw new NotImplementedException();
        }
    }


    class TextLabelExposion : IObserver
    {
        private TextLabel _textLabel;
        private readonly float _drawDistance;

        //Constructors
        public TextLabelExposion(string text, Color color, Vector3 position = default(Vector3), float drawDistance = 200.0f,
            bool testLOS = false)
        {
            _textLabel = new TextLabel(text, color, position, drawDistance, 0, testLOS);
            _drawDistance = drawDistance;
        }

        //Methods
        public void Update(IObservable sender)
        {
            var item = sender as Item;
            if (item != null)
                _textLabel.Position = item.Position;
        }
    }

    class DebugExposion : IObserver
    {
        public void Update(IObservable sender)
        {
            throw new NotImplementedException();
        }
    }

    class PickupExposion : IObserver
    {
        public void Expose()
        {
            throw new NotImplementedException();
        }

        public void UnExpose()
        {
            throw new NotImplementedException();
        }

        public void Update(IObservable sender)
        {
            throw new NotImplementedException();
        }
    }

    class CheckpointExposion : IObserver
    {
        public void Expose()
        {
            throw new NotImplementedException();
        }

        public void UnExpose()
        {
            throw new NotImplementedException();
        }

        public void Update(IObservable sender)
        {
            throw new NotImplementedException();
        }
    }
}
