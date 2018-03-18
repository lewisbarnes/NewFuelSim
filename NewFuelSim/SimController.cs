using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace NewFuelSim
{

    public class SimController
    {
        private List<Pump> _pumps = new List<Pump>();
        private VehicleFactory _vf;
        private string[] types = { "car","van","truck" };
        private Random _rand;
        private int _processedVehicles = 0;

        // Create a simcontroller with x pumps where x % 3 = 0
        public SimController(int pumpnum)
        {
            // Add 9 pumps to the pumps list
            for(int i=1; i < pumpnum+1; i++)
            {
                _pumps.Add(new Pump(i));
            }
            _rand = new Random();
            _vf = new VehicleFactory();
        }

        // Start the main loop of the simulation
        public void StartLoop()
        {
            var updateTimer = new Timer(250);
            var vehicleTimer = new Timer(250);
            var fuelTimer = new Timer(100);
            updateTimer.Elapsed += UpdateConsole;
            vehicleTimer.Elapsed += CreateVehicle;
            fuelTimer.Elapsed += FuelUp;
            updateTimer.Enabled = true;
            vehicleTimer.Enabled = true;
            fuelTimer.Enabled = true;
        }
        
        // Update the display on the console to reflect the simulation
        public void UpdateConsole(object s, EventArgs e)
        {
            Console.Clear();
            for (int i = 0; i < _pumps.Count; i += 3)
            {
                Console.WriteLine(String.Format("{0}{1}{2}\n{3}{4}{5}", _pumps[i], _pumps[i + 1], _pumps[i + 2], _pumps[i].AssignedString(), _pumps[i + 1].AssignedString(), _pumps[i + 2].AssignedString()));
            }
            Console.WriteLine($"Vehicles Processed: {_processedVehicles}");
        }

        // Create a pseudo-random vehicle every x milliseconds
        public void CreateVehicle(object s, EventArgs e)
        {
            var vrand = _rand.Next(3);
            var v = _vf.Create(types[vrand]);
            if(v.LookForPump(_pumps))
            {
                _processedVehicles++;
            }
        }

        public void FuelUp(object s, EventArgs e)
        {
            foreach (Pump p in _pumps)
            {
                p.TakeFuel();
            }
        }
    }
}
