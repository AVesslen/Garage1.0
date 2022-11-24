using Garage1._0.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1._0
{
    public static class Util
    {
        public static string AskForString(string message,ConsoleUI ui)  // Checks if a string is null or empty and returns a valid string
        {
            string answer;
            bool success = false;

            do
            {
                ui.Print($"{message}: ");
                answer = ui.GetInput();              
               

                if (string.IsNullOrEmpty(answer))
                {
                    ui.Print($"You must enter a valid {message}. Please try again.");
                }
                else
                {
                    success = true;
                }

            } while (!success);

            return answer;
        }


        public static int AskForInt(string message, ConsoleUI ui)
        {
            bool isInt = false;
            int answer;
            do
            {
                string input=AskForString(message, ui); 
               
                isInt = int.TryParse(input, out answer);
                if (!isInt)
                    ui.Print($"That was not a valid input. Please try again.");
                   
             
            }
            while (isInt == false);

            return answer;
        }

    }
}
