using static System.Console;

namespace _10830 {
	class PowMatrix {

		static int[,] Multiple(int[,] mat1, int[,] mat2, int n)
		{
			int[,] rtn = new int[n, n];
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					for (int k = 0; k < n; k++)
					{
						rtn[i, j] += (mat1[i, k] * mat2[k, j]) % 1000;
					}
					rtn[i, j] %= 1000;
				}
			}
			return rtn;
		}

		static void PrintMatrix(int[,] mat, int n)
		{
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					Write($"{mat[i, j]} ");
				}
				Write("\n");
			}
		}

		static void Main()
		{
			string[] nb = ReadLine().Split();
			int n = int.Parse(nb[0]); long b = long.Parse(nb[1]);

			int[,] mat = new int[n, n];
			for (int i = 0; i < n; i++)
			{
				string[] col = ReadLine().Split();
				for (int j = 0; j < n; j++) mat[i, j] = int.Parse(col[j]);
			}
			//set table
			int[][,] table = new int[40][,];
			table[0] = mat;
			for (int i = 1; i < 40; i++)
			{
				table[i] = Multiple(table[i - 1], table[i - 1], n);
			}
			int[,] ans = new int[n, n];
			for (int i = 0; i < n; i++) ans[i, i] = 1;

			while (b > 0)
			{
				int x = Convert.ToInt32(Math.Floor(Math.Log2(b)));
				ans = Multiple(ans, table[x], n);
				b -= (long)Math.Pow(2, x);
			}
			PrintMatrix(ans, n);
		}
	}
}
