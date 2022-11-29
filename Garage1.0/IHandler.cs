namespace Garage1._0
{
    public interface IHandler
    {
        bool CheckIfEmptyGarage();
        bool CheckIfFullGarage();
        bool CheckRegNoBeforeAdding(string inputRegNo);
        void CreateGarage(int capacity);
        string FindByProperty(string type, string color, int noOfWheels);
        string FindVehicleByRegNo(string inputRegNo);
        string GetNoOfEachType();
        int GetNoOfVehiclesParked();
        string ListAllVehiclesInGarage();
        bool ParkAirplane(string color, int noOfWheels, string regNo, int numberOfEngines);
        bool ParkBoat(string color, int noOfWheels, string regNo, int length);
        bool ParkBus(string color, int noOfWheels, string regNo, int noOfSeats);
        bool ParkCar(string color, int noOfWheels, string regNo, string fuelType);
        bool ParkMotorcycle(string color, int noOfWheels, string regNo, int cylinderVolume);
        bool UnparkVehicle(int index);
        void SeedData();
        int GetNoOfSpacesLeft();
    }
}