using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1._0
{
    public class GarageHandler
    {        
        private Garage<Vehicle> garage;
        public GarageHandler()
        {

        }
       
        public void CreateGarage(int capacity)
        {
            Garage<Vehicle> garage = new Garage<Vehicle>(capacity);
        }

        internal bool ParkAirplane(string color, int noOfWheels, string regNo,int numberOfEngines)
        {
            AirPlane airplane = new AirPlane(color, noOfWheels, regNo, numberOfEngines);
           if (garage.Add(airplane))
                return true;
           return false;
        }

        //internal void garage.Add(Vehicle vehicle);
        //{
        //    throw new NotImplementedException();
        //}
    }
}
