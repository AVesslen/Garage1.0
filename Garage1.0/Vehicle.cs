using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1._0
{
    public abstract class Vehicle
    {
        public string Color { get; set; }
        public int NoOfWheels { get; set; }
     
        public string RegNo { get; set; }



       // public Vehicle() : this("DefaultColor", 4,"NotRegistredYet") { }

        public Vehicle(string color, int noOfWheels, string regNo)
        {
            this.Color = color;
            this.NoOfWheels = noOfWheels;
            this.RegNo = regNo;
        }

        public override string ToString()
        {
            return "Reg.no:" + RegNo + "  Color:" + Color + "  No of wheels: " + NoOfWheels;
        }
    }

    public class AirPlane : Vehicle
    { 

        public int NumberOfEngines { get; set; }

        public AirPlane(string color, int noOfWheels, string regNo, int numberOfEngines ) : base(color, noOfWheels, regNo)
        {
            NumberOfEngines = numberOfEngines;
        }

        public override string ToString()
        {
            return base.ToString() + "  No of engines:" + NumberOfEngines;
        }
    }

    public class Motorcycle : Vehicle
    {

        public int CylinderVolume { get; set; }

        public Motorcycle(string color, int noOfWheels, string regNo, int cylinderVolume) : base(color, noOfWheels, regNo)
        {
            CylinderVolume = cylinderVolume;
        }
    }

    public class Car : Vehicle
    {

        public string FuelType { get; set; }

        public Car(string color, int noOfWheels, string regNo, string fuelType) : base(color, noOfWheels, regNo)
        {
           FuelType=fuelType;
        }
    }

    public class Bus : Vehicle
    {

        public int NumberOfSeats { get; set; }

        public Bus(string color, int noOfWheels, string regNo, int numberOfSeats) : base(color, noOfWheels, regNo)
        {
           NumberOfSeats=numberOfSeats;
        }
    }

    public class Boat : Vehicle
    {

        public int Length { get; set; }

        public Boat(string color, int noOfWheels, string regNo, int length) : base(color, noOfWheels, regNo)
        {
            Length = length;
        }
    }

}
