using System;

namespace A1B_Ex01_5
{
     public class ExerciseNumberFive
    {
         public static void Main()
         {
             Console.WriteLine("Please enter a line :");
             string line = Console.ReadLine();
             LexicographicAnalysisOfLine(line);
         }

         public static void LexicographicAnalysisOfLine(string i_Line)
         {
             int countLowerLetters = 0;
             int countUpperLetters = 0;
             int countDigitLetters = 0;
             int countSpaceLetters = 0;
             int lenghtOfLine = i_Line.Length;
             char[] stringToCharArray = i_Line.ToCharArray();
             for (int i = 0; i < lenghtOfLine; i++)
             {
                 // $G$ NTT-999 (0) It is better to keep a reference to the element rather than accessing it through indexes all the time.
                 // $G$ CSS-999 (0) There's no need to use "== true".
                 if (char.IsUpper(stringToCharArray[i]) == true)
                 {
                     countUpperLetters++;
                 }
                 // $G$ NTT-999 (-1) You should use "else if".
                 if (char.IsLower(stringToCharArray[i]) == true)
                 {
                     countLowerLetters++;
                 }

                 if (char.IsDigit(stringToCharArray[i]) == true)
                 {
                     countDigitLetters++;
                 }
                 // $G$ NTT-005 (-3) You should have used the Char.IsWhiteSpace(...).
                 if (stringToCharArray[i].Equals(' ') == true)
                 {
                     countSpaceLetters++;
                 }
            }

            string message = string.Format(
@"Lexicographic analysis of line is:
1. The number of lower-case letters is: {0},
2. The number of upper-case letters is: {1},
3. The number of digit letters is: {2},
4.The number of spaces in line: {3}.",
                              countLowerLetters,
                              countUpperLetters,
                              countDigitLetters,
                              countSpaceLetters);
            Console.WriteLine(message);
         }     
    }
}
