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
       
        public void Run()
        {
            ui.Print("Welcome to this garage application. Let's create a garage!");
            int capacity = Util.AskForInt("How many parking spaces do you need in your garage? ", ui);
            // Do you want the garage to be half full of vehicles from start? (yes/no)
            //SeedData(capacity);
            // Skapa garage 
            bool isRunning = true;
            do
            {
                ShowMainMenu();
                string input = ui.GetInput()!;

                switch (input)
                {
                    case "1":
                        ParkVehicle();
                        break;
                    case "2":
                        SeeStatistics();
                        break;
                    case "3":
                        UnparkVehicle();
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


        //    //Lägga till menyhelpers?
        private void ShowMainMenu()
        {
            ui.Print("Please select what you want to do with your garage"
            + "\n1. Park a vehicle in the garage"
            + "\n2. See statistics of your garage"
            + "\n3. Unpark vehicle from garage"
            + "\nQ. Quit the application");
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

        //AskForString
        //Ask for int


    }
}
