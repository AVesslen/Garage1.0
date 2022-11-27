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
            if (garage.IsFull == true) return true;
            else
                return false;
        }


        internal string ListAllVehiclesInGarage()
        {
            string result = "";
            int i = 1;
            foreach (Vehicle item in garage)
            {
                result += ($"{i}. {item.ToString()}\n");
                i++;
            }
            return result;
        }


        internal string GetNoOfEachType()  // Groups vehicles by type and count no of each type 
        {
            string result = "";
            var vehicleTypeList = garage.GroupBy(v => v.GetType().Name).Select(v => new
            {
                type = v.Key,
                count = v.Count()
            }).ToList();


            foreach (var v in vehicleTypeList)
            {
                result += $"{v.type}: {v.count}\n";
            }
            return result;
        }

        internal string FindVehicleByRegNo(string inputRegNo)
        {
            string result = "";
            var q = garage.Where(v => v?.RegNo.ToUpper() == inputRegNo.ToUpper());

            if (q.Count() == 0)
                result = $"Sorry, could not find a vehicle with reg.no {inputRegNo}";

            else
            {
                result = $"Here is the vehicle with reg.no {inputRegNo}:\n";
                foreach (var v in q)
                {
                    result += $"{v.ToString()};";
                }
            }
            return result;
        }


        internal bool CheckRegNoBeforeAdding(string inputRegNo)
        {
            bool isExisting;

            var q = garage.Where(v => v?.RegNo.ToUpper() == inputRegNo.ToUpper());
            if (q.Count() == 0)    
                isExisting = false;   // The reg.no is not defined at any of the vehicles
            else isExisting = true;

            return isExisting;
        }



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
            Airplane airplane = new Airplane(color, noOfWheels, regNo, numberOfEngines);
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
            Airplane airplane = new Airplane(color: "grey", noOfWheels: 3, regNo: "Sky123", numberOfEngines: 2);
            garage.Add(airplane);
            Motorcycle motorcycle = new Motorcycle(color: "black", noOfWheels: 2, regNo: "ACC900", cylinderVolume: 1000);
            garage.Add(motorcycle);
            Boat boat = new Boat(color: "white", noOfWheels: 0, regNo: "Sea111", length: 1);
            garage.Add(boat);
            Airplane airplane2 = new Airplane(color: "grey", noOfWheels: 3, regNo: "Sky222", numberOfEngines: 2);
            Bus bus = new Bus(color: "green", noOfWheels: 4, regNo: "BUS001", numberOfSeats: 40);
            garage.Add(bus);
            garage.Add(airplane2);
            Motorcycle motorcycle2 = new Motorcycle(color: "yellow", noOfWheels: 2, regNo: "ACC800", cylinderVolume: 850);
            garage.Add(motorcycle2);
            Car car = new Car(color: "red", noOfWheels: 4, regNo: "CAR001", fuelType: "gasoline");
            garage.Add(car);
            Bus bus2 = new Bus(color: "green", noOfWheels: 4, regNo: "BUS002", numberOfSeats: 50);
            garage.Add(bus2);
        }

    }
}
