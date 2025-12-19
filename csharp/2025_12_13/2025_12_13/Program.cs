using System;
using Microsoft.VisualBasic;

namespace _2025_12_13
{
    internal class Program
    {
        public static void CWL(string msg) => Console.WriteLine(msg);
        public static int RN() => int.Parse(Console.ReadLine());
        public static char RC() => char.Parse(Console.ReadLine());
        
        static void Main(string[] args)
        {
            CWL("Choose a task from 1-10:");
            int task = RN();

            switch (task)
            {
                case 1: FirstTask(); break;
                case 2: SecondTask(); break;
                case 3: ThirdTask(); break;
                case 4: FourthTask(); break;
                case 5: FifthTask(); break;
                case 6: SixthTask(); break;
                case 7: SeventhTask(); break;
                case 8: EighthTask(); break;
                case 9: NinthTask(); break;
                case 10: TenthTask(); break;
            }
        }

        public static int FirstTask()
        {
            CWL("Enter a number: ");
            int number = RN();
            if (number % 2 == 0)
            {
                CWL("The number is even");
            }
            else
            {
                CWL("The number is odd");
            }
            
            return 1;
        }

        public static int SecondTask()
        {
            CWL("Enter a number: ");
            int number = RN();

            if (number > 0)
            {
                CWL("The number is positive");
            }
            else if(number < 0)
            {
                CWL("The number is negative");
            }
            else
            {
                CWL("The number is zero");
            }
            
            return 2;
        }

        public static int ThirdTask()
        {
            CWL("Enter a number: ");
            int number = RN();
            if (number >= 10 && number <= 20)
            {
                CWL("The number is between 10 and 20.");
            }
            else
            {
                CWL("The number is NOT between the interval.");
            }
            return 3;
        }

        public static int FourthTask()
        {
            CWL("Enter a number 0-9999: ");
            int number = RN();
            if (number > 9999)
            {
                CWL("The number is too large");
            } else
            {
                int digitCount = number == 0
                    ? 1 : (int)Math.Floor(Math.Log10(Math.Abs(number))) + 1;
                CWL($"The number digit count: {digitCount}");
            }
            
            
            return 4;
        }

        public static int FifthTask()
        {
            CWL("Enter a Celsius: ");
            int number = RN();
            string result = number switch
            {
                < 0 => "Fagy.",
                >= 0 and < 21 => "Hűvös",
                >= 21 and < 31 => "Meleg",
                >= 31 => "Forróság"
            };

            CWL(result);

            
            return 5;
        }

        public static int SixthTask()
        {
            CWL("Enter a number: ");
            int number = RN();

            if (number % 3 == 0 && number % 5 == 0)
            {
                CWL("The number is dividable by 3 and 5.");
            }
            else if(number % 3 == 0 && number % 5 != 0)
            {
                CWL("The number is dividable by 3.");
            }
            else if (number % 3 != 0 && number % 5 == 0)
            {
                CWL("The number is dividable by 5.");
            }
            else
            {
                CWL("The number is not dividable by 3 nor 5.");
            }
            
            return 6;
        }

        public static int SeventhTask()
        {
            int i = 0;
            int[] numbers = new int[3];

            while (i < 3)
            {
                CWL($"Number {i+1}: ");
                numbers[i] = RN();
                if (numbers[i] <= 0)
                {
                    CWL("The number is negative.");
                    return 7;
                }
                i++;
            }

            int a = numbers[0];
            int b = numbers[1];
            int c = numbers[2];
            
            if (((a + b) > c) && ((a + c) > b) && ((b + c) > a))
            {
                CWL("This triangle can exist!");
            }
            else
            {
                CWL("This triangle cannot exist!");
            }
            
            return 7;
        }

        public static int EighthTask()
        {
            CWL("Enter an age: ");
            int age = RN();

            if (age >= 0 && age < 18) CWL("Kiskorú.");
            else if (age >= 18 && age < 65) CWL("Felnőtt.");
            else if (age >= 65) CWL("Nyugdíjas");
            
            return 8;
        }

        public static int NinthTask()
        {
            CWL("Enter a number: ");
            int number = RN();
            if(Math.Sign(number) == -1) CWL((number * (-1)).ToString());
            else if(Math.Sign(number) == 0) CWL("The number is zero.");
            else CWL(number.ToString());
            
            return 9;
        }

        public static int TenthTask()
        {
            int i = 0;
            int[] numbers = new int[2];
            
            CWL("Give an operation: ");
            char operation = RC();

            while (i < 2)
            {
                CWL($"Give number {i+1}: ");
                numbers[i] = RN();
                if (operation.ToString() == "/" && numbers[i] == 0)
                {
                    CWL("You cannot give 0 when dividing!");
                    return 10;
                }
                i++;
            }

            int a = numbers[0];
            int b = numbers[1];

            switch (operation.ToString())
            {
                case "+": CWL($"Value: {a} + {b} = {a + b}"); break;
                case "*": CWL($"Value: {a} * {b} = {a * b}"); break;
                case "/": CWL($"Value: {a} / {b} = {a / b}"); break;
                case "%": CWL($"Value: {a} % {b} = {a % b}"); break;
                case "-": CWL($"Value: {a} - {b} = {a - b}"); break;
            }
            
            return 10;
        }
    }
}