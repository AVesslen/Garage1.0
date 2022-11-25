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
    internal class Manager
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
            //string message="Do you want the garage to be half full of vehicles from start? (yes/no)";
            //string answer = ui.GetStringInput(message);
            //SeedData(capacity);
            // Skapa garage 
            handler.CreateGarage(capacity);
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
                        //handler.SeeStatistics();
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
            //isFull?

            bool isRunning = true;
            do
            {
            string vehicleType = ui.GetStringInput("Select what type of vehicle you want to park:"
            + "\n1. Airplane"
            + "\n2. Motorcycle"
            + "\n3. Car"
            + "\n4. Bus"
            + "\n5. Boat");

                switch (vehicleType)
                {
                    case "1":
                        string color = ui.GetStringInput("Color: ");
                        int noOfWheels = ui.GetIntInput("Number of wheels: ");
                        string regNo = ui.GetStringInput("Reg. number: ");                        
                        int noOfEngines = ui.GetIntInput("Number of engines: ");
                        handler.ParkAirplane(color, noOfWheels, regNo, noOfEngines);
                        break;
                    case "2":
                        //handler.SeeStatistics();
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

            } while (isRunning=true);         

        }

        
        






        




    }
}
