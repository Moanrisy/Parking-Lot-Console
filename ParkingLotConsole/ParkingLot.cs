using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLotConsole
{
    public class ParkingLot
    {
        private double _priceParkingPerHour = 5000;
        public Dictionary<int, Vehicle> Slots { get; private set; }
        public List<Transaction> Transactions { get; private set; }

        public ParkingLot(int slotNumber)
        {
            Slots = new Dictionary<int, Vehicle>();
            for (int i = 0; i < slotNumber; i++)
            {
                Slots[i] = null;
            }
            Transactions = new List<Transaction>();
            Console.WriteLine("Created a parking lot with {0} slots", slotNumber);
        }

        public void CheckIn(Vehicle vehicle)
        {
            for (int i = 0; i < Slots.Count; i++)
            {
                if (Slots[i] == null)
                {
                    Slots[i] = vehicle;
                    Transactions.Add(new Transaction(vehicle.Nrkb));
                    Console.WriteLine("Allocated slot number: " + (i + 1));
                    return;
                }
            }
            
            Console.WriteLine("Sorry, parking lot is full");
        }

        public void CheckOut(Vehicle vehicle)
        {
            bool exist = false;
            var updatedSlot = new Dictionary<int, Vehicle>(Slots);
            foreach (var slot in Slots)
            {
                if (slot.Value != null && slot.Value == vehicle)
                {
                    exist = true;

                    var transaction = Transactions.FirstOrDefault(x => x.Nrkb == vehicle.Nrkb);
                    if (transaction != null)
                    {
                        transaction.CheckOutNow();
                        Console.WriteLine("Parking duration in hour: "+transaction.ParkingDurationInHours());
                        Console.WriteLine("Price per hour: "+_priceParkingPerHour);
                        Console.WriteLine("Parking price: "+ _priceParkingPerHour * transaction.ParkingDurationInHours());
                    }
                    
                    Console.WriteLine(new String('=', 35));
                    updatedSlot[slot.Key] = null;
                    Console.WriteLine("Slot number " + (slot.Key + 1) + " is free");
                    break;
                }
            }

            if (exist)
            {
                Slots = updatedSlot;
            }
            else
            {
                throw new Exception("Vehicle doesn't exist in parking lot");
            }
        }
        
        public void CountMotorInParkingLot()
        {
            int count = 0;
            foreach (var slot in Slots)
            {
                if (slot.Value != null && slot.Value.VehicleType is Vehicle.EnumVehicleType.Motorbike)
                {
                    count++;
                }
            }

            Console.WriteLine("Number of motorbike in parking lot is: " + count);
        }
        
        public void CountCarInParkingLot()
        {
            int count = 0;
            foreach (var slot in Slots)
            {
                if (slot.Value != null && slot.Value.VehicleType is Vehicle.EnumVehicleType.Car)
                {
                    count++;
                }
            }
        
            Console.WriteLine("Number of car in parking lot is: " + count);
        }
        
        public enum EnumOddEven { Odd, Even }
        public void OddEvenPlate(EnumOddEven enumOddEven)
        {
            StringBuilder sb = new StringBuilder();
            bool firstItem = true;
            foreach (var slot in Slots)
            {
                if (slot.Value != null)
                {
                    string[] nrkbParts = slot.Value.Nrkb.Split('-');
                    if (enumOddEven == EnumOddEven.Odd)
                    {
                        if (Convert.ToInt32(nrkbParts[1]) % 2 != 0)
                        {
                            if (firstItem)
                            {
                                firstItem = false;
                                sb.Append(slot.Value.Nrkb);
                            }
                            else
                            {
                                sb.Append(", " + slot.Value.Nrkb);
                            }
                        }    
                    }
                    else if (enumOddEven == EnumOddEven.Even)
                    {
                        if (Convert.ToInt32(nrkbParts[1]) % 2 == 0)
                        {
                            if (firstItem)
                            {
                                firstItem = false;
                                sb.Append(slot.Value.Nrkb);
                            }
                            else
                            {
                                
                                sb.Append(", " + slot.Value.Nrkb);
                            }
                        }                       
                    }
                }
            }
            Console.WriteLine(sb);
        }

        public void PrintNrkbBaseOnVehicleColor(string color)
        {
            bool firstItem = true;
            StringBuilder sb = new StringBuilder();
            foreach (var slot in Slots)
            {
                if (slot.Value != null && slot.Value.Color == color)
                {
                    if (firstItem)
                    {
                        sb.Append(slot.Value.Nrkb);
                        firstItem = false;
                    }
                    else
                    {
                        sb.Append(", " + slot.Value.Nrkb);
                        
                    }
                }
            }

            if (firstItem)
            {
                sb.Append("Vehicle with color " + color + " doesn't exist in parking lot");
            }
            Console.WriteLine(sb);
        }
        
        public void PrintSlotNumberBaseOnVehicleColor(string color)
        {
            bool firstItem = true;
            StringBuilder sb = new StringBuilder();
            foreach (var slot in Slots)
            {
                if (slot.Value != null && slot.Value.Color == color)
                {
                    if (firstItem)
                    {
                        firstItem = false;
                        sb.Append(slot.Key + 1);
                    }
                    else
                    {
                        sb.Append(", " + (slot.Key + 1));
                    }
                }
            }
            Console.WriteLine(sb);
        }
        
        public void PrintSlotNumberBaseOnVehicleNrkb(string nrkb)
        {
            foreach (var slot in Slots)
            {
                if (slot.Value != null && slot.Value.Nrkb == nrkb)
                {
                    Console.WriteLine(slot.Key + 1);
                    return;
                }
            }
            Console.WriteLine("Not found");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Slot No.\tRegistration No\tType\tColour\n");
            for (int i = 0; i < Slots.Count; i++)
            {
                if (Slots[i] != null)
                {
                    sb.Append(i + 1 + "\t\t");
                    sb.Append(Slots[i].Nrkb + "\t");
                    sb.Append(Slots[i].VehicleType + "\t");
                    sb.Append(Slots[i].Color);
                    sb.Append("\n");
                }
            }

            return sb.ToString();
        }
    }
}