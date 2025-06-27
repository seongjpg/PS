using static System.Console;
using System.Numerics;

namespace _10826 {
	class Fibo04 {
		static void Main()
		{
			List<BigInteger> list = new List<BigInteger>() { 0, 1 };
			int n = int.Parse(ReadLine());
			int cnt = 2;
			while (cnt <= n)
			{
				list.Add(list[cnt - 2] + list[cnt - 1]);
				cnt++;
				//Write($"{list[cnt-1]}\n");
			}
				
			Write(list[n]);
		}
	}
}