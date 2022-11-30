using Garage1._0.UserInterface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Garage1._0
{
    public class Manager
    {
        private readonly IUI ui; 
        private readonly IHandler handler;
        private bool inProgress;

        public Manager(IUI ui, IHandler handler)  
        {
            this.ui = ui;
            this.handler = handler;
        }

        internal void Run()
        {
            Initialize();
            Start();
        }       
      
        private void Start()
        {           
            inProgress = true;

            do
            {               
                string input = ui.GetStringInput(ShowMainMenu());

                switch (input.ToUpper())
                {
                    case "1":
                        ParkVehicle();
                        break;
                    case "2":
                        UnparkVehicle();
                        break;
                    case "3":
                        ListVehicles();
                        break;
                    case "4":
                        ListVehicleTypesAndCount();
                        break;
                    case "5":
                        FindByRegNo();
                        break;
                    case "6":
                        FindByProperties();
                        break;
                    case "Q":
                       inProgress = false;
                        break;
                    default:
                        ui.Print("Please enter some valid input (1, 2, 3, 4, 5, 6 or Q");
                        break;
                }
            } while (inProgress==true);
        }

        private void Initialize()
        {
            ui.Print("Welcome to this garage application. Let's create a garage!");
            int capacity = ui.GetIntInput("How many parking spaces do you need in your garage? ");
            while (capacity <= 0)
            {
                capacity = ui.GetIntInput("The garage needs to have at least one parking space! Please try again!");
            }
            handler.CreateGarage(capacity);

            string answer = ui.GetStringInput("Do you want the garage to be filled with some vehicles from start? (yes/no)");
            while (answer.ToLower() != "yes" && answer.ToLower() != "no")
                answer = ui.GetStringInput("That was not a valid input. Please enter yes/no.");

            if (answer.ToLower() == "yes")
                handler.SeedData();
        }
              
        private string ShowMainMenu()
        {
           return ("\nPlease select what you want to do with your garage"
            + "\n1. Park a vehicle"
            + "\n2. Unpark a vehicle"
            + "\n3. List all vehicles in the garage"
            + "\n4. List vehicle types and how many of them"
            + "\n5. Find a vehicle by registration number"
            + "\n6. Find vehicle by one or more properties"
            + "\nQ. Quit the application");
        }

        private void ParkVehicle()
        {
          bool isFull= handler.CheckIfFullGarage();
            if (isFull == true)
            {
                ui.Print("Sorry, your garage is allready full.");
                return;
            }

            {
                int validVehicles = 5;
                int vehicleType = ui.GetIntInput("Select what type of vehicle you want to park: (1,2,3,..etc)"
                + "\n1. Airplane"
                + "\n2. Motorcycle"
                + "\n3. Car"
                + "\n4. Bus"
                + "\n5. Boat");

                while (vehicleType <= 0 || vehicleType > validVehicles)
                {
                    ui.Print("That was an invalid input, please enter a valid number 1, 2, 3, etc.");
                    vehicleType = ui.GetIntInput("");
                }

                string color = ui.GetStringInput("Color: ");          // Asks for properties in base class
                
                int noOfWheels = ui.GetIntInput("Number of wheels: ");
                while (noOfWheels < 0)
                    {
                        noOfWheels = ui.GetIntInput("Number of wheels can't be negative. Please try again!");
                    }

                string regNo;    // Checks if the reg.no allready exists. Every reg.no is uniqe and they can't be equal each other
                bool isExisting = false;
                do
                {
                   regNo = ui.GetStringInput("Reg. number: ");
                    if (handler.CheckRegNoBeforeAdding(regNo) == true)
                    {
                        ui.Print("That reg.no. allready exists. Please try again!");
                        isExisting = true;
                    }
                    else isExisting = false;
                    
                } while (isExisting == true) ;
                                             

                switch (vehicleType)            // Asks for properties in sub classes
                {
                    case 1:                      
                        int noOfEngines = ui.GetIntInput("Number of engines: ");
                       
                        if(handler.ParkAirplane(color, noOfWheels, regNo, noOfEngines)==true)
                                ui.PrintAddSuceed();
                        break;
                    case 2:
                        int cylinderVolume = ui.GetIntInput("Cylinder volume: ");

                        if (handler.ParkMotorcycle(color, noOfWheels, regNo, cylinderVolume) == true)
                            ui.PrintAddSuceed();
                        break;
                    case 3:
                        string fuelType = ui.GetStringInput("Fuel type?: ");

                        if (handler.ParkCar(color, noOfWheels, regNo, fuelType) == true)
                            ui.PrintAddSuceed();
                        break;
                    case 4:
                        int noOfSeats = ui.GetIntInput("Number of seats: ");

                        if (handler.ParkBus(color, noOfWheels, regNo, noOfSeats) == true)
                            ui.PrintAddSuceed();
                        break;
                    case 5:
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

        private void UnparkVehicle()
        {
            if (handler.CheckIfEmptyGarage() == true)
            {
                ui.Print("Sorry, you can't unpark any vehicle, because the garage is empty.");
                return;
            }
           
            ui.Print("Which of the listed vehicles do you want to unpark? (1,2,3.. etc");  
            string vehiclesInGarage=handler.ListAllVehiclesInGarage(); 
            ui.Print(vehiclesInGarage);                                     // Displays all parked vehicles
            int inputNumber= ui.GetIntInput("");                         //The user can choose number from the displayed list 

            while (inputNumber<=0 || inputNumber>handler.GetNoOfVehiclesParked())
            {
                ui.Print("That was an invalid input, please enter a valid number 1, 2, 3, etc.");
                inputNumber = ui.GetIntInput("");
            }

            if (handler.UnparkVehicle(inputNumber - 1) == true)  // Remove vehicle by index 
                ui.Print("Your vehicle was succesfully unparked!");
        }

        private void ListVehicles()                      // Lists all vehicles in the garage
        {
            //ToDo: Lägg till kapacitet och antal fordon?
            ui.Print("\nHere are the vehicles you have parked in the garage right now: \n");
            string vehiclesInGarage = handler.ListAllVehiclesInGarage();
            ui.Print(vehiclesInGarage);
            ui.Print($"Number of empty parking spaces left in the garage is: {handler.GetNoOfSpacesLeft()}\n");
        }                   

        private void ListVehicleTypesAndCount()          // Lists vehicle types and how many of them
        {            
            ui.Print("Number of each vehicle:\n");
            string typeAndNumber = handler.GetNoOfEachType();
            ui.Print(typeAndNumber);
        }

        private void FindByRegNo()                       // Finds a vehicle by registration number   
        {
            if (handler.CheckIfEmptyGarage() == true)
            {
                ui.Print("Sorry, you can't find any reg.no, because the garage is empty.");
                return;
            }
            string inputRegNo = ui.GetStringInput("Enter the registration number of the vehicle you want to find: ");
            string vehicleFound = handler.FindVehicleByRegNo(inputRegNo);
            ui.Print(vehicleFound);
        }

        private void FindByProperties()                  // Finds vehicle(s) by one or more properties
        {
            if (handler.CheckIfEmptyGarage() == true)
            {
                ui.Print("Sorry, you can't use any search criteria  because the garage is empty.");
                return;
            }

            // type
            string type = "";
            bool isRunning = false;
            string answer = ui.GetStringInput("Do you want to find vehicle by type? (yes/no)");
            do
            {
                if (answer.ToLower() == "yes")
                {
                    var vehicleTypes = new Dictionary<int, string>
                {
                    { 1, "airplane"},
                    { 2, "motorcycle"},
                    { 3, "car"},
                    { 4, "bus"},
                    { 5, "boat"}
                };

                    ui.Print("Select what type of vehicle you want to find (1, 2, 3, etc..)");

                    foreach (var vehicleType in vehicleTypes)
                    {
                        ui.Print($"{vehicleType.Key}: {vehicleType.Value}");
                    }

                    int inputNumber = ui.GetIntInput("");
                    while (inputNumber <= 0 || inputNumber > vehicleTypes.Count)
                    {
                        ui.Print("That was not a valid input, please enter a valid number 1, 2, 3, etc.)");
                        inputNumber = ui.GetIntInput("");
                    }
                    type = vehicleTypes[inputNumber];
                    isRunning = false;
                }

                else if (answer.ToLower() == "no")
                {
                    type = "X";                 // Sets to X if user is not interested in this property
                    isRunning = false;
                }
                else
                {
                    answer = ui.GetStringInput("That was not a valid input. Please enter yes/no.");
                    isRunning = true;
                }

            } while (isRunning == true);

            // color
            string color = "";
            answer = ui.GetStringInput("Do you want to find vehicle by color? (yes/no)");
            do
            {
                if (answer.ToLower() == "yes")
                {
                    color = ui.GetStringInput("Enter color: ");
                    isRunning = false;
                }

                else if (answer.ToLower() == "no")
                {
                    color = "X";                        // Sets to X if user is not interested in this property
                    isRunning = false;
                }
                else
                {
                    answer = ui.GetStringInput("That was not a valid input. Please enter yes/no.");
                    isRunning = true;
                }
            } while (isRunning == true);

            // no of wheels
            int noOfWheels = -1;
            answer = ui.GetStringInput("Do you want to find vehicle by no of wheels? (yes/no)");
            do
            {
                if (answer.ToLower() == "yes")
                {
                    noOfWheels = ui.GetIntInput("Enter number of wheels: ");
                    while (noOfWheels < 0)
                    {
                        noOfWheels = ui.GetIntInput("Please enter a non-negative number");
                    }
                    isRunning = false;
                }

                else if (answer.ToLower() == "no")
                {
                    noOfWheels = -1;           // Sets to -1 if user is not interested in this property
                    isRunning = false;
                }
                else
                {
                    answer = ui.GetStringInput("That was not a valid input. Please enter yes/no.");
                    isRunning = true;
                }
            } while (isRunning == true);

            string foundVehicles = handler.FindByProperty(type, color, noOfWheels);
            ui.PrintPropertyMessage(type, color, noOfWheels);
            ui.Print(foundVehicles);
        } 
    }
}
