using Garage1._0.UserInterface;

namespace Garage1._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager(new ConsoleUI(), new GarageHandler());
            manager.Run();
        }           
    }
}