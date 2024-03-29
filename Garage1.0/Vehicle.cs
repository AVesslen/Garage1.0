﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1._0
{

    public abstract class Vehicle : IVehicle
    {
        public string Color { get; set; }
        public int NoOfWheels { get; set; }

        public string RegNo { get; set; }


        public Vehicle(string color, int noOfWheels, string regNo)
        {
            this.Color = color;
            this.NoOfWheels = noOfWheels;
            this.RegNo = regNo;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}\tReg.no:{RegNo}\tColor:{Color}\tNo of wheels:{NoOfWheels}";
        }
    }

    public class Airplane : Vehicle
    { 

        public int NumberOfEngines { get; set; }

        public Airplane(string color, int noOfWheels, string regNo, int numberOfEngines ) : base(color, noOfWheels, regNo)
        {
            NumberOfEngines = numberOfEngines;
        }

        public override string ToString()
        {
            return base.ToString() +"\tNo of engines:" + NumberOfEngines;
        }
    }

    public class Motorcycle : Vehicle
    {

        public int CylinderVolume { get; set; }

        public Motorcycle(string color, int noOfWheels, string regNo, int cylinderVolume) : base(color, noOfWheels, regNo)
        {
            CylinderVolume = cylinderVolume;
        }

        public override string ToString()
        {
            return base.ToString() + "\tCylinder volume:" + CylinderVolume;
        }

    }

    public class Car : Vehicle
    {

        public string FuelType { get; set; }

        public Car(string color, int noOfWheels, string regNo, string fuelType) : base(color, noOfWheels, regNo)
        {
           FuelType=fuelType;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}\t\tReg.no:{RegNo}\tColor:{Color}\tNo of wheels:{NoOfWheels}\tFuel type:{FuelType}";
        }
    }

    public class Bus : Vehicle
    {

        public int NumberOfSeats { get; set; }

        public Bus(string color, int noOfWheels, string regNo, int numberOfSeats) : base(color, noOfWheels, regNo)
        {
           NumberOfSeats=numberOfSeats;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}\t\tReg.no:{RegNo}\tColor:{Color}\tNo of wheels:{NoOfWheels}\tNo of seats:{NumberOfSeats}";
        }
    }

    public class Boat : Vehicle
    {

        public int Length { get; set; }

        public Boat(string color, int noOfWheels, string regNo, int length) : base(color, noOfWheels, regNo)
        {
            Length = length;
        }
      
        public override string ToString()
        {
            return $"{this.GetType().Name}\t\tReg.no:{RegNo}\tColor:{Color}\tNo of wheels:{NoOfWheels}\tLength:{Length}";
        }
    }

}
