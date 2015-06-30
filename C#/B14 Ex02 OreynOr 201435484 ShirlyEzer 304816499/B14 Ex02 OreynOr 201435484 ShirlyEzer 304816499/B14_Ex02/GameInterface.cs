using System;
using System.Collections.Generic;
using System.Text;

namespace B14_Ex02
{
    public class GameInterface
    {
        private GameLogic m_GameLogic = new GameLogic();

        private void getInfoAboutThePlayers()
        {
            int choise;
            string choiseString;
            bool isIntOnly;

            Console.WriteLine("Hellow!\nWelcome to the memory game :)\nPlease enter your name:");
            m_GameLogic.PlayerNumber1.PlayerName = Console.ReadLine();
            Console.WriteLine("Against Who you want to play with?\n 1. player\n 2. computer");
            choiseString = Console.ReadLine();
            isIntOnly = int.TryParse(choiseString, out choise);
      Again:
            switch (choise)
            {
                case 1:
                    Console.WriteLine("You have choosen to play against another player");
                    Console.WriteLine("Please enter the name of the second player");
                    m_GameLogic.PlayerNumber2.PlayerName = Console.ReadLine();
                    m_GameLogic.GamePlayerVSPlayer = true;
                    break;
                case 2:
                    Console.WriteLine("You have choosen to play against the computer");
                    m_GameLogic.GameComputerVSPlayer = true;
                    break;
                default:
                    Console.WriteLine("You have entered wrong value, please try again:");
                    choiseString = Console.ReadLine();
                    isIntOnly = int.TryParse(choiseString, out choise);
                    goto Again;
             }
        }

        private void getInfoAboutTheBoard()
        {
            bool flag = false;
            char[] SizeOfBoardCharArray;

            Console.WriteLine("Please enter the size of board, in format rowsXcols");
            Console.WriteLine("Please notify the board should contain even number of slots");
            Console.WriteLine("The max number for row or col is 6)");
            m_GameLogic.BoardGame = new MemoryBoard();
            while (flag == false)
            {
                string SizeOfBoardString = Console.ReadLine();
                SizeOfBoardCharArray = SizeOfBoardString.ToCharArray();
                if (SizeOfBoardCharArray.Length != 3)
                {
                    Console.WriteLine("You have entered values in wrong format, Please enter the size of board, in format rowsXcols");
                }
                else
                {
                    if (m_GameLogic.CheckSizeValuesOfMatrix((int)char.GetNumericValue(SizeOfBoardCharArray[0]), (int)char.GetNumericValue(SizeOfBoardCharArray[2])) == true)
                    {
                        m_GameLogic.BoardGame.CreateBoard();
                        flag = true;
                    }
                    else
                    {
                        Console.WriteLine("You have entered wrong values, Please notify the board should contain even number of slots");
                    }
                }
            }

            Console.WriteLine("Let's start the game, Good luck! :)");
            printingBoardMethod(0);
        } 

        private void printBetweenLines()
        {
            Console.Write("   ");
            for (int i = 0; i < m_GameLogic.BoardGame.ColOfBoard; i++)
            {
                Console.Write("====");
            }

            Console.WriteLine("=");
        }

        private void printingBoardMethod(int i_CountOfCardToDisplay, params string[] i_CardsArrayToDisplay)
        {
            int firstCardRowNumber = 0;
            int firstCardColNumber = 0;
            int secondCardRowNumber = 0;
            int secondCardColNumber = 0;
            char alphabetIndex = 'A';
            bool isDisplayCardFlag = false;

            if (i_CountOfCardToDisplay >= 1)
            {
                m_GameLogic.RevealCard(i_CardsArrayToDisplay[0], ref firstCardRowNumber, ref firstCardColNumber);
                if (i_CountOfCardToDisplay == 2)
                {
                    m_GameLogic.RevealCard(i_CardsArrayToDisplay[1], ref secondCardRowNumber, ref secondCardColNumber);
                }
            }

            Console.Write("  ");
            for (int i = 0; i < m_GameLogic.BoardGame.ColOfBoard; i++)
            {
                Console.Write("   ");
                Console.Write(alphabetIndex);
                alphabetIndex++;
            }

            Console.WriteLine();
            for (int i = 1; i <= m_GameLogic.BoardGame.RowOfBoard; i++)
            {
                printBetweenLines();
                Console.Write(" ");
                Console.Write(i);
                Console.Write(" ");
                for (int j = 0; j < m_GameLogic.BoardGame.ColOfBoard; j++)
                {
                    Console.Write("|");
                    if (m_GameLogic.BoardGame.CountOfMatchingCard[m_GameLogic.BoardGame.Board[i - 1, j] - 'L'] == 1)
                    {
                        isDisplayCardFlag = true;
                    }

                    if (i_CountOfCardToDisplay >= 1)
                    {
                        if (firstCardRowNumber == i - 1 && firstCardColNumber == j)
                        {
                            isDisplayCardFlag = true;
                        }

                        if (i_CountOfCardToDisplay == 2 && secondCardRowNumber == i - 1 && secondCardColNumber == j)
                        {
                            isDisplayCardFlag = true;
                        }
                    }

                    if (isDisplayCardFlag == true)
                    {
                        Console.Write(" ");
                        Console.Write(m_GameLogic.BoardGame.Board[i - 1, j]);
                        Console.Write(" ");
                        isDisplayCardFlag = false;
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                }

                Console.WriteLine("|");
            }

            printBetweenLines();
        }

        private void runGamePlayerVSPlayer()
        {
            string playerFirstCardString;
            string playerSecondCardString;
            bool isGameOverFlag = false;

            askingForTwoCardFromPlayer(out playerFirstCardString, out playerSecondCardString);
            while (playerFirstCardString.Equals("Q") == false && playerSecondCardString.Equals("Q") == false && isGameOverFlag == false )
            {
                if (m_GameLogic.IsMatchingCard(playerFirstCardString, playerSecondCardString) == true)
                {
                    Console.WriteLine("There is a match, good work!");
                    m_GameLogic.UpdateScore();
                    if (m_GameLogic.IsGameOver(m_GameLogic.BoardGame.CountOfMatchingCard) == true)
                    {
                        isGameOverFlag = true;
                    }
                }
                else
                {
                    Console.WriteLine("There is not a match, try next time...");
                    m_GameLogic.ExchangeTurns();
                }

                if (isGameOverFlag == false)
                {
                    askingForTwoCardFromPlayer(out playerFirstCardString, out playerSecondCardString);
                }
            }
        }  

        private void runGameComputerVSPlayer()
        {
            string playerFirstCardString = null;
            string playerSecondCardString = null;
            bool isGameOverFlag = false;

            while (isGameOverFlag == false)
            {
                if (m_GameLogic.PlayerNumber1.IsPlayerTurn == true)
                {
                    askingForTwoCardFromPlayer(out playerFirstCardString, out playerSecondCardString);
                    if (playerFirstCardString.Equals("Q") == true || playerSecondCardString.Equals("Q") == true)
                    {
                        isGameOverFlag = true;
                    }
                }
                else
                {
                    Console.WriteLine("Now it is the computer turn, to continue press any key (beside Q -> Quit)");
                    string keyToContinue = Console.ReadLine();
                    if (keyToContinue.Equals("Q") == true)
                    {
                        isGameOverFlag = true;
                    }
                    else
                    {
                        Ex02.ConsoleUtils.Screen.Clear();
                        m_GameLogic.ComputerChooseTwoCards(out playerFirstCardString, out playerSecondCardString);
                        Console.WriteLine("The computer chosed " + playerFirstCardString + ", " + playerSecondCardString + " cards");
                        printingBoardMethod(2, playerFirstCardString, playerSecondCardString);
                    }
                }

                if (isGameOverFlag == false)
                {
                    if (m_GameLogic.IsMatchingCard(playerFirstCardString, playerSecondCardString) == true)
                    {
                        Console.WriteLine("There is a match, good work!");
                        m_GameLogic.UpdateScore();
                    }
                    else 
                    {
                        m_GameLogic.ExchangeTurns();
                    }
                }
             }
        }

        public void StartGame()
        {
            getInfoAboutThePlayers();
            getInfoAboutTheBoard();
            if (m_GameLogic.GameComputerVSPlayer == true)
            {
                runGameComputerVSPlayer();
            }
            else
            {
                runGamePlayerVSPlayer();
            }

            m_GameLogic.DeterminingTheWinner();
            string EndOfGameMessage = string.Format(
@"Game over!
The winner is: {0} with {1} points",
                                   m_GameLogic.Winner.PlayerName,
                                   m_GameLogic.Winner.PlayerScore);
            Console.WriteLine(EndOfGameMessage);
        }

        private void askingForTwoCardFromPlayer(out string o_playerFirstCardString, out string o_playerSecondCardString)
        {
            o_playerFirstCardString = null;
            o_playerSecondCardString = null;
            Console.WriteLine("Please enter the first card you want to choose");
            o_playerFirstCardString = Console.ReadLine();
            while (isValidCard(o_playerFirstCardString) == false && o_playerFirstCardString.Equals("Q") == false)
            {
                    Console.WriteLine("Please try again to enter the first card you want to choose: ");
                    o_playerFirstCardString = Console.ReadLine();
            }

            if (o_playerFirstCardString.Equals("Q") == false)
            {
                    Ex02.ConsoleUtils.Screen.Clear();
                    printingBoardMethod(1, o_playerFirstCardString);
                    Console.WriteLine("Please enter the second card you want to choose");
                    o_playerSecondCardString = Console.ReadLine();
                    while ((isValidCard(o_playerSecondCardString) == false && o_playerSecondCardString.Equals("Q") == false) || o_playerSecondCardString == o_playerFirstCardString)
                    {
                        if (o_playerSecondCardString == o_playerFirstCardString)
                        {
                            Console.WriteLine("You entered a card like your first card you choose,");
                        }

                        Console.WriteLine("Please try again to enter the second card you want to choose: ");
                        o_playerSecondCardString = Console.ReadLine();
                    }

                    if (o_playerSecondCardString.Equals("Q") == false)
                    {
                        Ex02.ConsoleUtils.Screen.Clear();
                        printingBoardMethod(2, o_playerFirstCardString, o_playerSecondCardString);
                    }
                }
            }

        private bool isValidCard(string i_ChoosedCard)
        {
            string message = null;
            bool isTheCardValidFlag = true;
            char[] choosedCardToCharArray = i_ChoosedCard.ToCharArray();

            if (choosedCardToCharArray.Length != 2)
            {
                if (choosedCardToCharArray[0] == 'Q' && choosedCardToCharArray.Length == 1)
                {
                    isTheCardValidFlag = true;
                }
                else
                {
                    message = string.Format("The card is no in the format of 2 characters");
                    isTheCardValidFlag = false;
                }
            }
            else
            {
                char firstCharacter = 'A';
                if (choosedCardToCharArray[0] - firstCharacter < 0 || choosedCardToCharArray[0] - firstCharacter > m_GameLogic.BoardGame.ColOfBoard - 1)
                {
                    firstCharacter = (char)((int)firstCharacter + m_GameLogic.BoardGame.ColOfBoard - 1);
                    message = string.Format("The first character is not upper letter between A and {0}", firstCharacter);
                    isTheCardValidFlag = false;
                }
                else
                {
                    if (char.GetNumericValue(choosedCardToCharArray[1]) < 1 || char.GetNumericValue(choosedCardToCharArray[1]) > m_GameLogic.BoardGame.RowOfBoard)
                    {
                        message = string.Format("The second character is not character between 1 and {0}", m_GameLogic.BoardGame.RowOfBoard);
                        isTheCardValidFlag = false;
                    }
                    else
                    {
                        if (m_GameLogic.BoardGame.AvailableCardsToChoose.Exists(availableCard => availableCard == i_ChoosedCard) == false)
                        {
                            isTheCardValidFlag = false;
                            message = string.Format("The card is exhibited, please try again :");
                        }
                    }
                }
            }

            if (message != null)
            {
                Console.WriteLine(message);
            }

            return isTheCardValidFlag;
        }
    }
}