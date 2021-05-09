using System;

namespace CoolParking.BL
{
    public class StartProgram
    {
        public static void Main(string[] args)
        {

            ParkingService parkingService = new ParkingService();
            Vehicle vehicle = new Vehicle("JK-5687-IO", VehicleType.Bus, 100);
            Console.WriteLine("Menu\r");
            Console.WriteLine("------------------------\n");

            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\t1 - Balance of the parking");
            Console.WriteLine("\t2 - Display the amount of money earned for the current period");
            Console.WriteLine("\t3 - Display free / occupied parking spaces.");
            Console.WriteLine("\t4 - Display last Parking Transactions for the current period ");
            Console.WriteLine("\t5 - Print the transaction history Transactions.log");
            Console.WriteLine("\t6 - List vehicle in the parking");
            Console.WriteLine("\t7 - Put vehicle in the parking");
            Console.WriteLine("\t8 - Pick up a vehicle from the Parking");
            Console.WriteLine("\t9 - Top up the balance of a vehicle");
            Console.Write("Your option? ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine($"Balance parking: { Settings.firstBalanceOfTheParking}");
                    break;
                case "2":
                    Console.WriteLine($"Balance parking after this period: {parkingService.GetBalance()}");

                    break;
                case "3":
                    Console.WriteLine($"Capacity in parking occupied: {parkingService.GetCapacity()} and free: {Settings.parkingCapacity - parkingService.GetCapacity()}");

                    break;
                case "4":
                    Console.WriteLine($"Last transaction: {parkingService.GetLastParkingTransactions()}");

                    break;
                case "5":
                    //Console.WriteLine($"Transaction history: {}");

                    break;
                case "6":
                    Console.WriteLine($"List vehicle in the parking: {parkingService.GetVehicles()}");

                    break;
                case "7":
                    //Console.WriteLine($"Add vehicle: {parkingService.AddVehicle()}");

                    break;
                case "8":
                    //Console.WriteLine($"Remove vehicle in the parking list: {parkingService.RemoveVehicle(vehicle.Id)}");

                    break;
                case "9":
                    //Console.WriteLine($"Balance parking after this period: {parkingService.TopUpVehicle(vehicle.Id, vehicle.Balance)}");

                    break;
            }
            
            Console.ReadKey();
        }
    }
}