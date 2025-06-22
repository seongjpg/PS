using static System.Console;

namespace _2108 {
	class Statistics
	{
		static void Main()
		{
			StreamReader rd = new StreamReader(Console.OpenStandardInput());
			int n = int.Parse(rd.ReadLine());
			int[] ints = new int[n];
			int[] amts = new int[8001];
			int s = 0;
			for (int i = 0; i < n; i++)
			{
				int x = int.Parse(rd.ReadLine());
				amts[x+4000]++;
				ints[i] = x;
				s += x;
			}

			//산술평균
			double am = (s / (double)n);
			double ans = Math.Round(am, 0 );
			if (Math.Abs(ans) == 0) ans = 0;
			Write($"{ans}\n");
			//중앙값
			Array.Sort(ints);
			Write($"{ints[n / 2]}\n");
			//최빈값
			List<int> m = new List<int>();
			int maxAmt = 0; int mid;
			for (int i = 0; i < 8001; i++)
			{
				if (maxAmt < amts[i])
				{
					maxAmt = amts[i];
					List<int> newM = new List<int>();
					newM.Add(i - 4000);
					m = newM;
				}
				else if (maxAmt == amts[i])
				{
					m.Add(i - 4000);
				}
			}
			if (m.Count == 1)
				mid = m[0];
			else
				mid = m[1];
			Write($"{mid}\n");

            //범위
            Write($"{ints[n - 1] - ints[0]}\n");
		}
	}
}