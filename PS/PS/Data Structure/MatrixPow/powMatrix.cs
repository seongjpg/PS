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
						rtn[i, j] += (mat1[i, k] * mat2[k, j]);
					}
					rtn[i, j] %= 1000;
				}
			}
			return rtn;
		}
		static int[,] Pow(int[,] mat, long p, int n)
		{
			if (p == 1) return mat;
			int[,] multipled = Multiple(Pow(mat, p / 2, n), Pow(mat, p / 2, n), n);
			if (p % 2 == 0)
			{
				return multipled;
			}
			return Multiple(multipled, mat, n);
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
			int[,] ans = new int[n, n];
			for (int i = 0; i < n; i++) ans[i, i] = 1;
			while (b > 0)
			{
				if (b % 2 == 1)
					ans = Multiple(ans, mat, n);
				mat = Multiple(mat, mat, n);
				b /= 2;
			}
			PrintMatrix(ans, n);

		}
	}
}
