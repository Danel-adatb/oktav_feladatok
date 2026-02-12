namespace _2026_01_24.utils;

public class Calculation
{
    public static bool IsPrime(int n)
    {
        if (n <= 1) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;

        for (int i = 3; (long)i * i <= n; i += 2)
        {
            if (n % i == 0)
                return false;
        }

        return true;
    }
    
    public static List<int> GetPrimeDivisors(int n)
    {
        var result = new List<int>();

        // 2-es prímosztó
        if (n % 2 == 0)
        {
            result.Add(2);
            while (n % 2 == 0) n /= 2;
        }

        // páratlan prímosztók
        for (int p = 3; (long)p * p <= n; p += 2)
        {
            if (n % p == 0)
            {
                result.Add(p);
                while (n % p == 0) n /= p;
            }
        }

        // ha maradt egy prímtényező
        if (n > 1)
            result.Add(n);

        return result;
    }
    
    public static List<(int Prime, int Power)> PrimeFactorization(int n)
    {
        var result = new List<(int Prime, int Power)>();

        // 2
        int count = 0;
        while (n % 2 == 0)
        {
            n /= 2;
            count++;
        }
        if (count > 0) result.Add((2, count));

        // páratlanok
        for (int p = 3; (long)p * p <= n; p += 2)
        {
            count = 0;
            while (n % p == 0)
            {
                n /= p;
                count++;
            }
            if (count > 0) result.Add((p, count));
        }

        // maradék (ha >1, akkor prímszám)
        if (n > 1)
            result.Add((n, 1));

        return result;
    }
    
    public static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int r = a % b;
            a = b;
            b = r;
        }

        return a;
    }
    
    public static long Lcm(int a, int b)
    {
        if (a == 0 || b == 0) return 0;
        int gcd = Gcd(a, b);

        return Math.Abs((long)(a / gcd) * b);
    }
}