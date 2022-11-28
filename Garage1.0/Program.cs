using Garage1._0.UserInterface;

namespace Garage1._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            


            

            Manager manager = new Manager(new ConsoleUI(), new GarageHandler());
            manager.Start();

            //    Test();

            //    AirPlane airPlane = new AirPlane("grey", 2, "abc123", 2);

            //    Garage<Vehicle> garage = new Garage<Vehicle>(4);
            //    garage.Add(airPlane);



            //}
            //private static void Test()
            //{
            //    var g = new Garage<Vehicle>(2);

            //    var onlyRed = g.Where(v => v?.Color == "Red");


            //    int nr = 0;
            //    List<Vehicle> vehicles = new();
            //    foreach (var item in g)
            //    {
            //        if (item.Color == "Red")
            //            vehicles.Add(item);
            //       // Console.WriteLine($"{nr++} {item}");

            //    }
        }
        //public static void Remove2(string index)
        //{
        //     ArgumentNullException.ThrowIfNull(index);

        //    if (index.Length < 2 || index.Length >= 14)
        //        throw new ArgumentOutOfRangeException("The index was out of range");
        //    Console.WriteLine(index);
        //}
    }
}