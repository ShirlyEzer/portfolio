using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    internal class GarageUI
    {
        private eColor m_ColorOfCar;
        private eAmountOfDoors m_NumberOfDoorsInCar;
        private eTypeOfVehicle m_TypeOfVehicle;
        private eVehicleGarageStatus m_VehicleGarageStatus;
        private eLicenseType m_LicenseTypeOfMotorcycle;
        private eFuelType m_VehicleFuelType;
        private GarageManager m_GarageManager = new GarageManager();
        private bool m_ExitApplication = false;

        private enum eMainMenuOptions
        {
            AddNewVehicleToTheGarage = 1,
            DisplayLiceneNumbersOfVehiclesInTheGarage,
            DisplayVehiclesLicenseNumberInTheGarageBySpecificStatus,
            UpdateVehicleStatus,
            InflatingWheelsToMaxAirPressure,
            RefillFuelVehicle,
            RechargeElectricVehicle,
            DisplayFullDetailsOfVehicle,
            ExitApplication
        }

        private void MenuOptions()
        {
            bool isValidMenuOptionInput = true;

            do
            {
                try
                {
                    Console.WriteLine(
@"
Menu

1. Insert a new vehicle
2. Display all vehicles license number in the garage
3. Display vehicles license number in the garage by specific status
4. Change a vehicle status
5. Inflate wheels air of a car to maximun
6. Refill a fuel vehicle
7. Recharge electric vehicle
8 .Display full details of vehicle
9. Exit");

                    string menuOptionsStr = Console.ReadLine();
                    isValidMenuOptionInput = true;

                    eMainMenuOptions menuOptions = (eMainMenuOptions)Enum.Parse(typeof(eMainMenuOptions), menuOptionsStr);

                    switch (menuOptions)
                    {
                        case eMainMenuOptions.AddNewVehicleToTheGarage:
                            insertNewVehicleToTheGarage();
                            break;
                        case eMainMenuOptions.DisplayLiceneNumbersOfVehiclesInTheGarage:
                            displayLiceneNumbersOfVehiclesInTheGarage();
                            break;
                        case eMainMenuOptions.DisplayVehiclesLicenseNumberInTheGarageBySpecificStatus:
                            displayVehiclesLicenseNumberInTheGarageBySpecificStatus();
                            break;
                        case eMainMenuOptions.UpdateVehicleStatus:
                            updateVehicleStatus();
                            break;
                        case eMainMenuOptions.InflatingWheelsToMaxAirPressure:
                            inflateWheelsToMax();
                            break;
                        case eMainMenuOptions.RefillFuelVehicle:
                            refillFuelVehicle();
                            break;
                        case eMainMenuOptions.RechargeElectricVehicle:
                            rechargeElectricVehicle();
                            break;
                        case eMainMenuOptions.DisplayFullDetailsOfVehicle:
                            displayFullDetailsOfVehicle();
                            break;
                        case eMainMenuOptions.ExitApplication:
                            m_ExitApplication = true;
                            break;
                        default:
                            isValidMenuOptionInput = false;
                            Console.WriteLine("Invalid menu option input. choose a correct number again");
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    isValidMenuOptionInput = false;
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    isValidMenuOptionInput = false;
                    Console.WriteLine(ex.Message);
                }
            }
            while (!isValidMenuOptionInput);
        }

        private string getUserStringInput(string i_MessageToPrint)
        {
            bool isValidInput = true;
            string userInputStr = string.Empty;

            do
            {
                Console.Write(i_MessageToPrint);
                userInputStr = Console.ReadLine();

                if (userInputStr == string.Empty)
                {
                    isValidInput = false;
                    Console.WriteLine("Invalid input");
                }
                else
                {
                    isValidInput = true;
                }
            }
            while (!isValidInput);

            return userInputStr;
        }

        private int getUserIntInput(string i_MessageStr)
        {
            bool validInput = true;
            int intValueToReturn = 0;
            string userInputStr = string.Empty;
            bool isInt = true;

            do
            {
                Console.Write(i_MessageStr);
                userInputStr = Console.ReadLine();
                isInt = int.TryParse(userInputStr, out intValueToReturn);
                if (!isInt)
                {
                    Console.WriteLine("Invalid input");
                    validInput = false;
                }
                else
                {
                    validInput = true;
                }
            }
            while (!validInput);

            return intValueToReturn;
        }

        private float getUserFloatInput(string i_MessageStr)
        {
            bool validInput = true;
            float floatValueToReturn;
            string userInputStr = string.Empty;
            bool isFloat = true;

            do
            {
                Console.Write(i_MessageStr);
                userInputStr = Console.ReadLine();
                isFloat = float.TryParse(userInputStr, out floatValueToReturn);
                if (!isFloat)
                {
                    Console.WriteLine("Invalid input");
                    validInput = false;
                }
                else
                {
                    validInput = true;
                }
            }
            while (!validInput);

            return floatValueToReturn;
        }

        private bool getUserBoolInput(string i_MessageStr)
        {
            bool isValidInput = true;
            bool boolValueToReturn = true;
            string userInputStr = string.Empty;

            do
            {
                Console.Write(i_MessageStr);
                userInputStr = Console.ReadLine();
                boolValueToReturn = bool.TryParse(userInputStr, out boolValueToReturn);
                if (!boolValueToReturn)
                {
                    Console.WriteLine("Invalid input");
                    isValidInput = false;
                }
                else
                {
                    isValidInput = true;
                }
            }
            while (!isValidInput);

            return boolValueToReturn;
        }

        private string getModelNameOfVehicle()
        {
            return getUserStringInput("Please enter the vehicle model name: ");
        }

        private string getLicenseNumberOfVehicle()
        {
            return getUserStringInput("Please enter the vehicle license number: ");
        }

        private string getManufacturerNameOfWheel()
        {
            return getUserStringInput("Please enter the manufacturer name of wheel: ");
        }

        private string getVehicleOwnerName()
        {
            return getUserStringInput("Please enter the vehicle owner name: ");
        }

        private string getVehicleOwnerPhone()
        {
            return getUserStringInput("Please enter the vehicle owner phone number: ");
        }

        private object parseEnumUserInput(string i_MessageToPrint, Type target)
        {
            object enumUserInput = null;
            string menuInputStr = null;

            Console.WriteLine(i_MessageToPrint);
            menuInputStr = Console.ReadLine();

            if (target.BaseType == typeof(Enum))
            {
                enumUserInput = Enum.Parse(target, menuInputStr);
            }

            return enumUserInput;
        }

        private void getCarColor()
        {
            bool isValidColor = true;

            do
            {
                try
                {
                    m_ColorOfCar = (eColor)parseEnumUserInput(
@"Please choose the car color from the menu:
1. Red
2. Yellow
3. black
4. Silver",
typeof(eColor));

                    isValidColor = Enum.IsDefined(typeof(eColor), m_ColorOfCar);
                    if (!isValidColor)
                    {
                        Console.WriteLine("Invalid color input");
                    }
                }
                catch (ArgumentException ex)
                {
                    isValidColor = false;
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    isValidColor = false;
                    Console.WriteLine(ex.Message);
                }
            }
            while (!isValidColor);
        }

        private void getNumberOfDoors()
        {
            bool isValidNumberOfDoors = true;

            do
            {
                try
                {
                    m_NumberOfDoorsInCar = (eAmountOfDoors)parseEnumUserInput(
@"Please choose the number of doors from the menu:
1. Two
2. Three
3. Four
4. Five",
typeof(eAmountOfDoors));

                    isValidNumberOfDoors = Enum.IsDefined(typeof(eAmountOfDoors), m_NumberOfDoorsInCar);
                    if (!isValidNumberOfDoors)
                    {
                        Console.WriteLine("Invalid number of doors input");
                    }
                }
                catch (ArgumentException ex)
                {
                    isValidNumberOfDoors = false;
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    isValidNumberOfDoors = false;
                    Console.WriteLine(ex.Message);
                }
            }
            while (!isValidNumberOfDoors);
        }

        private void getVehicleType()
        {
            bool isValidVehicleType = true;

            do
            {
                try
                {
                    m_TypeOfVehicle = (eTypeOfVehicle)parseEnumUserInput(
@"Please enter the vehicle type by choosing a number from the menu:
1. Fuel Motorcycle
2. Electric Motorcycle
3. Fuel Car
4. Electric Car
5. Truck ",
typeof(eTypeOfVehicle));

                    isValidVehicleType = Enum.IsDefined(typeof(eTypeOfVehicle), m_TypeOfVehicle);
                    if (!isValidVehicleType)
                    {
                        Console.WriteLine("Invalid vehicle type input");
                    }
                }
                catch (ArgumentException ex)
                {
                    isValidVehicleType = false;
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    isValidVehicleType = false;
                    Console.WriteLine(ex.Message);
                }
            }
            while (!isValidVehicleType);
        }

        private void getVehicleGarageStatus()
        {
            bool isValidVehicleStatus = true;

            do
            {
                try
                {
                    m_VehicleGarageStatus = (eVehicleGarageStatus)parseEnumUserInput(
@"Please enter the new vehicle garage status by choosing a number from the menu:
1. InRepair
2. Repaired
3. Paid",
typeof(eVehicleGarageStatus));

                    isValidVehicleStatus = Enum.IsDefined(typeof(eVehicleGarageStatus), m_VehicleGarageStatus);
                    if (!isValidVehicleStatus)
                    {
                        Console.WriteLine("Invalid vehicle type input");
                    }
                }
                catch (ArgumentException ex)
                {
                    isValidVehicleStatus = false;
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    isValidVehicleStatus = false;
                    Console.WriteLine(ex.Message);
                }
            }
            while (!isValidVehicleStatus);
        }

        private void getMotorcycleLicenseType()
        {
            bool isValidMenuInput = true;

            do
            {
                try
                {
                    m_LicenseTypeOfMotorcycle = (eLicenseType)parseEnumUserInput(
@"Please enter the new motorcycle License Type by choosing a number from the menu:
1. A
2. A1
3. AA
4. B1",
typeof(eLicenseType));

                    isValidMenuInput = Enum.IsDefined(typeof(eLicenseType), m_LicenseTypeOfMotorcycle);
                    if (!isValidMenuInput)
                    {
                        Console.WriteLine("Invalid license type input");
                    }
                }
                catch (ArgumentException ex)
                {
                    isValidMenuInput = false;
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    isValidMenuInput = false;
                    Console.WriteLine(ex.Message);
                }
            }
            while (!isValidMenuInput);
        }

        private void getVehicleFuelType()
        {
            bool isValidMenuInput = true;

            do
            {
                try
                {
                    m_VehicleFuelType = (eFuelType)parseEnumUserInput(
@"Please enter the Fuel Type by choosing a number from the menu:
1. Octan95
2. Octan96
3. Octan98
4. Soler",
         typeof(eLicenseType));

                    isValidMenuInput = Enum.IsDefined(typeof(eFuelType), m_VehicleFuelType);
                    if (!isValidMenuInput)
                    {
                        Console.WriteLine("Invalid Fuel type input");
                    }
                }
                catch (ArgumentException ex)
                {
                    isValidMenuInput = false;
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    isValidMenuInput = false;
                    Console.WriteLine(ex.Message);
                }
            }
            while (!isValidMenuInput);
        }

        private int getEngineCapacityOfMotorcycle()
        {
            return getUserIntInput("Please enter the Capacity of the motorcycle: ");
        }

        private float getCurrentAmontOfFuelInLiters()
        {
            bool isValidInput = true;
            float currentAmontOfFuelInLiters = 0;

            do
            {
                try
                {
                    isValidInput = true;
                    currentAmontOfFuelInLiters = getUserFloatInput("Please enter the amount of current fuel in liters: ");
                    m_GarageManager.CheckCurrentAmontOfFuelUserInput(currentAmontOfFuelInLiters);
                }
                catch (ValueOutOfRangeException ex)
                {
                    isValidInput = false;
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    isValidInput = false;
                    Console.WriteLine(ex.Message);
                }
            }
            while (!isValidInput);

            return currentAmontOfFuelInLiters;
        }

        private float getBatteryTimeInHours()
        {
            bool isValidInput = true;
            float batteryTimeInHours = 0;

            do
            {
                try
                {
                    isValidInput = true;
                    batteryTimeInHours = getUserFloatInput("Please enter the amount of battery time in hours: ");
                    m_GarageManager.CheckElectricBatteryUserInput(batteryTimeInHours);
                }
                catch (ValueOutOfRangeException ex)
                {
                    isValidInput = false;
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    isValidInput = false;
                    Console.WriteLine(ex.Message);
                }
            }
            while (!isValidInput);

            return batteryTimeInHours;
        }

        private float getBatteryTimeInMinutes()
        {
            bool isValidInput = true;
            float batteryTimeInMinutes = 0;

            do
            {
                try
                {
                    isValidInput = true;
                    batteryTimeInMinutes = getUserFloatInput("Please enter the amount of battery time in minutes: ");
                    m_GarageManager.CheckElectricBatteryUserInput(batteryTimeInMinutes / 60);
                }
                catch (ValueOutOfRangeException ex)
                {
                    isValidInput = false;
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    isValidInput = false;
                    Console.WriteLine(ex.Message);
                }
            }
            while (!isValidInput);

            return batteryTimeInMinutes;
        }

        private float getCurrentAmountOfAirPressureOfWheel()
        {
            bool isValidInput = true;
            float i_CurrentAmountOfAirPressureOfWheel = 0;

            do
            {
                try
                {
                    isValidInput = true;
                    i_CurrentAmountOfAirPressureOfWheel = getUserFloatInput("Please enter the current amount of air pressure of wheel: ");
                    m_GarageManager.CheckCurrentAmontOfAirPressureOfWheelUserInput(i_CurrentAmountOfAirPressureOfWheel);
                }
                catch (ValueOutOfRangeException ex)
                {
                    isValidInput = false;
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    isValidInput = false;
                    Console.WriteLine(ex.Message);
                }
            }
            while (!isValidInput);

            return i_CurrentAmountOfAirPressureOfWheel;
        }

        private float getWeightCarryingCapacity()
        {
            return getUserFloatInput("Please enter the weight carrying capacity of Truck: ");
        }

        private bool getIsCarryingHazardousMaterials()
        {
            return getUserBoolInput("Please enter true or false, if the truck carrying hazardous materials: ");
        }

        private void insertNewVehicleToTheGarage()
        {
            bool isVehicleCreated = false;
            string vehicleLicenseNumber = string.Empty;

            vehicleLicenseNumber = getLicenseNumberOfVehicle();
            getVehicleType();
            isVehicleCreated = m_GarageManager.InsertNewVehicleToGarage(m_TypeOfVehicle, vehicleLicenseNumber);
            if (isVehicleCreated != false)
            {
                setDetailesOfTheNewVehicle(m_TypeOfVehicle);
            }
            else
            {
                Console.WriteLine("The vehicle exist in the garage already, and is status updated to In Repair");
            }
        }

        private void setDetailesOfTheNewVehicle(eTypeOfVehicle i_TypeOfVehicle)
        {
            string vehicleModelName = getModelNameOfVehicle();
            string wheelManufacturerName = getManufacturerNameOfWheel();
            float wheelCurrentAmountOfAirPressure = getCurrentAmountOfAirPressureOfWheel();
            float currentAmountOfEnergy = 0;
            float truckWeightCarryingCapacity = 0;
            bool truckIsCarryingHazardousMaterials = true;

            switch (i_TypeOfVehicle)
            {
                case eTypeOfVehicle.FuelMotorcycle:
                    currentAmountOfEnergy = getCurrentAmontOfFuelInLiters();
                    goto label1;
                case eTypeOfVehicle.ElectricMotorcycle:
                    currentAmountOfEnergy = getBatteryTimeInHours();
            label1: 
                    getMotorcycleLicenseType();
                    int motorcycleEngineCapacity = getEngineCapacityOfMotorcycle();
                    m_GarageManager.InsertDetailsOfNewMotorcycle(vehicleModelName, wheelManufacturerName, currentAmountOfEnergy, wheelCurrentAmountOfAirPressure, m_LicenseTypeOfMotorcycle, motorcycleEngineCapacity);
                    break;
                case eTypeOfVehicle.FuelCar:
                    currentAmountOfEnergy = getCurrentAmontOfFuelInLiters();
                    goto label2;
                case eTypeOfVehicle.ElectricCar: 
                    currentAmountOfEnergy = getBatteryTimeInHours();
            label2:
                    getCarColor();
                    getNumberOfDoors();
                    m_GarageManager.InsertDetailsOfNewCar(vehicleModelName, wheelManufacturerName, currentAmountOfEnergy, wheelCurrentAmountOfAirPressure, m_ColorOfCar, m_NumberOfDoorsInCar);
                    break;
                case eTypeOfVehicle.Truck:
                    currentAmountOfEnergy = getCurrentAmontOfFuelInLiters();
                    truckIsCarryingHazardousMaterials = getIsCarryingHazardousMaterials();
                    truckWeightCarryingCapacity = getWeightCarryingCapacity();
                    m_GarageManager.InsertDetailsOfNewTruck(vehicleModelName, wheelManufacturerName, currentAmountOfEnergy, wheelCurrentAmountOfAirPressure, truckWeightCarryingCapacity, truckIsCarryingHazardousMaterials);
                    break;
            }

            string vehicleOwnerName = getVehicleOwnerName();
            string vehicleOwnerPhone = getVehicleOwnerPhone();
            getVehicleGarageStatus();
            m_GarageManager.SetVehicleGeneralInformation(vehicleOwnerName, vehicleOwnerPhone, m_VehicleGarageStatus);
        }

        private void displayLiceneNumbersOfVehiclesInTheGarage()
        {
            try
            {
                List<string> listOfLicensenumbers = m_GarageManager.GetVehicleLicenseNumbersInGarage();

                foreach (string licenseNumber in listOfLicensenumbers)
                {
                    Console.WriteLine(licenseNumber);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void displayVehiclesLicenseNumberInTheGarageBySpecificStatus()
        {
            getVehicleGarageStatus();
            try
            {
                List<string> listOfLicensenumbers = m_GarageManager.GetVehicleLicenseNumbersInGarageFilteredByStatus(m_VehicleGarageStatus);

                foreach (string licenseNumber in listOfLicensenumbers)
                {
                    Console.WriteLine(licenseNumber);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void updateVehicleStatus()
        {
            string vehicleLicenseNumber = getLicenseNumberOfVehicle();

            getVehicleGarageStatus();
            m_GarageManager.UpdateStatusOfVehicle(vehicleLicenseNumber, m_VehicleGarageStatus);
            Console.WriteLine("Vehicle status is : " + m_VehicleGarageStatus.ToString());
        }

        private void inflateWheelsToMax()
        {
            string vehicleLicenseNumber = getLicenseNumberOfVehicle();

            m_GarageManager.InflateVehicleWheelsToMax(vehicleLicenseNumber);
            Console.WriteLine("The wheels inflated to max successfully!");
        }

        private void refillFuelVehicle()
        {
            string vehicleLicenseNumber = getLicenseNumberOfVehicle();
            float amountOfFuel = getCurrentAmontOfFuelInLiters();

            getVehicleFuelType();
            try
            {
                m_GarageManager.RefuelingVehicle(vehicleLicenseNumber, m_VehicleFuelType, amountOfFuel);
                Console.WriteLine("Vehicle refuled successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }   
        }

        private void rechargeElectricVehicle()
        {
            string vehicleLicenseNumber = getLicenseNumberOfVehicle();
            float amountOfElectricityToChargeInMinutes = getBatteryTimeInMinutes();

            try
            {
                m_GarageManager.RechargeVehicle(vehicleLicenseNumber, amountOfElectricityToChargeInMinutes);
                Console.WriteLine("Vehicle recharged successfully!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void displayFullDetailsOfVehicle()
        {
            string vehicleLicenseNumber = getLicenseNumberOfVehicle();

            try
            {
                Console.WriteLine(m_GarageManager.DisplayVehicleDetailes(vehicleLicenseNumber));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void StartGarageApplication()
        {
            Console.WriteLine("Welcome to Garage Management System");

            do
            {
                MenuOptions();
            }
            while (!m_ExitApplication);
        }
    }
}
