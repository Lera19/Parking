// TODO: implement class Vehicle.
//       Properties: Id (string), VehicleType (VehicleType), Balance (decimal).
//       The format of the identifier is explained in the description of the home task.
//       Id and VehicleType should not be able for changing.
//       The Balance should be able to change only in the CoolParking.BL project.
//       The type of constructor is shown in the tests and the constructor should have a validation, which also is clear from the tests.
//       Static method GenerateRandomRegistrationPlateNumber should return a randomly generated unique identifier.
using System;
using System.Text;

public class Vehicle
{
    private string id;
    private readonly Random _random = new Random();

    public Vehicle(string id, VehicleType vehicleType, decimal balance)
    {
        Id=id;
        VehicleType = vehicleType;
        Balance= balance;
    }

    public string Id {
        set
        {
            id = GenerateRandomRegistrationPlateNumber();
        }
        get
        {
            return id;
        }
    }

    public VehicleType VehicleType { get;}
    
    public decimal Balance { get;set; }

    private string GenerateRandomRegistrationPlateNumber()
    {
        var idBuilder = new StringBuilder();
        idBuilder.Append(RandomString(2) + "-");
        idBuilder.Append(RandonNumber(0, 9999) + "-");
        idBuilder.Append(RandomString(2));

        return idBuilder.ToString();
    }

    private string RandomString(int size, bool lowerCase = false)
    {
        var builder = new StringBuilder(size);
        char offset = lowerCase ? 'a' : 'A';
        const int lettersOffset = 26;
        for (var i = 0; i < size; i++)
        {
            var @char = (char)_random.Next(offset, offset + lettersOffset);
            builder.Append(@char);

        }
        return lowerCase ? builder.ToString().ToLower() : builder.ToString();
    }

    private int RandonNumber(int min, int max)
    {
        return _random.Next(min, max);
    }
}