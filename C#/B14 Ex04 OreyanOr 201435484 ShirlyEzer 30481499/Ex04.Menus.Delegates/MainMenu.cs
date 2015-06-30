using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    /// <summary>
    /// Class represents the main menu
    /// </summary>
    public class MainMenu
    {
        private MasterItem m_RootItem;

        public MasterItem RootItem 
        { 
            get { return m_RootItem; }
            set { m_RootItem = value; }
        }

        public MainMenu(MasterItem i_MasterItem)
        {
            RootItem = i_MasterItem;
        }

        /// <summary>
        /// Method which runs a private recursive method for displaying the Main menu and the sub menus
        /// </summary>
        public void Show()
        {
            ShowMenu(m_RootItem, true);
        }

        /// <summary>
        /// Recursive method that displays the menu and its sub menus
        /// </summary>
        /// <param name="i_MasterItem">The Menu item paramater</param>
        /// <param name="i_IsThisMainMenu">Boolean that determines whether display Main menu or sub-menu</param>
        private void ShowMenu(MasterItem i_MasterItem, bool i_IsThisMainMenu)
        {
            int userInput = 0;

            while (true)
            {
                Console.Clear();
                PrintItems(i_MasterItem, i_IsThisMainMenu);
                userInput = GetUserInput(m_RootItem.MenuItemsList.Count);
                if (userInput == 0)
                {
                    return;
                }

                MasterItem masterItem = i_MasterItem.MenuItemsList[userInput - 1] as MasterItem;

                if (masterItem != null)
                {
                    ShowMenu(masterItem, false);
                }
                else
                {
                    Console.Clear();
                    LeafItem leafItem = i_MasterItem.MenuItemsList[userInput - 1] as LeafItem;
                    leafItem.RunMethod();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private void PrintItems(MasterItem i_MasterItem, bool i_IsThisMainMenu) 
        {
            StringBuilder menuListOfItemString = new StringBuilder();
            int index = 1;

            menuListOfItemString.AppendLine(i_MasterItem.ItemName);
            menuListOfItemString.AppendFormat("====================== {0}{1}", Environment.NewLine, Environment.NewLine);
            foreach (MenuItem item in i_MasterItem.MenuItemsList)
            {
                menuListOfItemString.AppendLine(index.ToString() + ") " + item.ItemName);
                index++;
            }

            menuListOfItemString.AppendFormat("Press 0 to {0} menu {1}", i_IsThisMainMenu ? "exit" : "back", Environment.NewLine);
            Console.WriteLine(menuListOfItemString.ToString());
        }

        /// <summary>
        /// Get number of item in menu method.
        /// Checks if the number is valid
        /// </summary>
        /// <param name="i_MenuSizeOfOptions">The amount of items in the menu</param>
        /// <returns>The input number</returns>
        private int GetUserInput(int i_MenuSizeOfOptions)
        {
            string userChoiseFromMenu = Console.ReadLine();
            int intUserChoiseFromMenu = 0;
            bool isValidInput = false;

            do
            {
                try
                {
                    intUserChoiseFromMenu = int.Parse(userChoiseFromMenu);

                    if (intUserChoiseFromMenu >= 0 && intUserChoiseFromMenu <= i_MenuSizeOfOptions)
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        isValidInput = false;
                        Console.WriteLine("You have entered a wrong value");
                        userChoiseFromMenu = Console.ReadLine();
                        intUserChoiseFromMenu = int.Parse(userChoiseFromMenu);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("You have entered a wrong value");
                    userChoiseFromMenu = Console.ReadLine();
                    isValidInput = false;
                }
            }
            while (!isValidInput);

            return intUserChoiseFromMenu;
        }
    }
}
