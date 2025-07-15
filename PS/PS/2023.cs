using static System.Console;

namespace _2023
{
    class Marvelous
    {
        static void IsMystery(int x, int len, int n)
        {
            if (len == n)
            {
                Write($"{x}\n"); return;
            }
            x *= 10;
            for (int i = 1; i < 10; i++)
            {
                if (IsPrime(x + i)) IsMystery(x + i, len + 1, n);
            }

        }
        static bool IsPrime(int n)
        {
            bool rtn = true;
            int sqrt = Convert.ToInt32(Math.Sqrt(n));
            //Write($"sqrt : {sqrt}\n");
            for (int i = 2; i <= sqrt; i++)
            {
                if (n % i == 0)
                {
                    rtn = false;
                    break;
                }
            }
            return rtn;
        }
        static void Main()
        {
            int n = int.Parse(ReadLine());
            for (int x = 2; x < 10; x++)
            {
                if (IsPrime(x)) IsMystery(x, 1, n);
            }
        }
    }
}
