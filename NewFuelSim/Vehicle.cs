using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NewFuelSim
{
    public abstract class Vehicle : IDisposable
    {
        protected double _fillLevel;
        protected double _fillRate;
        protected double _tankCapacity;
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                handle.Dispose();
                disposed = true;
            }
        }
        public Vehicle()
        {
        }

        public double FuellingRate
        {
            get
            {
                return _fillRate;
            }
        }

        public void GiveFuel(double amount)
        {
            _fillLevel += amount;
        }

        public bool IsFilled
        {
            get
            {
                if (_fillLevel >= _tankCapacity)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public void Complete()
        {
            this.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
        }
        public bool LookForPump(List<Pump> pumps)
        {
            foreach(Pump p in pumps)
            {
                if(!p.IsAssigned)
                {
                    p.AssignVehicle(this);
                    p.TakeFuel();
                    return true;
                }
            }
            Complete();
            return false;
        }
    }
    public class Car : Vehicle
    {
        public Car()
        {
            _fillLevel = 0;
            _fillRate = 0.78;
            _tankCapacity = 50;
        }

        public override string ToString()
        {
            return " [--C--]";
        }
    }

    public class Van : Vehicle
    {
        public Van()
        {
            _fillLevel = 0;
            _fillRate = 0.68;
            _tankCapacity = 75;
        }
        public override string ToString()
        {
            return " [--V--]";
        }
    }

    public class Truck : Vehicle
    {
        public Truck()
        {
            _fillLevel = 0;
            _fillRate = 2.7;
            _tankCapacity = 240;
        }

        public override string ToString()
        {
            return " [--T--]";
        }
    }
}
