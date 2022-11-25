using Garage1._0.UserInterface;
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
        
        
        public void CreateGarage(int capacity)
        {
            Garage<Vehicle> garage = new Garage<Vehicle>(capacity);
            this.garage = garage;            
        }

        internal void ParkAirplane(string color, int noOfWheels, string regNo,int numberOfEngines)
        {
            AirPlane airplane = new AirPlane(color, noOfWheels, regNo, numberOfEngines);
            garage.Add(airplane);         
           
        }

      
    }
}
