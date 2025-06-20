using static System.Console;

namespace _15552
{
    class FastAB
    {
        static void Main()
        {
            StreamReader rd = new StreamReader(Console.OpenStandardInput());
            StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());
            int n = int.Parse(rd.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                string[] ab = rd.ReadLine().Split();
                wr.Write($"{int.Parse(ab[0]) + int.Parse(ab[1])}\n");
            }
                
            wr.Flush();
            wr.Close();
            rd.Close();

        }
    }
}