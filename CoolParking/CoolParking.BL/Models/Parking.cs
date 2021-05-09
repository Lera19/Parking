// TODO: implement class Parking.
//       Implementation details are up to you, they just have to meet the requirements 
//       of the home task and be consistent with other classes and tests.
using System.Collections.Generic;

public class Parking
{
    private Dictionary<string, Vehicle> parkingMap = new Dictionary<string, Vehicle>(Settings.parkingCapacity);

    private static Parking instance;

    public Parking()
    {

    }

    public static Parking GetInstance()
    {
        if(instance == null)
        {
            instance = new Parking();
        }
        return instance;
    }

    public VehicleType vehicleType { get; set; }
    public decimal balanse { get; set; }
    
    public  static Dictionary<string, Vehicle> GetParkingMap()
    {
        return parkingMap;
    }


}