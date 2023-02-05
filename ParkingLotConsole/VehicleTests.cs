using System;
using Xunit;
using Xunit.Abstractions;

namespace ParkingLotConsole
{
    public class VehicleTests
    {
        private readonly ITestOutputHelper _output;

        public VehicleTests(ITestOutputHelper output)
        {
            this._output = output;
        }

        // dimension used as small car standard is Kijang LGX
        private const int Length = 4495;
        private const int Width = 1670;
        private const int Height = 1775;

        [Fact]
        public void Constructor_ScanRegistrationNumber_Succeeds()
        {
            string expectedNrkb = "ABC-123-XYZ";
            var vehicle = new Vehicle(expectedNrkb, "white", Length, Width, Height);
            
            string actualNrkb = vehicle.Nrkb;
            
            _output.WriteLine("test hmm");
            Assert.Equal(expectedNrkb, actualNrkb);
        }
        
        [Fact]
        public void Constructor_EmptyRegistrationNumber_ReturnEmptyNrkb()
        {
            Vehicle vehicle = new Vehicle("", "white", 4300, 1700, 1700);

            string isNrkbEmpty = vehicle.Nrkb;

            Assert.Null(isNrkbEmpty);
        }

        [Fact]
        public void Constructor_InvalidRegistrationNumber_ReturnEmptyNrkb()
        {

            Vehicle vehicle = new Vehicle("ABC123", "white", 4300, 1700, 1700);
            
            string isNrkbEmpty = vehicle.Nrkb;

            Assert.Null(isNrkbEmpty);           
        }

        [Fact]
        public void Constructor_VehicleDimensionIsLargeCar_ThrowsException()
        {
            int length = 4800, width = 1800, height = 1800;
            
            Exception actualException = Assert.Throws<Exception>(() => new Vehicle("ABC-123-XYZ", "white", length, width, height));
            
            Assert.Equal("Vehicle dimension is larger than the parking lot", actualException.Message);
        }
    }
}