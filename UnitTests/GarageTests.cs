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

            Assert.Throws<ArgumentNullException>(() => garage.Add(null!));
        }


        [Fact]
        public void Add_IfGarageIsNotFull_ReturnTrue()
        {
            // Arrange
            int capacity = 2;
            Garage<Vehicle> garage = new Garage<Vehicle>(capacity);
            Airplane airplane = new Airplane("grey", 3, "FLY465", 2);
            bool expected = true;

            // Act
           var actual = garage.Add(airplane);

            // Assert
            Assert.Equal(expected, actual);
        }



        [Fact]
        public void Add_IfGarageIsFull_ReturnFalse()
        {
            // Arrange
            int capacity = 2;
            Garage<Vehicle> garage = new Garage<Vehicle>(capacity);
            Airplane airPlane = new Airplane("grey", 3, "FLY465", 2);
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


        [Fact]
        public void Add_IfVehicleAdded_NoOfVehiclesParkedShouldIncreaseByOne()
        {
            // Arrange
            int capacity = 10;
            Garage<Vehicle> garage = new Garage<Vehicle>(capacity);
            int expected = 1;

            // Act
            Boat boat = new Boat("white", 0, "SEA864", 32);
            garage.Add(boat);
            var actual = garage.NoOfVehiclesParked;

            // Assert
            Assert.Equal(expected, actual);
        }



        [Fact]
        public void Remove_IndexNotValid_Throws()
        {
            // Arrange 
            int capacity = 2;
            Garage<Vehicle> garage = new Garage<Vehicle>(capacity);
            int index = 5;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => garage.Remove(index));
        }

        [Fact]
        public void Remove_WhenSuccesfullyRemoved_ReturnTrue()
        {
            // Arrange
            int capacity = 2;
            Garage<Vehicle> garage = new Garage<Vehicle>(capacity);

            Boat boat = new Boat("white", 0, "SEA864", 32);
            garage.Add(boat);
            
            int index = 0;
            bool expected = true;

            // Act
            bool actual=garage.Remove(index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Remove_IfVehicleRemoved_NoOfVehiclesParked_ShouldDecreaseByOne()
        {
            // Arrange
            int capacity = 10;           
            Garage<Vehicle> garage = new Garage<Vehicle>(capacity);

            Boat boat = new Boat("white", 0, "SEA864", 32);
            garage.Add(boat);
            Airplane airPlane = new Airplane("grey", 3, "FLY465", 2);
            garage.Add(airPlane);
            
            int expected = 1;

            // Act
            garage.Remove(0);
            var actual = garage.NoOfVehiclesParked;

            // Assert
            Assert.Equal(expected, actual);
        }
    }

        


    


    
}