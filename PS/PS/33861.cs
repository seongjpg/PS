using static System.Console;
using System.Text;

namespace PS
{
    class _33861
    {
        static void Main()
        {
            int n = int.Parse(ReadLine());
            StringBuilder ans = new StringBuilder();
            //n이 1, 2인 경우는 불가능.
            if (n == 1 || n == 2) ans.Append("NO");
            else
            {
                ans.Append("YES\n");
                int[,] table_2by3 = { { 1, 1 }, { 2, 2 }, { 1, 3 }, { 2, 1 }, { 1, 2 }, { 2, 3 } };
                int[,] table_2by4 = { { 1, 1 }, { 2, 2 }, { 1, 4 }, { 2, 3 }, { 1, 2 }, { 2, 1 }, { 1, 3 }, { 2, 4 } };
                int[,] table_2by5 = { { 1, 1 }, { 2, 2 }, { 1, 4 }, { 2, 5 }, { 1, 3 }, { 2, 4 }, { 1, 5 }, { 2, 3 }, { 1, 2 }, { 2, 1 } };
                int add = 0;

                while (n >= 6)
                {
                    for (int i = 0; i < 6; i++) ans.Append($"{table_2by3[i,0]} {table_2by3[i,1] + add}\n");
                    add += 3;
                    n -= 3;
                }
                switch (n){
                    case 3:
                        for (int i = 0; i < 6; i++) ans.Append($"{table_2by3[i, 0]} {table_2by3[i, 1] + add}\n");
                        break;
                    case 4:
                        for (int i = 0; i < 8; i++) ans.Append($"{table_2by4[i, 0]} {table_2by4[i, 1] + add}\n");
                        break;
                    case 5:
                        for (int i = 0; i < 10; i++) ans.Append($"{table_2by5[i, 0]} {table_2by5[i, 1] + add}\n");
                        break;
                }
            }
            Write(ans);
        }
    }
}

/*
n == 3인 경우
1 5 3
4 2 6
의 방문 순서를 거쳐 가능.

n == 4인 경우
1 5 7 3
6 2 4 8
의 방문 순서를 거쳐 가능.

n == 5인 경우
1 9 5 3 7
10 2 8 6 4
의 방문 순서를 거쳐 가능.

따라서, n == 1, n == 2인 경우를 제외한 모든 자연수에 대해 이동이 가능하다.
 */