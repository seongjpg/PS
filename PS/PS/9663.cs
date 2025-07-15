using static System.Console;

namespace _9663 {
	class ImAQueen{
		
		static bool[,] Remove(bool[,] b, int y, int x, int n)
		{
			bool[,] rtn = new bool[n, n];
			for (int i = 0; i < n; i++) for (int j = 0; j < n; j++) rtn[i, j] = b[i, j];
			for (int i = 0; i < n; i++) rtn[y, i] = true; // 세로
			for (int i = 0; i < n; i++) rtn[i, x] = true; // 가로
			for (int i = 0; i < n; i++)
			{
				if (y + i < n)
				{
					if (x + i < n) rtn[y + i, x + i] = true;
					if (x - i >= 0) rtn[y + i, x - i] = true;
				}
				if (y - i >= 0)
				{
					if (x + i < n) rtn[y - i, x + i] = true;
					if (x - i >= 0) rtn[y - i, x - i] = true;
				}
			}
			return rtn;
		}

		static void Check(bool[,] board, int n)
		{
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					string x = board[i,j] ? "O" : "X";
					Write(x);
				}
				Write("\n");
			}
			Write("\n");
		}
		static int NQueen(bool[,] board, int row, int n)
		{
			//Check(board, n);
			int rtn = 0;
			//row가 끝까지 도달한 경우
			if (row == n)
			{
				return 1;
			}
			for (int i = 0; i < n; i++)
			{
				if (!board[row, i]) // 가능한 칸인 경우
				{
					rtn += NQueen(Remove(board, row, i, n), row+1, n);
				}
			}

			return rtn ;
		}
		static void Main()
		{
			int n = int.Parse(ReadLine());
			bool[,] board = new bool[n, n];
			int ans = 0;
			for (int i = 0; i < n; i++)
			{
				ans += NQueen(Remove(board, 0, i, n), 1, n);
			}
			Write(ans);
		}
	}
}


/*
1. 모든 행에 대해 loop. 행의 각 위치마다 퀸을 배치한다.
2. 퀸으로 인해 발생하는 먹히는 상황이 발생하는 칸을 배제
3. 각 열에 대해, 퀸이 배치될 수 있는 칸에 대해 백트래킹 실시
*/