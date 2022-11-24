using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1._0.UserInterface
{
    public class ConsoleUI //: IUI
    {
        public string GetInput()
        {
            return Console.ReadLine()!;
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
