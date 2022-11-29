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
    public class GarageHandler : IHandler
    {
        public Garage<Vehicle> garage = null!;

        public GarageHandler()
        {

        }

        public void CreateGarage(int capacity)
        {
            Garage<Vehicle> garage = new Garage<Vehicle>(capacity);
            this.garage = garage;
        }

        public int GetNoOfVehiclesParked()
        {
            int amount = garage.NoOfVehiclesParked;
            return amount;
        }

        public bool CheckIfEmptyGarage()
        {          
            return (garage.NoOfVehiclesParked==0)? true:false;
        }

        public bool CheckIfFullGarage()
        {
            return(garage.IsFull==true)? true:false;            
        }

        public int GetNoOfSpacesLeft()
        {
            return garage.NoOfSpacesLeft;

        }



        public bool UnparkVehicle(int index)
        {
            if (garage.Remove(index) == true)
                return true;

            else
                return false;
        }


        public string ListAllVehiclesInGarage()
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


        public string GetNoOfEachType()  // Groups vehicles by type and counts the number of each type 
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

        public string FindVehicleByRegNo(string inputRegNo)
        {
            string result = "";
            
            var q = garage.Where(v => v?.RegNo.ToUpper() == inputRegNo.ToUpper());

            if (q.Count() == 0)
            {
                result = $"Sorry, could not find a vehicle with reg.no {inputRegNo}. ";                                   
            }

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


        public bool CheckRegNoBeforeAdding(string inputRegNo)
        {
            bool isExisting;

            var q = garage.Where(v => v?.RegNo.ToUpper() == inputRegNo.ToUpper());
            if (q.Count() == 0)
                isExisting = false;   // False if reg.no is not allready defined at any of the vehicles
            else isExisting = true;


            return isExisting;
        }


        public string FindByProperty(string type, string color, int noOfWheels)
        {
            string result = "";
            IEnumerable<Vehicle> q = garage;
            if (!type.Equals("X"))
            {
                q = q.Where(v => v.GetType().Name.ToLower() == type.ToLower());
            }
            if (color != "X")
            {
                q = q.Where(v => v.Color.ToLower() == color.ToLower());
            }
            if (noOfWheels != -1)
            {
                q = q.Where(v => v.NoOfWheels == noOfWheels);
            }


            foreach (var item in q)
            {
                result += $"{item.ToString()}\n";
            }

            return result;
        }



        public bool ParkAirplane(string color, int noOfWheels, string regNo, int numberOfEngines)
        {
            Airplane airplane = new Airplane(color, noOfWheels, regNo, numberOfEngines);
            if (garage.Add(airplane) == true)
                return true;
            else return false;
        }


        public bool ParkCar(string color, int noOfWheels, string regNo, string fuelType)
        {
            Car car = new Car(color, noOfWheels, regNo, fuelType);
            if (garage.Add(car) == true)
                return true;
            else return false;
        }

        public bool ParkMotorcycle(string color, int noOfWheels, string regNo, int cylinderVolume)
        {
            Motorcycle motorcycle = new Motorcycle(color, noOfWheels, regNo, cylinderVolume);
            if (garage.Add(motorcycle) == true)
                return true;
            else return false;
        }

        public bool ParkBus(string color, int noOfWheels, string regNo, int noOfSeats)
        {
            Bus bus = new Bus(color, noOfWheels, regNo, noOfSeats);
            if (garage.Add(bus) == true)
                return true;
            else return false;
        }

        public bool ParkBoat(string color, int noOfWheels, string regNo, int length)
        {
            Boat boat = new Boat(color, noOfWheels, regNo, length);
            if (garage.Add(boat) == true)
                return true;
            else return false;
        }

        public void SeedData()
        {
            ParkBoat(color: "white", noOfWheels: 0, regNo: "SEA001", length: 32);
            ParkAirplane(color: "grey", noOfWheels: 3, regNo: "SKY123", numberOfEngines: 2);            
            ParkMotorcycle(color: "black", noOfWheels: 3, regNo: "ACC900", cylinderVolume: 1000);            
            ParkBoat(color: "red", noOfWheels: 0, regNo: "SEA002", length: 25);
            ParkCar(color: "white", noOfWheels: 4, regNo: "CAR001", fuelType: "gasoline");            
            ParkAirplane(color: "black", noOfWheels: 3, regNo: "SKY222", numberOfEngines: 1);
            ParkBus(color: "green", noOfWheels: 4, regNo: "BUS001", noOfSeats: 40);          
            ParkMotorcycle(color: "yellow", noOfWheels: 2, regNo: "ACC800", cylinderVolume: 850);            
            ParkCar(color: "red", noOfWheels: 4, regNo: "XGA492", fuelType: "gasoline");
            ParkCar(color: "black", noOfWheels: 4, regNo: "CAR002", fuelType: "electric");
            ParkBus(color: "yellow", noOfWheels: 4, regNo: "BUS002", noOfSeats: 50);         
            ParkMotorcycle(color: "yellow", noOfWheels: 3, regNo: "ACC700", cylinderVolume: 900);            
        }
    }
}
