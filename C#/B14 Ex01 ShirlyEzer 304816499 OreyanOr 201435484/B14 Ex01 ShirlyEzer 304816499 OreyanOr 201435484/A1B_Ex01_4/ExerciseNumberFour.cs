using System;
using System.Globalization;

namespace A1B_Ex01_4
{
    // $G$ SFN-015 (-3) You should display a message indicating that the input is in binary format even when the input string length is incorrect.
    // $G$ SFN-015 (-3) You should display a message indicating that the input is in the correct length even when the input is not binary.
    public class ExerciseNumberFour
    {
        public static void Main()
        {
            string message = "Please enter binary number with lenght of 9 digits";
            Console.WriteLine(message);
            string binaryNumberString = Console.ReadLine();
            if (IsBinaryNumber(binaryNumberString) == false || binaryNumberString.Length != 9)
            {
                message = "You have entered a roung value";
            }
            else
            {
                int binaryNumber = int.Parse(binaryNumberString);
                int decimalNumber = ConvertBinaryToDecimal(binaryNumber);
                if (IsPrimeNumber(decimalNumber) == false)
                {
                    message = "The converted decimal number is " + decimalNumber.ToString() + " and it is not a prime number!";
                }
                else
                {
                    message = "The converted decimal number is " + decimalNumber.ToString() + " and it is a prime number!";
                }
            }

            Console.WriteLine(message);  
        }

        public static bool IsBinaryNumber(string i_stringNumber)
        {
            int countOfCorrectDigits = 0;
            foreach (var charInStringNumber in i_stringNumber)
            {
                if (charInStringNumber == '0' || charInStringNumber == '1')
                {
                    countOfCorrectDigits++;
                }  
            }

            return (countOfCorrectDigits == 9) ? true : false;
        }

        public static int ConvertBinaryToDecimal(int i_BinaryNumber)
        {
            int decimalNumber = 0;
            for (int i = 0; i < 9; i++)
            {
                int remainedDigit = i_BinaryNumber % 10;
                decimalNumber += remainedDigit * (int)Math.Pow(2, i);
                i_BinaryNumber = i_BinaryNumber / 10;
            }

            return decimalNumber;
        }

        public static bool IsPrimeNumber(int i_DecimalNumber)
        {
            bool flag = true;
            if (i_DecimalNumber == 0 || i_DecimalNumber == 1)
            {
                flag = false;
            }

            for (int i = 2; i <= Math.Sqrt(i_DecimalNumber); i++)
            {
                if (i_DecimalNumber % i == 0)
                {
                    flag = false;
                    // $G$ NTT-999 (-1) You should break the loop here.
                }
            }

            return (flag == true) ? true : false;
        }          
    }
}
