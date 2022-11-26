using Garage1._0.UserInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Garage1._0
{
    public class GarageHandler
    {        
       public Garage<Vehicle> garage;
        
        
        public void CreateGarage(int capacity)
        {
            Garage<Vehicle> garage = new Garage<Vehicle>(capacity);
            this.garage = garage;            
        }

        internal bool CheckIfEmptyGarage()
        {
            if (garage.NoOfVehiclesParked == 0)
                return true;
            return false;
        }

        internal bool CheckIfFullGarage()
        {
            if (garage.IsFull== true) return true;
            return false;
        }

       
        internal Garage<Vehicle> ListAllVehiclesInGarage()
        {
            //foreach (Vehicle item in garage)
            //{
            //    Console.WriteLine(item);
            //}
            return garage; ;
        }

        internal void PrintVehicles()
        {
            foreach (Vehicle item in garage)
            {
                //Console.WriteLine(item.ToString());
                //Console.WriteLine($"{item.GetType().Name}  {item.ToString()}");
            }
        }

        internal string PrintVehicles2()
        {
            string result = "";
            foreach (Vehicle item in garage)
            {
              result+=($"{item.GetType().Name}  {item.ToString()}\n");
            }
            return result;
        }

        //public string ListType()
        //{
        //    string result = "";
        //    var type = garage.Where(x => x != null).Select(x => x.GetType().Name);
        //    foreach (var v in type)
        //    {
        //        result += v + "|";
        //    }
        //    return result;
        //}


        internal IEnumerable<Vehicle> SortByProperty(string color)
        {

            var q = garage.Where(v => v?.Color == color);
            q = q.OrderBy(v => v.NoOfWheels);

            return q;
           
        }
        internal IEnumerable<Vehicle> SortByColor(string color)
        {

            var q = garage.Where(v => v?.Color == color);           

            return q;

        }

        internal IEnumerable<Vehicle> SortByNoOfWheels()
        {
           
            var q = garage.OrderBy(v => v.NoOfWheels);
            return q;
        }



        internal bool ParkAirplane(string color, int noOfWheels, string regNo, int numberOfEngines)
        {
            AirPlane airplane = new AirPlane(color, noOfWheels, regNo, numberOfEngines);
            if (garage.Add(airplane) == true)
                return true;
            else return false;
        }


        internal bool ParkCar(string color, int noOfWheels, string regNo, string fuelType)
        {
            Car car = new Car(color, noOfWheels, regNo, fuelType);
            if (garage.Add(car) == true)
                return true;
            else return false;
        }

        internal bool ParkMotorcycle(string color, int noOfWheels, string regNo, int cylinderVolume)
        {
           Motorcycle motorcycle= new Motorcycle(color, noOfWheels, regNo, cylinderVolume);
            if (garage.Add(motorcycle) == true)
                return true;
            else return false;
        }

        internal bool ParkBus(string color, int noOfWheels, string regNo, int noOfSeats)
        {
            Bus bus=new Bus(color, noOfWheels, regNo, noOfSeats);
            if (garage.Add(bus) == true)
                return true;
            else return false;
        }

        internal bool ParkBoat(string color, int noOfWheels, string regNo, int length)
        {
            Boat boat=new Boat(color, noOfWheels, regNo, length);
            if (garage.Add(boat) == true)
                return true;
            else return false;
        }
        internal void SeedData()
        {           
            AirPlane airplane = new AirPlane(color: "grey", noOfWheels: 3, regNo: "Sky123", numberOfEngines: 2);
            garage.Add(airplane);
            Motorcycle motorcycle = new Motorcycle(color: "black", noOfWheels: 2, regNo: "ACC900", cylinderVolume: 1000);
            garage.Add(motorcycle);
            Boat boat = new Boat(color: "white", noOfWheels: 0, regNo: "Sea111", length: 1);
            garage.Add(boat);
            AirPlane airplane2 = new AirPlane(color: "grey", noOfWheels: 3, regNo: "Sky222", numberOfEngines: 2);
            garage.Add(airplane2);
            Motorcycle motorcycle2 = new Motorcycle(color: "yellow", noOfWheels: 2, regNo: "ACC800", cylinderVolume: 850);
            garage.Add(motorcycle2);
        }
    }
}
