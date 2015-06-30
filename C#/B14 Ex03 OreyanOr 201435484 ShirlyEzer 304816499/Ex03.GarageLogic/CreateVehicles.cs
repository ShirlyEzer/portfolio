using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class CreateVehicles
    {
        public static Vehicle CreateNewVehicle(eTypeOfVehicle i_TypeOfVehicle)
        {
            Vehicle m_Vehicle = null;
            Fuel fuelSource = null;
            ElectricBattery electricSource = null;
            switch (i_TypeOfVehicle)
            {
                case eTypeOfVehicle.ElectricCar:
                    electricSource = new ElectricBattery(1.8f);
                    m_Vehicle = new Car(electricSource);
                    m_Vehicle.SetMaxAirPressureOfWheelInListOfWheels(32);
                    break;
                case eTypeOfVehicle.ElectricMotorcycle:
                    electricSource = new ElectricBattery(1.9f);
                    m_Vehicle = new Motorcycle(electricSource);
                    m_Vehicle.SetMaxAirPressureOfWheelInListOfWheels(29);
                    break;
                case eTypeOfVehicle.FuelCar:
                    fuelSource = new Fuel(48f);
                    fuelSource.FuelType = eFuelType.Octan95;
                    m_Vehicle = new Car(fuelSource);
                    m_Vehicle.SetMaxAirPressureOfWheelInListOfWheels(32);
                    break;
                case eTypeOfVehicle.FuelMotorcycle:
                    fuelSource = new Fuel(7.5f);
                    fuelSource.FuelType = eFuelType.Octan98;
                    m_Vehicle = new Motorcycle(fuelSource);
                    m_Vehicle.SetMaxAirPressureOfWheelInListOfWheels(29);
                    break;
                case eTypeOfVehicle.Truck:
                    fuelSource = new Fuel(190f);
                    fuelSource.FuelType = eFuelType.Soler;
                    m_Vehicle = new Truck(fuelSource);
                    m_Vehicle.SetMaxAirPressureOfWheelInListOfWheels(31);
                    break;
                default:
                    throw new ArgumentException("Invalid type of vehicle");
            }

            return m_Vehicle;
        }
    }
}
