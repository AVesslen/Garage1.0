﻿using Garage1._0.UserInterface;
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
        // Welcome to this garageapplication. Let's create a garage! Hur many
        // parking spaces do you need in your garage? (capacity)
        //
        // Do you want the garage to be half full of vehicles from start? (yes/no)

        // Skapa garage 

        //Menu
        //1. Park a vehicle in a garage
        //2. See statistics of your garage
        //3. Unpark vehicle from garage
        //4. Quit the application

        public void Run()
        {
          SeedData(int capacity);

            do
            {
                ShowMainMeny();
                string input = ui.GetInput()!;

                switch (input)
                {
                    case MenyHelpers.Add:
                        AddEmployee();
                        break;
                    case MenyHelpers.Print:
                        PrintEmployees();
                        break;
                    case MenyHelpers.Quit:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }



            } while (true);
        }


        //    //Lägga till menyhelpers?
        //private void ShowMainMenu()
        //{
        //    ui.Print("1. Park a vehicle in the garage");
        //    ui.Print("2. See statistics of your garage");
        //    ui.Print("3. Unpark vehicle from garage");
        //    ui.Print("4. Quit the application");      
        //}

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
