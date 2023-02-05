using System;
using System.Text;

namespace ParkingLotConsole
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int menuChoosen = 0;
            ParkingLot parkingLot = null;
            PrintMenu();
            while (menuChoosen != 12)
            {
                Console.Write("Please choose menu: ");
                menuChoosen = Convert.ToInt32(Console.ReadLine());
                switch (menuChoosen)
                {
                    case 1:
                        PrintMenu();
                        Console.Write("Please enter the parking lot size: ");
                        int parkingSlotSize = Convert.ToInt32(Console.ReadLine());
                        parkingLot = new ParkingLot(parkingSlotSize);
                        Console.WriteLine(new String('=', 53));
                        break;
                    case 2:
                        PrintMenu();
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Please create parking lot first, with menu number 1.");   
                        }
                        else
                        {
                            int length, width, height;
                            Console.Write("Write vehicle type (1 for car, 2 for motorbike): ");
                            int vehicleType = Convert.ToInt32(Console.ReadLine());
                            if (vehicleType == 1)
                            {
                                // Kijang LGX
                                length = 4495; width = 1670; height = 1775;
                            } else if (vehicleType == 2)
                            {
                                // Supra x 125cc
                                length = 1995; width = 750; height = 1400;
                            } else
                            {
                                Console.WriteLine("Invalid vehicle type.");
                                Console.WriteLine(new String('=', 53));
                                break;
                            }
                            Console.WriteLine("Format example: qwe-4422-xyz");
                            Console.Write("Write vehicle license plate: ");
                            string nrkb = Console.ReadLine();

                            Console.Write("Write vehicle color: ");
                            string vehicleColor = Console.ReadLine();
                            
                            Vehicle vehicle = new Vehicle(nrkb, vehicleColor, length, width, height);
                            if (!String.IsNullOrEmpty(vehicle.Nrkb))
                            {
                                parkingLot.CheckIn(vehicle);
                            }
                        }
                        Console.WriteLine(new String('=', 53));
                        break;
                    case 3:
                        PrintMenu();
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Please create parking lot first, with menu number 1.");   
                        }
                        else
                        {
                            Console.Write("Please enter slot number to unpark (check out): ");
                            int selectedParkingSlot = Convert.ToInt32(Console.ReadLine());                                                   
                            foreach (var slot in parkingLot.Slots)
                            {
                                if (slot.Value != null && slot.Key == selectedParkingSlot - 1)
                                {
                                    parkingLot.CheckOut(slot.Value);
                                }
                            }
                        }
                        Console.WriteLine(new String('=', 53));
                        break;                   
                    case 4:
                        PrintMenu();
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Please create parking lot first, with menu number 1.");   
                        }
                        else
                        {
                            Console.WriteLine(parkingLot.ToString());
                        }
                        Console.WriteLine(new String('=', 53));
                        break;
                    case 5:
                        PrintMenu();
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Please create parking lot first, with menu number 1.");   
                        }
                        else
                        {
                            parkingLot.CountMotorInParkingLot();
                        }
                        Console.WriteLine(new String('=', 53));
                        break;
                    case 6:
                        PrintMenu();
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Please create parking lot first, with menu number 1.");   
                        }
                        else
                        {
                            parkingLot.CountCarInParkingLot();
                        }
                        Console.WriteLine(new String('=', 53));
                        break;
                    case 7:
                        PrintMenu();
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Please create parking lot first, with menu number 1.");   
                        }
                        else
                        {
                            parkingLot.OddEvenPlate(ParkingLot.EnumOddEven.Odd);
                        }
                        Console.WriteLine(new String('=', 53));
                        break;
                    case 8:
                        PrintMenu();
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Please create parking lot first, with menu number 1.");   
                        }
                        else
                        {
                            parkingLot.OddEvenPlate(ParkingLot.EnumOddEven.Even);
                        }
                        Console.WriteLine(new String('=', 53));
                        break;
                    case 9:
                        PrintMenu();
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Please create parking lot first, with menu number 1.");   
                        }
                        else
                        {
                            Console.Write("Please enter vehicle color: ");
                            string color = Console.ReadLine();
                            parkingLot.PrintNrkbBaseOnVehicleColor(color);
                        }
                        Console.WriteLine(new String('=', 53));
                        break;
                    case 10:
                        PrintMenu();
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Please create parking lot first, with menu number 1.");
                        }
                        else
                        {
                            Console.Write("Please enter vehicle color: ");
                            string color = Console.ReadLine();
                            parkingLot.PrintSlotNumberBaseOnVehicleColor(color);
                        }
                        Console.WriteLine(new String('=', 53));
                        break;
                    case 11:
                        PrintMenu();
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Please create parking lot first, with menu number 1.");   
                        }
                        else
                        {
                            Console.WriteLine("Please enter vehicle license plate: ");
                            string nrkb = Console.ReadLine();
                            parkingLot.PrintSlotNumberBaseOnVehicleNrkb(nrkb);
                        }
                        Console.WriteLine(new String('=', 53));
                        break;
                    case 12:
                        Console.WriteLine(new String('=', 53));
                        Console.WriteLine("Thank you for parking with us.");
                        Console.WriteLine(new String('=', 53));
                        break;                
                }
            }

        }

        static void PrintMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1. Create parking lot\n");
            sb.Append("2. Park vehicle\n");
            sb.Append("3. Unpark vehicle\n");
            sb.Append("4. Status\n");
            sb.Append("5. Count motorbike parked\n");
            sb.Append("6. Count car parked\n");
            sb.Append("7. Print odd plate\n");
            sb.Append("8. Print even plate\n");
            sb.Append("9. Print plates by color\n");
            sb.Append("10. Print parking slot number by color\n");
            sb.Append("11. Print parking slot number by plate\n");
            sb.Append("12. Exit\n");           
            Console.WriteLine(sb);
        }
    }
    
}