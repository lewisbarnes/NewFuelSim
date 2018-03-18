using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFuelSim
{
    public class Pump
    {
        private int _num;
        private double _fillLevel = 32000;
        private Vehicle _assignedVehicle;

        // Check to see if a vehicle has been assigned to the pump
        public bool IsAssigned
        {
            get
            {
                if (_assignedVehicle != null) return true;
                {
                    return false;
                }
            }
        }
        public Pump(int num)
        {
            _num = num;
        }

        // Give fuel to the vehicle that has been assigned to the pump
        public void TakeFuel()
        {
            if(_assignedVehicle != null)
            {
                if (!_assignedVehicle.IsFilled)
                {
                    _fillLevel -= _assignedVehicle.FuellingRate;
                    _assignedVehicle.GiveFuel(_assignedVehicle.FuellingRate);
                }
                else
                {
                    _assignedVehicle.Complete();
                    _assignedVehicle = null;
                }
            }
        }

        // Assign a vehicle to the pump
        public void AssignVehicle(Vehicle vehicle)
        {
            _assignedVehicle = vehicle;
        }

        public override string ToString()
        {
            return $" [#{_num.ToString("D3")}#]";
        }
        public string AssignedString()
        {
            if (_assignedVehicle != null)
            {
                return _assignedVehicle.ToString();
            }
            else
            {
                return " -------";
            }
        }
    }
}
