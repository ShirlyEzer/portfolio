using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInformation
    {
        private string m_VehicleOwnerName = string.Empty;
        private string m_VehicleOwnerPhone = string.Empty;
        private eVehicleGarageStatus m_VehicleGarageStatus;

        public eVehicleGarageStatus VehicleGarageStatus
        {
            get { return m_VehicleGarageStatus; }
            set { m_VehicleGarageStatus = value; }
        }

        public string VehicleOwnerName
        {
            get { return m_VehicleOwnerName; }
            set { m_VehicleOwnerName = value; }
        }

        public string VehicleOwnerPhone
        {
            get { return m_VehicleOwnerPhone; }
            set { m_VehicleOwnerPhone = value; }
        }

        public VehicleInformation()
        {
            VehicleGarageStatus = eVehicleGarageStatus.InRepair;
        }

        /// <summary>
        /// This method collects a general vehicle information
        /// </summary>
        /// <returns>string with general vehicle information</returns>
        public override string ToString()
        {
            string vehicleInformationToString = string.Format(
@"Garage information about the vehicle :
Vehicle owner name - {0}
Vehicle owner phone - {1} 
Vehicle status - {2} ",
                      VehicleOwnerName,
                      VehicleOwnerPhone,
                      VehicleGarageStatus.ToString());

            return vehicleInformationToString;
        }
    }
}
