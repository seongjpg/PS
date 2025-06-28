using static System.Console;
namespace _2436
{
    class _2436
    {
        static int GCD(int x, int y)
        {
            if (y > x) (x, y) = (y, x);
            while (x % y != 0) (x, y) = (y, x % y);
            return y;
        }
        static void Main()
        {
            string[] ab = ReadLine().Split();
            int a = int.Parse(ab[0]); int b = int.Parse(ab[1]);
            
            b /= a;
            int x = 0; int y = 0;
            int rootB = Convert.ToInt32(Math.Sqrt(b));
            int minSum = int.MaxValue;
            for (int i  = 1; i <= rootB; i++)
            {
                
                if (b % i == 0 && minSum > i + b/i && GCD(i, b/i) == 1)
                {     
                    x = i * a; y = b / i * a;
                    //debug
                    //Write($"i : {i}\nminSum : {minSum}\n\n");
                    minSum = i + b / i;
                }
                    
            }
            if (x > y) (x, y) = (y, x);
            Write($"{x} {y}\n");
        }
    }
}
