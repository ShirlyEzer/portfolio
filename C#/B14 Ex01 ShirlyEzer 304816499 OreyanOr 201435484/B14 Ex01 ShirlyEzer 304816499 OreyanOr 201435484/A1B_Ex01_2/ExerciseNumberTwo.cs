using System;
using System.Text;  // For the string builder

namespace A1B_Ex01_2
{
    public class ExerciseNumberTwo
    {
        public static void Main()
        {
            int numberOfLines = 0;
            Console.WriteLine("Please enter the number of lines for the diamond : ");
            string numberOfLinesString = Console.ReadLine();
            numberOfLines = CheckValue(numberOfLinesString);
            // $G$ SFN-010 (-2) Exercise 2 should print only one type of rhombus (5 lines).
            DrawDiamond(numberOfLines);
        }

        public static int CheckValue(string i_NumberOfLinesString)
        {
            int numberOfLines = 0;
            int wrongValueFlag = 0;
            // $G$ SFN-010 (-5) The program get stuck in a loop when providing a positive number.
            while (wrongValueFlag == 0)
            {
                if (int.TryParse(i_NumberOfLinesString, out numberOfLines) == false || numberOfLines <= 0)
                {
                    Console.WriteLine("You have entered a wrong value. please try again : ");
                    i_NumberOfLinesString = Console.ReadLine();
                }
                else
                {
                    wrongValueFlag = 0;
                }
            }

            if (numberOfLines % 2 == 0)
            {
                numberOfLines--;
            }

            return numberOfLines;
        }

        public static void DrawDiamond(int i_NumberOfLines)
        {
            StringBuilder diamondStringBuilder = new StringBuilder();
            for (int line = 0; line < i_NumberOfLines; line++)
            {
                string lineForDiamond = GenerateLineForDiamond(line, i_NumberOfLines);
                diamondStringBuilder.Append(lineForDiamond);
                diamondStringBuilder.AppendLine();
            }

            Console.WriteLine(diamondStringBuilder.ToString());
        }

        public static string GenerateLineForDiamond(int i_Line, int i_NumberOfLines)
        {
            StringBuilder lineStringBuilder = new StringBuilder();
            int numOfStars = 0;
            int rowInDiamond = 0;
            int numOfSpacesInLine = Math.Abs((i_NumberOfLines / 2) - i_Line);
            if (i_Line > (i_NumberOfLines / 2))
            {
                rowInDiamond = i_NumberOfLines - i_Line - 1;
            }
            else
            {
                rowInDiamond = i_Line;
            }

            for (int i = 0; i < numOfSpacesInLine; i++)
            {
                lineStringBuilder.Append(" ");
            }

            numOfStars = (i_NumberOfLines / 2) + rowInDiamond - numOfSpacesInLine + 1;
            for (int i = 0; i < numOfStars; i++)
            {
                lineStringBuilder.Append("*");
            }

            return lineStringBuilder.ToString();
        }
    }
}
