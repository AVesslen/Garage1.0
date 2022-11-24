using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1._0
{
    internal class GarageHandler
    {        
        private Garage<Vehicle> garage;
       
        internal void CreateGarage(int capacity)
        {
            Garage<Vehicle> garage = new Garage<Vehicle>(capacity);
        }

        internal void ParkVehicle()
        {
            throw new NotImplementedException();
        }
    }
}
