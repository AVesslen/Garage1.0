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
    public class Manager
    {
        private readonly ConsoleUI ui; //senare IUI
        private readonly GarageHandler handler; //senare IHandler

        public Manager(ConsoleUI ui, GarageHandler handler)
        {
            this.ui = ui;
            this.handler = handler;
        }
       
      
        public void Start()
        {
            WelcomeUser();
           
            //garagenamn?
            int capacity = ui.GetIntInput("How many parking spaces do you need in your garage? ");
            handler.CreateGarage(capacity);
           
            string answer=ui.GetStringInput("Do you want the garage to be filled with some vehicles from start? (yes/no)");
            if (answer.ToLower()=="yes")
            handler.SeedData();

            
            
            bool isRunning = true;
            do
            {               
                string input = ui.GetStringInput(ShowMainMenu());

                switch (input.ToUpper())
                {
                    case "1":
                        ParkVehicle();
                        break;
                    case "2":
                        SeeStatistics();
                        break;
                    case "3":
                       // UnparkVehicle();
                        break;
                    case "Q":
                       isRunning = false;
                        break;
                    default:
                        ui.Print("Please enter some valid input (1, 2, 3 or Q");
                        break;
                }
            } while (isRunning==true);
        }

     

     
        private void WelcomeUser()
        {
            ui.Print("Welcome to this garage application. Let's create a garage!");
        }
       
        private string ShowMainMenu()
        {
           return ("Please select what you want to do with your garage"
            + "\n1. Park a vehicle"
            + "\n2. See statistics"
            + "\n3. Unpark a vehicle"
            + "\nQ. Quit the application");
        }


        private void ParkVehicle()
        {
          bool full= handler.CheckIfFullGarage();//isFull?
            if (full == true)
                ui.Print("Sorry, your garage is allready full.");

            {
                string vehicleType = ui.GetStringInput("Select what type of vehicle you want to park:"
                + "\n1. Airplane"
                + "\n2. Motorcycle"
                + "\n3. Car"
                + "\n4. Bus"
                + "\n5. Boat");
                        string color = ui.GetStringInput("Color: ");
                        int noOfWheels = ui.GetIntInput("Number of wheels: ");
                        string regNo = ui.GetStringInput("Reg. number: ");

                switch (vehicleType)
                {
                    case "1":
                        int noOfEngines = ui.GetIntInput("Number of engines: ");
                       
                        if(handler.ParkAirplane(color, noOfWheels, regNo, noOfEngines)==true)
                                ui.PrintAddSuceed();
                        break;
                    case "2":
                        int cylinderVolume = ui.GetIntInput("Cylinder volume: ");

                        if (handler.ParkMotorcycle(color, noOfWheels, regNo, cylinderVolume) == true)
                            ui.PrintAddSuceed();
                        break;
                    case "3":
                        string fuelType = ui.GetStringInput("Fuel type?: ");

                        if (handler.ParkCar(color, noOfWheels, regNo, fuelType) == true)
                            ui.PrintAddSuceed();
                        break;
                    case "4":
                        int noOfSeats = ui.GetIntInput("Number of seats: ");

                        if (handler.ParkBus(color, noOfWheels, regNo, noOfSeats) == true)
                            ui.PrintAddSuceed();
                        break;
                    case "5":
                        int length = ui.GetIntInput("Length: ");

                        if (handler.ParkBoat(color, noOfWheels, regNo, length) == true)
                            ui.PrintAddSuceed();
                        break;
                    default:
                        ui.Print("Please enter some valid input (1, 2, 3, 4, 5");
                        break;
                }

            }
        }

        private void SeeStatistics()
        {
            //1. List all vehicles in the garage

            //Lägg till kapacitet och antal fordon?
            ui.Print("\nHere are the vehicles you have parked in the garage right now: \n");
           
            string answer=handler.ListAllVehiclesInGarage();
            ui.Print(answer);

            //2. List vehicle types and how many of them
            ui.Print("Number of each vehicle:\n");
           string answer2=handler.GetNoOfEachType();
            ui.Print(answer2);


            //string amountAirplane = handler.GetNoOfEachType();
           // ui.Print(amountAirplane);




           // handler.SortByProperty("grey");

            //string types=handler.ListType();
            //ui.Print(types);

            //What du you want to do?
            //     1. List all parked vehicles
            //     2. List vehicles by property
            //    3. Find a specific vehicle by regNO

            //if 3.
            //Do you want to filter by type?
            //  if yes
            //    string type = ui.GetStringInput("which type? ");
            // Do you want to filter by Color?
            // if yes
            //string color = ui.GetStringInput("which color? ");
            // by rising number Of Wheels?
            // if yes
            //var q = handler.SortByColor("grey");
            //q = handler.SortByNoOfWheels();
            //foreach (var item in q)
            //{
            //    Console.WriteLine(item);
            //}


            //bool isFull=handler.CheckIfEmptyGarage();

            //Garage<Vehicle> garage=handler.ListAllVehiclesInGarage();
            //foreach (Vehicle item in handler.garage)
            //{
            //    Console.WriteLine(item);
            //}

            //var q = garage.Where(v => v?.Color == color);
            //q = q.OrderBy(v => v.NoOfWheels);

            //return q;
        }














    }
}
