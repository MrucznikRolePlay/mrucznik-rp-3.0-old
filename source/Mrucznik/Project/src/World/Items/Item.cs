using System.Collections.Generic;
using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.SAMP;

namespace Mrucznik.Items
{
    abstract class Item : IObservable
    {
        //--- Fields ---
        protected List<IObserver> Observers;

        private Vector3 _position;
        private Vector3 _rotation;
        protected string Name;

        public Vector3 Position
        {
            get { return _position; }
            set { SetPosition(value); }
        }

        public Vector3 Rotation
        {
            get { return _rotation; }
            set { SetRotation(value); }
        }

        //--- Constructors ---
        protected Item()
        {
            _position = default(Vector3);
            _rotation = default(Vector3);
            Name = "Brak";
            Observers = new List<IObserver>();
        }

        //--- Methods ---
        public void AddListener(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void RemoveListener(IObserver observer)
        {
            Observers.Remove(observer);
        }

        private void SetPosition(Vector3 position)
        {
            _position = position;
            InformObservers();
        }

        private void SetRotation(Vector3 rotation)
        {
            _rotation = rotation;
            InformObservers();
        }

        public void InformObservers()
        {
            foreach (IObserver observer in Observers)
            {
                observer.Update(this);
            }
        }
    }

    class GunItem : Item
    {
        //--- Fields
        private Weapon gun;
        private int ammo;

        //--- Constructors ---
        public GunItem(Weapon gun, int ammo = 0)
        {
            this.gun = gun;
            this.ammo = ammo;
            Name = gun.ToString();
            AddListener(new ObjectExposion(356, Position, Rotation));
            AddListener(new TextLabelExposion(gun.ToString(), Color.Red));
        }

        //--- Methods ---
    }

    class MoneyItem : Item
    {
        private int ammount;

        public MoneyItem(int ammount)
        {
            this.ammount = ammount;
            Observers.Add(new PickupExposion());
        }
    }
}
