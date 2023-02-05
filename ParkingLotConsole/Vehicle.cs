using System;

namespace ParkingLotConsole
{
    public class Vehicle
    {
        // Nrkb abbreviation from Nomor Registrasi Kendaraan Bermotor
        public string Nrkb { get; private set; }
        public string Color { get; private set; }
        public enum EnumVehicleType { Car, Motorbike }
        public EnumVehicleType VehicleType { get; private set; }

        public Vehicle(string nrkb, string color, int length, int width, int height)
        {
            bool isNkrbValid = IsRegistrationNumberValid(nrkb);
            if (isNkrbValid)
            {
                this.Color = color;
                ScanVehicleDimension(length, width, height);   
            }
        }
        
        public bool IsRegistrationNumberValid(string nrkb)
        {
            Console.WriteLine("Scanning NRKB with camera on process...");
            
            if (String.IsNullOrEmpty(nrkb))
            {
                // throw new Exception("NRKB is empty");
                Console.WriteLine("NRKB(Plat nomor) is not valid");
                return false;
            }

            string[] nrkbParts = nrkb.Split('-');
            if (nrkbParts.Length != 3)
            {
                // throw new Exception("NRKB(Plat nomor) is not valid");
                Console.WriteLine("NRKB(Plat nomor) is not valid");
                return false;
            }

            try
            {
                int unused = Convert.ToInt32(nrkbParts[1]);
            }
            catch (Exception)
            {
                Console.WriteLine("NRKB(Plat nomor) is not valid");
                return false;
            }
            
            this.Nrkb = nrkb;
            Console.WriteLine("Vehicle NRKB is valid");
            return true;
        }

        // Vehicle dimension in millimeter
        public void ScanVehicleDimension(int length, int width, int height)
        {
            Console.WriteLine("Scanning vehicle dimension with camera on process...");
            
            // dimension used as motorbike is standard motorbike with 110-125 cc
            if (length < 2100 || width < 800 || height < 1500)
            {
                VehicleType = EnumVehicleType.Motorbike;
            }
            else
            {
                VehicleType = EnumVehicleType.Car;
            }
            
            // dimension used as small car standard is Kijang LGX
            if (length > 4500 || width > 1700 || height > 1800)
            {
                throw new Exception("Vehicle dimension is larger than the parking lot");
            }
            
            Console.WriteLine("Vehicle dimension is valid");
        }
    }
}