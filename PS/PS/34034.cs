using System.Text;
using static System.Console;
namespace PS {
	class _34034 {
		static void Main()
		{
			string[] nmk = ReadLine().Split();
			StringBuilder ans = new StringBuilder();
			int n = int.Parse(nmk[0]); int m = int.Parse(nmk[1]); int k = int.Parse(nmk[2]);
			string[] arr = ReadLine().Split();
			List<int[]> needs = new List<int[]>();
			for (int i = 0; i < n; i++)
			{
				int[] add = { int.Parse(arr[i]), i + 1 };
				needs.Add(add);
			}
			needs.Sort((a, b) =>
			{
				return a[0].CompareTo(b[0]);
			});
			int solveToAble = k - m;
			int needTime = 0;
			if (solveToAble > n) ans.Append("-1");
			else
			{
				for (int i = 0; i < solveToAble; i++) needTime += needs[i][0];

				if (needTime > k) ans.Append("-1");
				else
				{
					for (int i = 0; i < m; i++) ans.Append("0 ");
					for (int i = 0; i < k - m; i++) ans.Append($"{needs[i][1]} ");
				}
			}
			
			Write(ans);
		}
	}
}
