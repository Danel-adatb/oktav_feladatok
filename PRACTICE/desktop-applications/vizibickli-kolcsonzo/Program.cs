using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace vizibickli_kolcsonzo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Rent> rents = Rent.readDatas();
            foreach (Rent rent in rents)
            {
                Console.WriteLine(rent.ToString());
            }

            //Feladat 5.
            Console.WriteLine("Feladat 5.");
            Console.WriteLine($"Napi kölcsönzések száma: {rents.Count}");

            //Feladat 6.
            Console.WriteLine("Feladat 6.");
            Console.WriteLine("Kérek egy nevet: ");
            var name = Console.ReadLine()?.Trim();
            getDataByName(rents, name);

            //Feladat 7.
            Console.WriteLine("Feladat 7.");
            Console.WriteLine("Adjon meg egy időpontot óra:perc alakban: ");
            var time = Console.ReadLine()?.Trim();
            getDataByTime(rents, time);

            //Feladat 8.
            Console.WriteLine("Feladat 8.");
            Console.WriteLine($"A napi bevétel: {CalculateIncome(rents)} Ft");

            //Feladat 9.
            Console.WriteLine("Írjon bűnöst? (Y / N):");
            var answer = Console.ReadLine();
            if (answer == "Y") PrintPerpetrator(rents);

            //Feladat 10.
            Console.WriteLine("Feladat 10.");

        }

        public static void getDataByName(List<Rent> rents, string? input)
        {
            if (input == null)
            {
                Console.WriteLine("Nem adott meg nevet!");
                return;
            }

            var filtered = rents.Where(r => r.Name == input).ToList();

            if( filtered.Count == 0 )
            {
                Console.WriteLine("Nem volt ilyen nevű kölcsönző!");
                return;
            }

            Console.WriteLine("Kata kölcsönzései:");
            foreach (Rent rent in filtered)
            {
                Console.WriteLine($"{rent.THour}:{rent.TMinute}-{rent.BHour}:{rent.BMinute}");
            }
        }
    
        public static void getDataByTime(List<Rent> rents, string? input) {
            if (input == null)
            {
                Console.WriteLine("Nem adott meg időt!");
                return;
            }

            int hour = 0;
            int minute = 0;
            TimeOnly time = TimeOnly.Parse("00:00:00");
            string[] parts = [];

            try
            {
                parts = input.Split(':');
                hour = int.Parse(parts[0]);
                minute = int.Parse(parts[1]);
                time = TimeOnly.Parse($"{hour}:{minute}:00");
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Nem megfelelő formátum!");
                return;
            }

            List<Rent> filtered = new List<Rent>();
            TimeOnly tTime = new();
            TimeOnly bTime = new();

            Console.WriteLine("A vízen lévő járművek: ");
            foreach (Rent rent in rents)
            {
                tTime = TimeOnly.Parse($"{rent.THour}:{rent.TMinute}:00");
                bTime = TimeOnly.Parse($"{rent.BHour}:{rent.BMinute}:00");
                if(time.IsBetween(tTime, bTime)) {
                    Console.WriteLine($"{tTime}-{bTime} : {rent.Name}");
                }
            }
        }

        public static double CalculateIncome(List<Rent> rents)
        {
            TimeOnly tTime = new();
            TimeOnly bTime = new();
            TimeSpan diffTime = new();
            double diff = 0;
            double sum = 0;

            foreach (Rent rent in rents)
            {
                tTime = TimeOnly.Parse($"{rent.THour}:{rent.TMinute}:00");
                bTime = TimeOnly.Parse($"{rent.BHour}:{rent.BMinute}:00");
                diffTime = bTime - tTime;
                diff = diffTime.TotalMinutes / 30;
                sum += Math.Ceiling(diff) * 2400;
            }

            return sum;
        }

        public static void PrintPerpetrator(List<Rent> rents)
        {
            var filtered = rents.Where(r => r.Category == "F").ToList();
            List<string> result = new();

            foreach (Rent rent in filtered)
            {
                result.Add($"{rent.THour}:{rent.TMinute}-{rent.BHour}:{rent.BMinute} : {rent.Name}");
            }
            string file = "F.txt";

            File.WriteAllLines($"C:\\GitHubPersonal\\oktav_feladatok\\PRACTICE\\desktop-applications\\vizibickli-kolcsonzo\\{file}", result);
        }

        public static Dictionary<string, int> Statistic(List<Rent> rents)
        {
            /*return rents
                .GroupBy(rent => rent.Category)
                .ToDictionary(
                    group => group.Key,
                    group => group.Sum(rent => rent.Category)
                )
                .OrderByDescending(c => c.Value)
                .ToDictionary(c => c.Key, c => c.Value);
            */
        }
    }
}