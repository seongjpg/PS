using static System.Console;

namespace _1806
{
    class SubSum
    {
        static void Main()
        {
            StreamReader rd = new StreamReader(Console.OpenStandardInput());
            string[] ns = rd.ReadLine().Split();
            string[] arr = rd.ReadLine().Split();
            int n = int.Parse(ns[0]); int s = int.Parse(ns[1]);
            int id_s = 0; int id_e = 0;
            int len = int.MaxValue; 
            int[] ints = new int[n+1];
            for (int i = 0; i < n; i++) ints[i] = int.Parse(arr[i]);
            ints[n] = int.MinValue;
            int sum = ints[0]; 
            if (sum >= s) len = 1;

            while (id_s <= id_e && id_e < n)
            {
                //sum이 s보다 작다면 id_e를 늘리기
                if (sum < s)
                {
                    id_e++; sum += ints[id_e];
                }
                //sum이 s보다 크거나 같다면 id_s를 줄이기
                else if (sum >= s)
                {
                    if (id_e - id_s + 1 < len) len = id_e - id_s + 1;
                    sum -= ints[id_s];
                    id_s++;
                }
            }
            if (len == int.MaxValue) len = 0;
            WriteLine(len);
        }
    }
}
