using System;
using Xunit;

namespace ParkingLotConsole
{
    public class ParkingLotTests
    {
        [Fact]
        public void Constructor_ShouldCreateParkingLot_Succeeds()
        {
            // Arrange
            var parkingLot = new ParkingLot(6);
    
            // Act
            int parkingLotCapacity = parkingLot.Slots.Count;
    
            // Assert
            Assert.NotNull(parkingLot);
            Assert.Equal(6, parkingLotCapacity);
        }
        
        // Kijang LGX dimension car
        private const int Length = 4495;
        private const int Width = 1670;
        private const int Height = 1775;
        
        [Fact]
        public void CheckIn_ShouldAddVehicleToParkingLot_Succeeds()
        {
            // Arrange
            var parkingLot = new ParkingLot(6);
            var vehicle = new Vehicle("ABC-123-XYZ", "white", Length, Width, Height);
    
            // Act
            parkingLot.CheckIn(vehicle);
    
            // Assert
            Assert.Equal(vehicle, parkingLot.Slots[0]);
        }
        
        [Fact]
        public void CheckOut_ShouldRemoveVehicleFromParkingLot_Succeeds()
        {
            // Arrange
            var parkingLot = new ParkingLot(6);
            var vehicle = new Vehicle("ABC-123-XYZ",  "white", Length, Width, Height);
            parkingLot.CheckIn(vehicle);
    
            // Act
            parkingLot.CheckOut(vehicle);
    
            // Assert
            Assert.Null(parkingLot.Slots[0]);
        }
        
        [Fact]
        public void CheckOut_ShouldRemoveVehicleFromParkingLot_FailIfNotExist()
        {
            // Arrange
            var parkingLot = new ParkingLot(6);
            var vehicle = new Vehicle("ABC-123-XYZ", "white", Length, Width, Height);
            
            // Act
            Exception actualException = Assert.Throws<Exception>(() => parkingLot.CheckOut(vehicle));
            
            // Assert
            Assert.Equal("Vehicle doesn't exist in parking lot", actualException.Message);
        }
    }
}