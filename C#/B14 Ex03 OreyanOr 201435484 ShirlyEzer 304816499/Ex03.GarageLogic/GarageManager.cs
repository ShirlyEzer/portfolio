using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private List<Vehicle> m_VehicleCollection = new List<Vehicle>(0);
        private Vehicle m_Vehicle = null;

        public List<Vehicle> VehicleCollection
        {
            get { return m_VehicleCollection; }
            set { m_VehicleCollection = value; }
        }

        private void insertDetailsOfNewVehicle(
            string i_InputVehicleModelName, 
            string i_InputWheelManufacturerName, 
            float i_InputVehicleCurrentAmountOfEnergy, 
            float i_InputWheelCurrentAirPressure)
        {
            m_Vehicle.VehicleModelName = i_InputVehicleModelName;
            m_Vehicle.SetManufacturerNameOfWheelInListOfWheels(i_InputWheelManufacturerName);
            m_Vehicle.SetAirPressureOfWheelInListOfWheels(i_InputWheelCurrentAirPressure);
            m_Vehicle.VehicleEnergySource.CurrentAmountOfEnergy = i_InputVehicleCurrentAmountOfEnergy;
            m_Vehicle.SetCurrentAmountEnergySourceInPercentage();
        }

        public void InsertDetailsOfNewTruck(
            string i_InputVehicleModelName, 
            string i_InputWheelManufacturerName, 
            float i_InputVehicleCurrentAmountOfEnergy, 
            float i_InputWheelCurrentAirPressure, 
            float i_InputTruckWeightCarryingCapacity, 
            bool i_InputIsTruckHazardousMaterials)
        {
            Truck newTruck = m_Vehicle as Truck;

            if (newTruck != null)
            {
                newTruck.IsCarryingHazardousMaterials = i_InputIsTruckHazardousMaterials;
                newTruck.WeightCarryingCapacity = i_InputTruckWeightCarryingCapacity;
                insertDetailsOfNewVehicle(i_InputVehicleModelName, i_InputWheelManufacturerName, i_InputVehicleCurrentAmountOfEnergy, i_InputWheelCurrentAirPressure);
            }
            else
            {
                throw new ArgumentException("The vehicle is not a Truck");
            }
        }

        public void InsertDetailsOfNewMotorcycle(
            string i_InputVehicleModelName, 
            string i_InputWheelManufacturerName, 
            float i_InputVehicleCurrentAmountOfEnergy, 
            float i_InputWheelCurrentAirPressure, 
            eLicenseType i_InputMotorcycleLicenseType, 
            int i_InputMotorcycleEngineCapacity)
        {
            Motorcycle newMotorcycle = m_Vehicle as Motorcycle;

            if (newMotorcycle != null)
            {
                newMotorcycle.LicenseType = i_InputMotorcycleLicenseType;
                newMotorcycle.EngineCapacity = i_InputMotorcycleEngineCapacity;
                insertDetailsOfNewVehicle(i_InputVehicleModelName, i_InputWheelManufacturerName, i_InputVehicleCurrentAmountOfEnergy, i_InputWheelCurrentAirPressure);
            }
            else
            {
                throw new ArgumentException("The vehicle is not a Motorcycle");
            }
        }

        public void InsertDetailsOfNewCar(
            string i_InputVehicleModelName, 
            string i_InputWheelManufacturerName, 
            float i_InputVehicleCurrentAmountOfEnergy, 
            float i_InputWheelCurrentAirPressure, 
            eColor i_InputCarColor,
            eAmountOfDoors i_InputCarDoorsNumber)
        {
            Car newCar = m_Vehicle as Car;

            if (newCar != null)
            {
                newCar.ColorOfCar = i_InputCarColor;
                newCar.AmountOfDoorsInCar = i_InputCarDoorsNumber;
                insertDetailsOfNewVehicle(i_InputVehicleModelName, i_InputWheelManufacturerName, i_InputVehicleCurrentAmountOfEnergy, i_InputWheelCurrentAirPressure);
            }
            else
            {
                throw new ArgumentException("The vehicle is not a Car");
            }
        }

        private Vehicle searchVehicleByLicenseNumber(string i_VehicleLicenseNumber)
        {
            Vehicle searchedVehicle = null;

            foreach (Vehicle vehicle in VehicleCollection)
            {
                if (vehicle.VehicleLicenseNumber == i_VehicleLicenseNumber)
                {
                    searchedVehicle = vehicle;
                    break;
                }
            }

            if (searchedVehicle == null)
            {
                throw new Exception("Vehicle with the license number " + i_VehicleLicenseNumber + " does not exist in the garage");
            }

            return searchedVehicle;
        }

        public bool InsertNewVehicleToGarage(eTypeOfVehicle i_VehicleType, string i_LicenseNumber)
        {
            bool flag = false;
            
            try
            {
                m_Vehicle = searchVehicleByLicenseNumber(i_LicenseNumber);
                UpdateStatusOfVehicle(m_Vehicle.VehicleLicenseNumber, eVehicleGarageStatus.InRepair);
            }
            catch (Exception)
            {
                m_Vehicle = CreateVehicles.CreateNewVehicle(i_VehicleType);
                m_Vehicle.VehicleLicenseNumber = i_LicenseNumber;
                VehicleCollection.Add(m_Vehicle);
                flag = true;
            }

            return flag;
        }

        public List<string> GetVehicleLicenseNumbersInGarageFilteredByStatus(eVehicleGarageStatus i_VehicleGarageStatus)
        {
            List<string> vehicleLicenseNumbersCollection = new List<string>(0);

            foreach (Vehicle vehicle in VehicleCollection)
            {
                if (vehicle.VehicleInformation.VehicleGarageStatus == i_VehicleGarageStatus)
                {
                    vehicleLicenseNumbersCollection.Add(vehicle.VehicleLicenseNumber);
                }
            }

            if (vehicleLicenseNumbersCollection.Count == 0)
            {
                throw new Exception("Does not exist any vehicle in status " + i_VehicleGarageStatus.ToString());
            }

            return vehicleLicenseNumbersCollection;
        }

        public List<string> GetVehicleLicenseNumbersInGarage()
        {
            List<string> vehicleLicenseNumbersCollection = new List<string>(0);

            foreach (Vehicle vehicle in VehicleCollection)
            {
                vehicleLicenseNumbersCollection.Add(vehicle.VehicleLicenseNumber);
            }

            if (vehicleLicenseNumbersCollection.Count == 0)
            {
                throw new Exception("Does not exist any vehicle in garage");
            }

            return vehicleLicenseNumbersCollection;
        }

        public void UpdateStatusOfVehicle(string i_VehicleLicenseNumber, eVehicleGarageStatus i_VehicleGarageStatus)
        {
            Vehicle vehicleStatusUpdate = null;

            vehicleStatusUpdate = searchVehicleByLicenseNumber(i_VehicleLicenseNumber);
            vehicleStatusUpdate.VehicleInformation.VehicleGarageStatus = i_VehicleGarageStatus;
        }

        public void InflateVehicleWheelsToMax(string i_VehicleLicenseNumber)
        {
            Vehicle vehicleInflateWheels = null;

            vehicleInflateWheels = searchVehicleByLicenseNumber(i_VehicleLicenseNumber);
            vehicleInflateWheels.SetAirPressureOfWheelInListOfWheels(vehicleInflateWheels.Wheels[0].MaxAirPressure - vehicleInflateWheels.Wheels[0].CurrentAirPressure);
        }

        public void RefuelingVehicle(string i_VehicleLicenseNumber, eFuelType i_FuelType, float i_AmountOfFuelToAdd)
        {
            Vehicle refueledVehicle = null;
            Fuel fuel = new Fuel();

            refueledVehicle = searchVehicleByLicenseNumber(i_VehicleLicenseNumber);
            fuel.FuelType = i_FuelType;
            try
            {
                refueledVehicle.LoadEnergy(i_AmountOfFuelToAdd, fuel);
            }
            catch (FormatException)
            {
                throw new FormatException("The vehicle's energy source is not fuel");
            }
        }

        public void RechargeVehicle(string i_VehicleLicenseNumber, float i_AmountOfElectrictyToAdd)
        {
            Vehicle rechargedVehicle = null;
            ElectricBattery electricBattery = new ElectricBattery();

            rechargedVehicle = searchVehicleByLicenseNumber(i_VehicleLicenseNumber);
            try
            {
                rechargedVehicle.LoadEnergy(i_AmountOfElectrictyToAdd / 60, electricBattery);
            }
            catch (FormatException)
            {
                throw new FormatException("The vehicle's energy source is not electric battery");
            }
        }

        public void CheckElectricBatteryUserInput(float i_BatteryTimeLeftInHours)
        {
            ElectricBattery electricBatteryEnergySource = m_Vehicle.VehicleEnergySource as ElectricBattery;

            if (electricBatteryEnergySource != null)
            {
                if (m_Vehicle.VehicleEnergySource.MaxAmountOfEnergy < i_BatteryTimeLeftInHours)
                {
                    throw new ValueOutOfRangeException(string.Format("Can not set the current amount of electricty, it is above the max {0}", m_Vehicle.VehicleEnergySource.MaxAmountOfEnergy), 0f, m_Vehicle.VehicleEnergySource.MaxAmountOfEnergy);
                }

                if (i_BatteryTimeLeftInHours < 0)
                {
                    throw new ValueOutOfRangeException(string.Format("Can not set the current amount of electricty, it is less then 0"), 0f, m_Vehicle.VehicleEnergySource.MaxAmountOfEnergy);
                }
            }
        }

        public void CheckCurrentAmontOfFuelUserInput(float i_CurrentAmontOfFuelInLiters)
        {
            Fuel fuelEnergySource = m_Vehicle.VehicleEnergySource as Fuel;

            if (fuelEnergySource != null)
            {
                if (m_Vehicle.VehicleEnergySource.MaxAmountOfEnergy < i_CurrentAmontOfFuelInLiters)
                {
                    throw new ValueOutOfRangeException(string.Format("Can not set the current amount of fuel, it is above the max {0}", m_Vehicle.VehicleEnergySource.MaxAmountOfEnergy), 0f, m_Vehicle.VehicleEnergySource.MaxAmountOfEnergy);
                }

                if (i_CurrentAmontOfFuelInLiters < 0)
                {
                    throw new ValueOutOfRangeException(string.Format("Can not set the current amount of fuel, it is less then 0"), 0f, m_Vehicle.VehicleEnergySource.MaxAmountOfEnergy);
                }
            }
        }

        public void CheckCurrentAmontOfAirPressureOfWheelUserInput(float i_CurrentAmontOfAirPressureOfWheel)
        {
            if (m_Vehicle.Wheels[0].MaxAirPressure < i_CurrentAmontOfAirPressureOfWheel)
            {
                throw new ValueOutOfRangeException(string.Format("Can not set the current amount of air, it is above the max {0}", m_Vehicle.Wheels[0].MaxAirPressure), 0f, m_Vehicle.Wheels[0].MaxAirPressure);
            }

            if (i_CurrentAmontOfAirPressureOfWheel < 0)
            {
                throw new ValueOutOfRangeException(string.Format("Can not set the current amount of air, it is less then 0"), 0f, m_Vehicle.Wheels[0].MaxAirPressure);
            }
        }

        public string DisplayVehicleDetailes(string i_VehicleLicenseNumber)
        {
            m_Vehicle = searchVehicleByLicenseNumber(i_VehicleLicenseNumber);
            return m_Vehicle.ToString();
        }

        public void SetVehicleGeneralInformation(string i_VehicleOwnerName, string i_VehicleOwnerPhone, eVehicleGarageStatus i_GarageStatus)
        {
            m_Vehicle.VehicleInformation.VehicleGarageStatus = i_GarageStatus;
            m_Vehicle.VehicleInformation.VehicleOwnerName = i_VehicleOwnerName;
            m_Vehicle.VehicleInformation.VehicleOwnerPhone = i_VehicleOwnerPhone;
        }
    }
}