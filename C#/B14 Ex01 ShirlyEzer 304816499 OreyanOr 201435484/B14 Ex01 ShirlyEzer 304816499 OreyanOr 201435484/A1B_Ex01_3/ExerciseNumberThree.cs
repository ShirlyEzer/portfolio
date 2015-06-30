using System;
using A1B_Ex01_2;

namespace A1B_Ex01_3
{
    public class ExerciseNumberThree
    {
        public static void Main()
        {
            int heightOfDiamond = 0;
            Console.WriteLine("Please enter the height of the diamond : ");
            string heightOfDiamondString = Console.ReadLine();
            heightOfDiamond = ExerciseNumberTwo.CheckValue(heightOfDiamondString);
            ExerciseNumberTwo.DrawDiamond(heightOfDiamond);
        }
    }
}
