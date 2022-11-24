using Garage1._0;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using Xunit.Sdk;

namespace UnitTests
{
    public class GarageTests
    {
        [Fact]
        public void Add_InputIsNull_Throws()
        {
            // Arrange
            int capacity = 4;
            Garage<Vehicle> garage = new Garage<Vehicle>(capacity);

            // Act and Assert

            Assert.Throws<ArgumentNullException>(() => garage.Add(null));
        }


        [Fact]
        public void Add_IfGarageIsNotFull_ReturnTrue()
        {
            // Arrange
            int capacity = 2;
            Garage<Vehicle> garage = new Garage<Vehicle>(capacity);
            AirPlane airPlane = new AirPlane("grey", 3, "FLY465", 2);
            bool expected = true;

            // Act
           var actual = garage.Add(airPlane);

            // Assert
            Assert.Equal(expected, actual);
        }



        [Fact]
        public void Add_IfGarageIsFull_ReturnFalse()
        {
            // Arrange
            int capacity = 2;
            Garage<Vehicle> garage = new Garage<Vehicle>(capacity);
            AirPlane airPlane = new AirPlane("grey", 3, "FLY465", 2);
            Car car = new Car("red", 4, "khr999", "gasoline");
            Boat boat = new Boat("white", 0, "SEA864", 32);
            garage.Add(car);
            garage.Add(airPlane);
            bool expected= false;

            // Act
            var actual= garage.Add(boat);

            // Assert
            Assert.Equal(expected, actual);

        }


        //[Fact]
        //public void Remove_IfGarageIsFull_ReturnFalse()
        //{
        //    // Arrange
        //    int capacity = 2;
        //    Garage<Vehicle> garage = new Garage<Vehicle>(capacity);
        //    AirPlane airPlane = new AirPlane("grey", 3, "FLY465", 2);
        //    Car car = new Car("red", 4, "khr999", "gasoline");
        //    Boat boat = new Boat("white", 0, "SEA864", 32);
        //    garage.Add(car);
        //    garage.Add(airPlane);
        //    bool expected = false;

        //    // Act
        //    var actual = garage.Add(boat);

        //    // Assert
        //    Assert.Equal(expected, actual);

        //}
    }

        


    


    
}