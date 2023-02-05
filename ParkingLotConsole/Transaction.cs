using System;

namespace ParkingLotConsole
{
    public class Transaction
    {
        public DateTime CheckInTime { get; private set; }
        public DateTime CheckOutTime { get; private set; }
        public string Nrkb { get; private set; }

        public Transaction(string nrkb)
        {
            this.Nrkb = nrkb;
            this.CheckInTime = DateTime.Now;
        }
        
        public void CheckOutNow()
        {
            this.CheckOutTime = DateTime.Now;
        }

        public void CheckOutAt(DateTime at)
        {
            this.CheckOutTime = at;
        }

        public int ParkingDurationInHours()
        {
            TimeSpan span = CheckOutTime - CheckInTime;
            int parkingDuration = (int)Math.Round(span.TotalHours, 0);
            if (parkingDuration < 1)
            {
                parkingDuration = 1;
            }
            return parkingDuration;
        }
    }
}