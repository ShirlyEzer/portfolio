using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    internal class Program
    {
        public static void Main()
        {
            GarageUI garagUI = new GarageUI();
            garagUI.StartGarageApplication();

            Console.WriteLine("Good bye!");
        }
    }
}
