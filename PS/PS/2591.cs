using static System.Console;

namespace _2591
{
	class Card
	{
		static int Fibo(int len) // 서브스트링 덩어리의 경우의 수 리턴
		{
			int fibo1 = 1;
			int fibo2 = 1;
			while (len-- > 0)
				(fibo1, fibo2) = (fibo2, fibo1 + fibo2);
			return fibo1;
		}

		static bool IsValid(List<char> chars)// 0이 숫자 카드로 커버 가능한 10, 20, 30을 만들 수 있는 경우로만 주어졌는지 검사하는 함수.
		{
			
			if (chars[0] == '0') return false;
			for (int i = 0; i < chars.Count; i++)
			{
				if (chars[i] == '0' && (chars[i - 1] != '1' && chars[i - 1] != '2' && chars[i - 1] != '3')) return false;
			}
			return true;
		}
		static bool IsZero(List<char> chars) // 10, 20, 30 숫자카드로만 이루어졌는지 검사하는 함수
		{
			for (int i = chars.Count - 2; i >= 0; i--)
			{
				if (chars[i + 1] == '0')
				{
					chars.RemoveAt(i); chars.RemoveAt(i);
					i--;
				}
			}
			return chars.Count == 0;
		}
		static void Main()
		{
			string n = ReadLine();
			List<char> chars = new List<char>() { };
			for (int i = 0; i < n.Length; i++) chars.Add(n[i]);
			if (IsValid(chars))
			{
				//연속적으로 2자리 숫자 카드를 적용할 수 있는 구간들에 대해 묶어준다. 
				//가령, 27123이 있다고 가정하면, 27까지는 2, 7, 그리고 27이 가능하므로 묶을 수 있고,
				//123은 1, 2, 3이 있고, 12, 23으로 묶을 수 있다.
				//하지만 71은 해당하는 숫자 카드가 존재하지 않으므로, 71을 끼고는 묶을 수 없다. 
				//덧붙여, 10, 20, 30으로 되어있는 서브스트링은 반드시 숫자카드 10, 20, 30으로만 존재할 수 있으므로, 이 경우는 없는 것으로 취급하면 된다.)
				int ans = 1;
				int len = 1;
				for (int i = 1; i <chars.Count; i++)
				{
					int x = int.Parse($"{chars[i - 1]}{chars[i]}");
					int f = int.Parse($"{chars[i - 1]}"); int t = int.Parse($"{chars[i]}");
					//10, 20, 30
					if (x % 10 == 0)
					{
						ans *= Fibo(len - 1);
						len = 1;
						i++;
					}
					//숫자카드군에 없는 경우
					else if (f >= 4 || f == 3 && t > 4)
					{
						ans *= Fibo(len);
						len = 1;
					}

					//1의자리 수는 4 이상이지만 숫자 카드군에 존재하는 경우
					else if (t > 3 || x == 34)
					{
						ans *= Fibo(len+1);
						i++;
						len = 1;
					}
					//그외-숫자카드군에 있는, 1의자리수와 10의자리수가 1 2 3으로 이루어진 경우
					else if (f <= 2 || t <= 3)
					{
						len++;
					}
				}
				ans *= Fibo(len);
				if (IsZero(chars)) ans = 1;
				Write(ans);
			}
			else Write(0);
		}
	}
}