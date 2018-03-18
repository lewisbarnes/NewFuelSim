using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFuelSim
{
    public class VehicleFactory
    {
        public VehicleFactory()
        {

        }

        // Create a vehicle based on string passed
        public Vehicle Create(string type)
        {
            switch(type)
            {
                case "car":
                    return new Car();
                case "van":
                    return new Van();
                case "truck":
                    return new Truck();
                default:
                    return null;
            }
        }
    }
}
