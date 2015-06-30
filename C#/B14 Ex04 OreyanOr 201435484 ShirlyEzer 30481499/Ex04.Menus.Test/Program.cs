namespace Ex04.Menus.Test
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Ex04.Menus.Interfaces;
    using Ex04.Menus.Delegates;

    public class Program
    {
        public static void Main()
        {
            RunDelegateMenu();
            RunInterfaceMenu();
        }

        private static void RunDelegateMenu()
        {
            Delegates.MasterItem mainMenuDelegate = new Delegates.MasterItem("Main Menu - Delegate");
            Delegates.MainMenu delegatesMainMenu = new Delegates.MainMenu(mainMenuDelegate);
            Delegates.MasterItem timeMenuDelegate = new Delegates.MasterItem("Time Menu");
            Delegates.LeafItem wordsCounterItemDelegate = new Delegates.LeafItem("Words Counter");
            Delegates.LeafItem showVersionItemDelegate = new Delegates.LeafItem("Show Version");
            Delegates.LeafItem showTimeItemDelegate = new Delegates.LeafItem("Show Time");
            Delegates.LeafItem showDateItemDelegate = new Delegates.LeafItem("Show Date");

            wordsCounterItemDelegate.DoAction += WordsCounterMethod;
            showVersionItemDelegate.DoAction += ShowVersionMethod;
            showTimeItemDelegate.DoAction += ShowTimeMethod;
            showDateItemDelegate.DoAction += ShowDateMethod;
            timeMenuDelegate.AddItem(showTimeItemDelegate);
            timeMenuDelegate.AddItem(showDateItemDelegate);
            mainMenuDelegate.AddItem(timeMenuDelegate);
            mainMenuDelegate.AddItem(wordsCounterItemDelegate);
            mainMenuDelegate.AddItem(showVersionItemDelegate);
            delegatesMainMenu.Show();
        }

        private static void RunInterfaceMenu()
        {
            Interfaces.MasterItem iMainMenu = new Interfaces.MasterItem("Main Menu - Interface");
            Interfaces.MainMenu interfaceMainMenu = new Interfaces.MainMenu(iMainMenu);
            Interfaces.MasterItem iTimeMenu = new Interfaces.MasterItem("Time Menu");

            Interfaces.LeafItem iWordsCounterItem = new Interfaces.LeafItem("Words Counter", new TestStartAction());
            Interfaces.LeafItem iShowVersionItem = new Interfaces.LeafItem("Show Version", new TestStartAction());
            Interfaces.LeafItem iShowTimeItem = new Interfaces.LeafItem("Show Time", new TestStartAction());
            Interfaces.LeafItem iShowDateItem = new Interfaces.LeafItem("Show Date", new TestStartAction());

            iTimeMenu.AddItem(iShowTimeItem);
            iTimeMenu.AddItem(iShowDateItem);
            iMainMenu.AddItem(iTimeMenu);
            iMainMenu.AddItem(iWordsCounterItem);
            iMainMenu.AddItem(iShowVersionItem);
            interfaceMainMenu.Show();
        }

        private static void ShowTimeMethod()
        {
            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss tt"));
        }

        private static void ShowDateMethod()
        {
            Console.WriteLine(DateTime.Now.ToShortDateString());
        }

        private static void WordsCounterMethod()
        {
            string sentence = string.Empty;
            int numOfWordsInSentence = 0;
            char[] sep = { ' ' };
            string[] wordsInSentence = null;

            Console.WriteLine("Please enter a sentence");
            sentence = Console.ReadLine();
            wordsInSentence = sentence.Split(sep);
            numOfWordsInSentence = wordsInSentence.Length;
            Console.WriteLine("There is " + numOfWordsInSentence + " words in the sentence");
        }

        private static void ShowVersionMethod()
        {
            Console.WriteLine("Version: 14.2.4.0");
        }

        /// <summary>
        /// This class implements a method of the interface IStartActionHandler
        /// </summary>
        private class TestStartAction : IStartActionHandler
        {
            public void DoAction(Interfaces.LeafItem i_LeafItem)
            {
                switch (i_LeafItem.ItemName)
                {
                    case "Show Time":
                        ShowTimeMethod();
                        break;
                    case "Show Date":
                        ShowDateMethod();
                        break;
                    case "Show Version":
                        ShowVersionMethod();
                        break;
                    case "Words Counter":
                        WordsCounterMethod();
                        break;
                }
            }
        }
    }
}
