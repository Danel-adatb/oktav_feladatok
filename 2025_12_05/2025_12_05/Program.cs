using System;
using System.Collections.Generic;
using System.Linq;

namespace _2025_12_05
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Choose a Task to run (Task 1 => Task 9):");
            int taskNumber = int.Parse(Console.ReadLine());

            switch (taskNumber)
            {
                case 1: TaskOne(); break;
                case 2: TaskTwo(); break;
                case 3: TaskThree(); break;
                case 4: TaskFour(); break;
                case 5: TaskFive(); break;
                case 6: TaskSix(); break;
                case 7: TaskSeven(); break;
                case 8: TaskEight(); break;
                case 9: TaskNine(); break;
            }
        }

        static int TaskOne()
        {
            Console.WriteLine("Give a number:");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine($"Number = {number}");
            Console.WriteLine($"Number*2 = {number * 2}");
            Console.WriteLine($"Number*3 = {number * 3}");

            return 1;
        }

        static int TaskTwo()
        {
            Console.WriteLine("Give a (double) number:");
            double number = double.Parse(Console.ReadLine());
            Console.WriteLine($"Math Round => {Math.Round(number)}");
            Console.WriteLine($"Math Floor => {Math.Floor(number)}");
            Console.WriteLine($"Math Ceiling => {Math.Ceiling(number)}");

            return 2;
        }

        static int TaskThree()
        {
            Console.WriteLine("Give a (double) number:");
            double number = double.Parse(Console.ReadLine());
            Console.WriteLine($"Number Sqrt = {Math.Sqrt(number)}");
            Console.WriteLine($"Number Pow = {Math.Pow(number, 3)}");

            return 3;
        }

        static int TaskFour()
        {
            Console.Write("Enter name no. 1: ");
            string nameOne = Console.ReadLine();
            Console.Write("Enter name no. 2: ");
            string nameTwo = Console.ReadLine();

            Console.WriteLine($"Hello {nameOne} and {nameTwo}!");

            return 4;
        }

        static int TaskFive()
        {
            Console.Write("Enter radius: ");
            double radius = double.Parse(Console.ReadLine());

            Console.WriteLine($"Circumfence => {2 * radius * Math.PI}");
            Console.WriteLine($"Area => {radius * radius * Math.PI}");

            return 5;
        }

        static int TaskSix()
        {
            List<int> numbers = new List<int>();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Give Number {i + 1}:");
                numbers.Add(int.Parse(Console.ReadLine()));
            }

            int max = numbers.Max();
            int min = numbers.Min();
            Console.WriteLine($"Max => {max}, Min => {min}");

            return 6;
        }

        static int TaskSeven()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 101);

            Console.WriteLine($"Random number: {number}");

            return 7;
        }

        static int TaskEight()
        {
            Console.WriteLine("Give a Celsius value in Double:");
            double number = double.Parse(Console.ReadLine());

            Console.WriteLine($"F = {number * 1.8 + 32}");

            return 8;
        }

        static int TaskNine()
        {
            Console.WriteLine("give number 1.:");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("give number 2.:");
            int numberTheSecond = int.Parse(Console.ReadLine());

            double result = (double)number / numberTheSecond;
            Console.WriteLine($"Number1 / number2 = {result}");
            Console.WriteLine($"Number1 % number2 = {number % numberTheSecond}");

            return 9;
        }
    }
}
