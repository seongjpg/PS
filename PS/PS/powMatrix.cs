using static System.Console;

namespace MatrixSquare {
	class PowMatrix {

		//행렬곱
		static int[,] Multiple(int[,] mat1, int[,] mat2, int n)
		{
			int[,] rtn = new int[n, n];
			for (int i = 0; i < n; i++) {
				for (int j = 0; j < n; j++) {
					for (int k = 0; k < n; k++) {
						rtn[i, j] += (mat1[i, k] * mat2[k, j]);
					}
					rtn[i, j] %= 1000;
				}
			}
			return rtn;
		}
		//출력부
		static void PrintMatrix(int[,] mat, int n)
		{
			for (int i = 0; i < n; i++) {
				for (int j = 0; j < n; j++) {
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
			for (int i = 0; i < n; i++) ans[i, i] = 1; // ans를 단위행렬로 변환.
			while (b > 0)
			{
				if ((b & 1) == 1) // b를 binary로 보았을 때, 1로 끝나는 경우(즉 홀수일 때).
					ans = Multiple(ans, mat, n); // b가 홀수인 경우, ans에 mat를 곱해준다. 
				mat = Multiple(mat, mat, n); // b가 짝수인 경우, mat끼리 서로 곱해준다.
				b >>= 1;
			}
			PrintMatrix(ans, n);
		}
	}
}
/*
 b == 12인 경우,
m -> m^2, b -> 6.
m^2 -> m^4, b -> 3.
ans -> m^4, m^4 -> m^8, b -> 1.
ans -> m^12. k = 0
기본적으로 사용하는 개념은 분할 정복 기법이지만, 함수 호출로 분할 정복을 하면 스택 오버플로우가 발생한다.
스택 오버플로우를 방지하기 위해, while 문으로 기본적으로 사용되는 개념인
b %= 2 == 0 -> a * a
b %= 2 == 1 -> a * a * 1
다음 연산을 동일하게 적용할 수 있도록 적절히 변환하여 구현한다.그게 43-49번 라인.

혹은, 미리 테이블에 구현하는 수도 있다. 본질적으로는 큰 차이가 없다.
43-49 라인에서, shift 연산을 사용하여 약간의 메모리와 시간상 이득을 볼 수 있다. 일반적인 사칙 연산으로 대체해도 무방.
 */
