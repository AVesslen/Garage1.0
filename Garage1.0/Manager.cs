using Garage1._0.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
       
        internal void Run()
        {
            Initialize();
            Start();
        }


        private void WelcomeUser()
        {
            ui.Print("Welcome to this garage application. Let's create a garage!");
        }

        public void Start()
        {      

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

     

        private void Initialize()
        {
            WelcomeUser();
            
            int capacity = ui.GetIntInput("How many parking spaces do you need in your garage? ");
            string message="Do you want the garage to be half full of vehicles from start? (yes/no)";
            string answer = ui.GetStringInput(message);
            //SeedData(capacity);
            // Skapa garage 
            handler.CreateGarage(capacity);
        }

        //    //Lägga till menyhelpers?
        private string ShowMainMenu()
        {
           return ("Please select what you want to do with your garage"
            + "\n1. Park a vehicle in the garage"
            + "\n2. See statistics of your garage"
            + "\n3. Unpark vehicle from garage"
            + "\nQ. Quit the application");
        }
        private void ParkVehicle()
        {
            string type = ui.GetStringInput("Type of vehicle: (airplane, car, bus, motorcycle or boat)");
            if (type.ToLower() != "airplane" || type.ToLower() != "car" || type.ToLower() != "bus" || type.ToLower() != "motorcycle" || type.ToLower() != "boat")
            {
                ui.Print("That was not a valid type");
                return;
            }

            string color = ui.GetStringInput("Color: ");
            int noOfWheels = ui.GetIntInput("Number of wheels: ");
            string regNo = ui.GetStringInput("Reg. number: ");
            handler.ParkVehicle()

        }






        //private void SeedData(int capacity)
        //{
        //    payRoll.AddEmployee("Anna", 36000);
        //    payRoll.AddEmployee("Bengt", 30000);
        //    payRoll.AddEmployee("Pelle", 4000);
        //    payRoll.AddEmployee("Lars", 60000);
        //    payRoll.AddEmployee("Anna", 35000);
        //    payRoll.AddEmployee("Anna", 5000);
        //}

        


    }
}
