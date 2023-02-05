using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace ParkingLotConsole
{
    public class TransactionTests
    {
        private readonly ITestOutputHelper _output;
        
        public TransactionTests(ITestOutputHelper output)
        {
            this._output = output;
        }
        
        [Fact]
        public void Constructor_CheckInVehicle_Succeeds()
        {
            //Arrange/ACT
            var transaction = new Transaction("ABC123");
            
            //Assert
            Assert.NotNull(transaction);
            Assert.Equal("ABC123", transaction.Nrkb);
            // _output.WriteLine(transaction.CheckInTime.ToString(CultureInfo.InvariantCulture));
        }
        
        [Fact]
        public void CheckOut_CheckOutVehicle_Succeeds()
        {
            //Arrange
            var transaction = new Transaction("ABC123");
            
            //ACT
            transaction.CheckOutNow();
            // TimeSpan span = transaction.CheckOutTime - transaction.CheckInTime;
            
            //Assert
            Assert.Equal(DateTime.Now, transaction.CheckOutTime, TimeSpan.FromSeconds(1));
            // _output.WriteLine(transaction.CheckOutTime.ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void ParkingDuration_inHours()
        {
            //Arrange
            var transaction = new Transaction("ABC123");
            
            DateTime now = DateTime.Now;
            DateTime checkOutAt = now.AddHours(3);
            transaction.CheckOutAt(checkOutAt);
             
            //ACT
            int parkingDuration = transaction.ParkingDurationInHours();
             
            //Assert
            Assert.Equal(3, parkingDuration);
        }

        [Fact]
        public void ParkingDuration_lessThanOneHour_returnOne()
        {
            //Arrange
            var transaction = new Transaction("ABC123");
             
            DateTime now = DateTime.Now;
            DateTime checkOutAt = now.AddMinutes(10);
            transaction.CheckOutAt(checkOutAt);
              
            //ACT
            int parkingDuration = transaction.ParkingDurationInHours();
              
            //Assert
            Assert.Equal(1, parkingDuration);           
        }
    }
}