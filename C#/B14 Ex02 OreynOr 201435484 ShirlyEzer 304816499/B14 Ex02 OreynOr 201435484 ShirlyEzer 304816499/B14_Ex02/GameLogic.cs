using System;
using System.Collections.Generic;
using System.Text;

namespace B14_Ex02
{
    public class GameLogic
    {
        private Player m_PlayerNumber1 = new Player();
        private Player m_PlayerNumber2 = new Player();
        private ComputerPlayer m_ComputerPlay = new ComputerPlayer();
        private MemoryBoard m_BoardGame;
        private bool m_GameComputerVSPlayer = false;
        private bool m_GamePlayerVSPlayer = false;
        private Player m_Winner;

        public GameLogic()
        {
            m_PlayerNumber1.IsPlayerTurn = true;
            m_PlayerNumber1.PlayerScore = 0;
            m_PlayerNumber2.IsPlayerTurn = false;
            m_PlayerNumber2.PlayerScore = 0;
            m_ComputerPlay.IsComputerTurn = false;
            m_ComputerPlay.ComputerScore = 0;
        }

        public MemoryBoard BoardGame
        {
            get { return m_BoardGame; }
            set { m_BoardGame = value; }
        }

        public ComputerPlayer ComputerPlay
        {
            get { return m_ComputerPlay; }
            set { m_ComputerPlay = value; }
        }

        public Player PlayerNumber1
        {
            get { return m_PlayerNumber1; }
            set { m_PlayerNumber1 = value; }
        }

        public Player PlayerNumber2
        {
            get { return m_PlayerNumber2; }
            set { m_PlayerNumber2 = value; }
        }

        public bool GameComputerVSPlayer
        {
            get { return m_GameComputerVSPlayer; }
            set { m_GameComputerVSPlayer = value; }
        }

        public bool GamePlayerVSPlayer
        {
            get { return m_GamePlayerVSPlayer; }
            set { m_GamePlayerVSPlayer = value; }
        }

        public Player Winner
        {
            get { return m_Winner; }
        }

        public bool IsMatchingCard(string i_FirstChoosedCard, string i_SecondChoosedCard)
        {
            int firstCardRowNumber = 0;
            int firstCardColNumber = 0;
            int secondCardRowNumber = 0;
            int secondCardColNumber = 0;
            char firstCardCharacter;
            bool flag = true;

            firstCardCharacter = RevealCard(i_FirstChoosedCard, ref firstCardRowNumber, ref firstCardColNumber);
            if (firstCardCharacter != RevealCard(i_SecondChoosedCard, ref secondCardRowNumber, ref secondCardColNumber))
            {
                flag = false;
            }
            else
            {
                m_BoardGame.CountOfMatchingCard[firstCardCharacter - 'L'] = 1;
                m_BoardGame.AvailableCardsToChoose.Remove(i_FirstChoosedCard);
                m_BoardGame.AvailableCardsToChoose.Remove(i_SecondChoosedCard);
            }

            return flag;
        }

        public bool CheckSizeValuesOfMatrix(int i_RowOfBoard, int i_ColOfBoard)
        {
            bool flag = true;

            if (i_RowOfBoard < 4 || i_RowOfBoard > 6)
            {
                flag = false;
            }
            else
            {
                if (i_ColOfBoard < 4 || i_ColOfBoard > 6)
                {
                    flag = false;
                }
                else
                {
                    if (i_RowOfBoard % 2 != 0 && i_ColOfBoard % 2 != 0)
                    {
                        flag = false;
                    }
                }
            }

            m_BoardGame.ColOfBoard = i_ColOfBoard;
            m_BoardGame.RowOfBoard = i_RowOfBoard;
            return flag;
        }

        public bool IsGameOver(int[] i_CountOfMatchingCard)
        {
            bool flag = true;

            for (int i = 0; i < i_CountOfMatchingCard.Length; i++)
            {
                if (i_CountOfMatchingCard[i] == 0)
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }

        public char RevealCard(string i_ChoosedCard, ref int io_RowIndexOfCard, ref int io_ColIndexOfCard)
        {
            char[] choosedCardToCharArray = i_ChoosedCard.ToCharArray();

            io_ColIndexOfCard = choosedCardToCharArray[0] - 'A';
            io_RowIndexOfCard = (int)char.GetNumericValue(choosedCardToCharArray[1]) - 1;
            return m_BoardGame.Board[io_RowIndexOfCard, io_ColIndexOfCard];
        }

        public void UpdateScore()
        {
            if (m_PlayerNumber1.IsPlayerTurn == true)
            {
                m_PlayerNumber1.PlayerScore++;
            }
            else
            {
                if (m_GamePlayerVSPlayer == true)
                {
                    m_PlayerNumber2.PlayerScore++;
                }
                else
                {
                    m_ComputerPlay.ComputerScore++;
                }
            }
        }

        public void ExchangeTurns()
        {
            if (m_PlayerNumber1.IsPlayerTurn == true)
            {
                m_PlayerNumber1.IsPlayerTurn = false;
                if (m_GameComputerVSPlayer == true)
                {
                    m_ComputerPlay.IsComputerTurn = true;
                }
                else
                {
                    m_PlayerNumber2.IsPlayerTurn = true;
                }
            }
            else
            {
                m_PlayerNumber1.IsPlayerTurn = true;
                if (m_GameComputerVSPlayer == true)
                {
                    m_ComputerPlay.IsComputerTurn = true;
                }
                else
                {
                    m_PlayerNumber2.IsPlayerTurn = true;
                }
            }
        }

        public void DeterminingTheWinner()
        {
            m_Winner = new Player();

            if (m_GamePlayerVSPlayer == true)
            {
                if (m_PlayerNumber1.PlayerScore > m_PlayerNumber2.PlayerScore)
                {
                    m_Winner.PlayerName = m_PlayerNumber1.PlayerName;
                    m_Winner.PlayerScore = m_PlayerNumber1.PlayerScore;
                }
                else
                {
                    m_Winner.PlayerName = m_PlayerNumber2.PlayerName;
                    m_Winner.PlayerScore = m_PlayerNumber2.PlayerScore;
                }
            }
            else
            {
                if (m_PlayerNumber1.PlayerScore > m_ComputerPlay.ComputerScore)
                {
                    m_Winner.PlayerName = m_PlayerNumber1.PlayerName;
                    m_Winner.PlayerScore = m_PlayerNumber1.PlayerScore;
                }
                else
                {
                    m_Winner.PlayerName = "The Computer";
                    m_Winner.PlayerScore = m_ComputerPlay.ComputerScore;
                }
            }
        }

        public void ComputerChooseTwoCards(out string o_FirstCardChosenByComputer, out string o_SecondCardChosenByComputer)
        {
            Random randValue = new Random();
            int randomIndex = randValue.Next(0, m_BoardGame.AvailableCardsToChoose.Count);

            o_FirstCardChosenByComputer = m_BoardGame.AvailableCardsToChoose[randomIndex];
            m_BoardGame.AvailableCardsToChoose.Remove(m_BoardGame.AvailableCardsToChoose[randomIndex]);
            randomIndex = randValue.Next(0, m_BoardGame.AvailableCardsToChoose.Count);
            o_SecondCardChosenByComputer = m_BoardGame.AvailableCardsToChoose[randomIndex];
            m_BoardGame.AvailableCardsToChoose.Add(o_FirstCardChosenByComputer);
        }
    }
}
