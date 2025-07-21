using static System.Console;

namespace _2696
{
    class FindMId
    {
        static void Insert(int amt, List<int> list)
        {

            if (list.Count == 0) list.Add(amt);

            else
            {
                int s = 0; int e = list.Count-1;
                int id = (s + e) / 2;
                while (s <= e)
                {
                    if (list[id] < amt) s = id + 1;
                    else if (list[id] > amt) e = id - 1;
                    else
                    {
                        list.Insert(id, amt); return;
                    }           
                    id = (s + e) / 2;
                }
                
                list.Insert(s, amt);
            }
        }
        static void Main()
        {
            StreamReader rd = new StreamReader(Console.OpenStandardInput());
            StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());
            int t = int.Parse(rd.ReadLine());
            while (t-- > 0)
            {
                List<int> list = new List<int>();
                int n = int.Parse(rd.ReadLine());
                wr.Write($"{n / 2 + 1}\n");
                int loops = n / 10;
                for (int i = 0; i <= loops; i++)
                {
                    string[] arr = rd.ReadLine().Split();
                    for (int j = 0; j < arr.Length; j++)
                    {
                        Insert(int.Parse(arr[j]), list);
                        if (list.Count % 2 == 1) { wr.Write($"{list[list.Count / 2]} ");
                            //for (int x = 0; x < list.Count; x++) Write($"{list[x]} ");
                            //Write("\n\n");
                        }
                    }
                    if (i % 2 == 1 || i == (n / 10)) wr.Write("\n");
                }
                
            }
            wr.Flush();
            rd.Close();
            wr.Close();
        }
    }
}