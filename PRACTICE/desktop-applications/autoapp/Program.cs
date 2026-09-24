using autoapp;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Auto> cars = Auto.readData();

            foreach (Auto c in cars)
            {
                Console.WriteLine(c.ToString());
            }
            
            //feladat 5.
            Console.Write("Feladat 5: ");
            Console.WriteLine($"{countCars(cars)} autó található a listában");

            //feladat 6.
            Console.Write("Feladat 6: ");
            Console.WriteLine($"Az autók esetében az átlagosan eladott darabszám {avgSold(cars):F1}");

            //feladat 7.
            Console.Write("Feladat 7: ");
            Console.WriteLine("Az elmúlt 7 évben gyártott autok:");
            List<Auto> newCars = newModels(cars);
            foreach (Auto car in newCars)
            {
                Console.WriteLine($"- {car.Brand} {car.Model}: {car.Year}");
            }

            //Feladat 8.
            Dictionary<string, int> result = soldByBrand(cars);

            Console.Write("Feladat 8: ");
            Console.WriteLine("Legsikeresebb márkák listája az eladott darabszám alapján:");
            foreach (var brand in result)
            {
                Console.WriteLine($"- {brand.Key}: {brand.Value} darab");
            }
        }

        public static int countCars(List<Auto> cars)
        {
            return cars.Count();
        }

        public static double avgSold(List<Auto> cars)
        {
            int sum = 0;

            foreach (Auto car in cars)
            {
                sum += car.SoldCount;
            }

            double avg = (double)sum / cars.Count();

            return avg;
        }

        public static List<Auto> newModels(List<Auto> cars)
        {
            List<Auto> filtered = cars
                .Where(c => c.Year >= 2019)
                .ToList();

            return filtered;
        }

        public static Dictionary<string, int> soldByBrand(List<Auto> cars)
        {
            return cars
                .GroupBy(car => car.Brand)
                .ToDictionary(
                    group => group.Key,
                    group => group.Sum(car => car.SoldCount)
                )
                .OrderByDescending(c => c.Value)
                .ToDictionary(c => c.Key, c => c.Value);
        }
    }
}