using System.Collections;
using static System.Console;

namespace _1759 {
	class MakePW
	{
		static StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());
		public static char[] par = {'a', 'e', 'i', 'o', 'u'};
		public static char[] ch = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z' };
		static void Recursion(int len, char[] arr, int id, int c, string str, int parNo, int chNo)
		{
			if (len == c) { if (parNo > 0 && chNo > 1) wr.Write($"{str}\n"); return; }

			for (int i = id; i < arr.Length; i++)
			{
				string newStr = $"{str}{arr[i]}";
				bool isPar = false;
				for (int j = 0; j < 5; j++)
				{
					if (par[j] == arr[i])
					{
						Recursion(len + 1, arr, i + 1, c, newStr, parNo + 1, chNo); isPar = true;  break;
					}
				}
				if (!isPar) Recursion(len + 1, arr, i + 1, c, newStr, parNo, chNo + 1); ;
			}
		}
		static void Main()
		{
			string[] lc = ReadLine().Split();
			string[] arr = ReadLine().Split();
			Array.Sort(arr);
			char[] chr = new char[arr.Length];
			for (int i = 0; i < arr.Length; i++) chr[i] = Convert.ToChar(arr[i]);
			Recursion(0, chr, 0, int.Parse(lc[0]), "", 0, 0);
			wr.Flush();
			wr.Close();
		}
	}
}