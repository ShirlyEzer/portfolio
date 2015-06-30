using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eFuelType
    {
        Octan95 = 1,
        Octan96,
        Octan98,
        Soler
     }

    public enum eColor
    {
        Green = 1,
        Black,
        Red,
        Silver
    }

    public enum eAmountOfDoors
    {
        Two = 1,
        Three,
        Four,
        Five
    }

    public enum eLicenseType
    {
        A1 = 1,
        AA,
        AB,
        C
    }

    public enum eVehicleGarageStatus
    {
        InRepair = 1,
        Repaired,
        Paid
    }

    public enum eTypeOfVehicle
    {
        FuelMotorcycle = 1,
        ElectricMotorcycle,
        FuelCar,
        ElectricCar,
        Truck
    }
}
