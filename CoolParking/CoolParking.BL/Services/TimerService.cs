// TODO: implement class TimerService from the ITimerService interface.
//       Service have to be just wrapper on System Timers.
using CoolParking.BL.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Timers;

public class TimerService : ITimerService
{
    private Dictionary<string, Vehicle> parkingMap;

   ParkingService parkingService = new ParkingService();
    public double Interval { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public event ElapsedEventHandler Elapsed;

    public void Dispose()
    {
        throw new System.NotImplementedException();
    }

    public void Start()
    {
        int num = 0;
        //foreach (KeyValuePair<string, Vehicle> kvp in parkingMap)
        //{
        //    kvp.Value.Balance
        //}

      TimerCallback tm = new TimerCallback(parkingService.GetVehiclesTariff());

        Timer timer = new Timer(tm, num, 0, Settings.paymentTime);

    }

    public void Stop()
    {
        throw new System.NotImplementedException();
    }
}