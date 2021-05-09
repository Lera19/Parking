// TODO: implement the ParkingService class from the IParkingService interface.
//       For try to add a vehicle on full parking InvalidOperationException should be thrown.
//       For try to remove vehicle with a negative balance (debt) InvalidOperationException should be thrown.
//       Other validation rules and constructor format went from tests.
//       Other implementation details are up to you, they just have to match the interface requirements
//       and tests, for example, in ParkingServiceTests you can find the necessary constructor format and validation rules.
using CoolParking.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

public class ParkingService : IParkingService
{
    private System.IO.StreamReader _streamReader = null;
    private Parking parking= new Parking();
    List<TransactionInfo> transactionInfo= new List<TransactionInfo>();
    private Dictionary<string, Vehicle> parkingMap = Parking.GetParkingMap();

    public ParkingService()
    {
        //this.parking = parking;
        //this.transactionInfo = transactionInfo;
        //this.parkingMap = parking.GetParkingMap();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        if (parkingMap.ContainsKey(vehicle.Id) == false)
        {
            parkingMap.Add(vehicle.Id, vehicle);
        }
        else
        {
            Console.WriteLine("This vehicle is in parking");
        }
    }

    public void Dispose()
    {
       _streamReader.Close();
    }

    public decimal GetBalance()
    {
        return parking.balanse;
    }

    public int GetCapacity()
    {
        return parkingMap.Count;
    }

    public int GetFreePlaces()
    {
        return Settings.parkingCapacity - parkingMap.Count;
    }

    public TransactionInfo[] GetLastParkingTransactions()
    {

        var lastTransaction = transactionInfo.ElementAt(transactionInfo.Count-1);
        return lastTransaction.GetList.ToArray();
        
    }

    public ReadOnlyCollection<Vehicle> GetVehicles()
    {
        ReadOnlyCollection<Vehicle> readOnlyCollection= new ReadOnlyCollection<Vehicle>(parkingMap.Values.ToList());
        return readOnlyCollection;
    }

    public string ReadFromLog()
    {
        throw new System.NotImplementedException();
    }

    public void RemoveVehicle(string vehicleId)
    {

        bool result = parkingMap.Remove(vehicleId);
        if(result == false)
        {
            Console.WriteLine("No vechical in park");
        }
    }

    public void TopUpVehicle(string vehicleId, decimal sum)
    {
        Vehicle resultVehicle = null;
        parkingMap.TryGetValue(vehicleId, out resultVehicle);

        if(resultVehicle != null)
        {
            resultVehicle.Balance += sum;
            parkingMap.Remove(vehicleId);
            parkingMap.Add(vehicleId, resultVehicle);
        }

    
        
    }

    private decimal GetPrice(Vehicle vehicle)
    {
        if(vehicle.VehicleType == VehicleType.Bus)
        {
            return Settings.busTariff;
        }
        else if(vehicle.VehicleType == VehicleType.Motorcycle)
        {
            return Settings.motorcycleTariff;
        }
        else if(vehicle.VehicleType == VehicleType.PassengerCar)
        {
            return Settings.passengerCarTariff;
        }
        else 
        {
            return Settings.truckTariff;
        }

    }
    private decimal GetVehicleBalance(Vehicle vehicle)
    {
        if(vehicle.Balance < GetPrice(vehicle))
        {
           var forfeit = (GetPrice(vehicle) - vehicle.Balance) * Settings.forfeit;
            return vehicle.Balance + forfeit;
        }
        else if(vehicle.Balance == 0)
        {
            return GetPrice(vehicle) * Settings.forfeit;
        }
        else
        {
            return vehicle.Balance - GetPrice(vehicle);
        }

    }

    public void GetVehiclesTariff(Vehicle vehicle)
    {

        parking.balanse += GetVehicleBalance(vehicle);
    }

}