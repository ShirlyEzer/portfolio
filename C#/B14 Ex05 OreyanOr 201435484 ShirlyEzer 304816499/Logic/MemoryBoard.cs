using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class MemoryBoard
    {
        // $G$ DSN-999 (-5) Cells should be represented by either a struct, a class or an enum.
        private char[,] m_Board = null;
        private int[] m_CountOfMatchingCard = null;
        private int m_RowOfBoard;
        private int m_ColOfBoard;
        private List<int> m_AvailableCardsToChoose = null;

        public char[,] Board
        {
            get { return m_Board; }
        }

        public int[] CountOfMatchingCard
        {
            get { return m_CountOfMatchingCard; }
        }

        public int ColOfBoard
        {
            get { return m_ColOfBoard; }
            set { m_ColOfBoard = value; }
        }

        public int RowOfBoard
        {
            get { return m_RowOfBoard; }
            set { m_RowOfBoard = value; }
        }

        public List<int> AvailableCardsToChoose
        {
            get { return m_AvailableCardsToChoose; }
        }

        private void InsertToArrayCardsThatAvailableToSelect()
        {
            m_AvailableCardsToChoose = new List<int>(m_ColOfBoard * m_RowOfBoard);
            for (int i = 0; i < m_RowOfBoard; i++)
            {
                for (int j = 0; j < m_ColOfBoard; j++)
                {
                    m_AvailableCardsToChoose.Add(((i + 1) * 10) + (j + 1));
                }
            }
        }
        
        public void CreateBoard()
        {
            char insertValueToList = 'L';
            Random randValue = new Random();

            List<char> arrayInsertValues = new List<char>(m_ColOfBoard * m_RowOfBoard);
            m_CountOfMatchingCard = new int[(m_ColOfBoard * m_RowOfBoard) / 2];
            m_Board = new char[m_RowOfBoard, m_ColOfBoard];
            for (int i = 0; i < (m_ColOfBoard * m_RowOfBoard) / 2; i++)
            {
                m_CountOfMatchingCard[i] = 0;
                arrayInsertValues.Add(insertValueToList);
                arrayInsertValues.Add(insertValueToList);
                insertValueToList++;
            }

            for (int i = 0; i < m_RowOfBoard; i++)
            {
                for (int j = 0; j < m_ColOfBoard; j++)
                {
                    int randomIndex = randValue.Next(0, arrayInsertValues.Count);
                    m_Board[i, j] = arrayInsertValues[randomIndex];
                    arrayInsertValues.Remove(arrayInsertValues[randomIndex]);
                }
            }

            InsertToArrayCardsThatAvailableToSelect();  
        }
    }
}
