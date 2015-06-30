using System;

// $G$ THE-002 (-3) You should have mentioned that Programs and eDemoOptions being nested inside DemosManager.
namespace A1B_Ex01_1
{
    // $G$ CSS-016 (-5) The class which handles the program entry point should be named 'Program'.
   public class ExerciseNumberOne
    {
       public static void Main()
       {
           FindingMinMax();
       }

       // $G$ DSN-003 (-5) Method too long, the code should be divided to several methods (getUserInput(), etc...).
       public static void FindingMinMax()
       {
           int maxNumber = 0;
            int minNumber = 0;
            int sumOfNumbers = 0;
            float avrageOfNumbers = 0;
            int countTheRecivedNumbers = 0;
            int countDivisorsInFirstNumber = 0;
            int firstNumber = 0;
            int number = 0;
            // $G$ CSS-027 (-5) Space should be kept after local variable declarations section.
            Console.WriteLine("Please enter positive numbers, after each one press 'enter', till -1");
            while (number != -1)
            {
                string stringNumber = Console.ReadLine();
                try
                {
                    if (countTheRecivedNumbers == 0)  
                    {
                        firstNumber = int.Parse(stringNumber);
                        maxNumber = firstNumber;
                        minNumber = firstNumber;
                        number = firstNumber;
                    }
                    else  
                    {
                        number = int.Parse(stringNumber);
                    }

                    // $G$ NTT-002 (-5) You should have used int.TryParse instead.
                    if (number < 0 && number != -1)
                    {
                        throw new FormatException();
                    }

                    if (number > -1)
                    {
                        countTheRecivedNumbers++;
                        // $G$ SFN-999 (-5) You should check if the first number is 0.
                        if (number % firstNumber == 0 && countTheRecivedNumbers != 1)
                        {
                            countDivisorsInFirstNumber++;
                        }

                        sumOfNumbers += number;
                        maxNumber = Math.Max(maxNumber, number);
                        minNumber = Math.Min(minNumber, number);
                    }
                }
                // $G$ NTT-999 (0) There is no point in throwing an exception and catching it in the same method. Exceptions are used for abnormal situations, which can't be dealt with at the context in which they are used.
                catch (FormatException)
                {
                    Console.WriteLine("This is not a positive integer. Please try again:");
                }
            } // End of while
            avrageOfNumbers = (float)sumOfNumbers / countTheRecivedNumbers;
            string message;
            if (countTheRecivedNumbers > 0)
            {
                message = string.Format(
@"The max number is: {0}
The min number is : {1}
The average is : {2}
Num of numbers : {3}
The count divisors in the first number : {4}", 
                                             maxNumber, 
                                             minNumber, 
                                             avrageOfNumbers, 
                                             countTheRecivedNumbers, 
                                             countDivisorsInFirstNumber);  
            }
            else
            {
                message = string.Format("You did not insert any number");
            }

            Console.WriteLine(message);
        }
    }
}