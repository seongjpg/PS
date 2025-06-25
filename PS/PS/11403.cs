using static System.Console;
using System.Collections.Generic;

namespace _11403
{
    class FIndRoad
    {
        static void BFS(int s, int n, int[][] gr, int[][] ar)
        {
            bool[] visited = new bool[n];
            Queue<int> q = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                if (gr[s][i] == 1) q.Enqueue(i); 
            }
            while (q.Count > 0)
            {
                int x = q.Dequeue();
                if (!visited[x])
                {
                    visited[x] = true;
                    for (int i = 0; i < n; i++)
                    {
                        if (gr[x][i] == 1)
                        {
                            q.Enqueue(i);
                        }
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (visited[i])ar[s][i] = 1;
            }
        }
        static void Main()
        {
            int n = int.Parse(ReadLine());
            int[][] ableRoad = new int[n][];
            int[][] givenRoad = new int[n][];

            for (int i = 0; i < n; i++)
            {

                string[] r = ReadLine().Split();
                int[] roads = new int[n];
                int[] nRoad = new int[n];
                ableRoad[i] = roads;
                for (int j = 0; j < n; j++)
                    roads[j] = int.Parse(r[j]);
                givenRoad[i] = roads;
            }
            //인접행렬의 전 원소에 대해 경로탐색 수행
            for (int i = 0; i < n; i++)
            {
                BFS(i, n, givenRoad, ableRoad);
            }

            //출력부
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Write($"{ableRoad[i][j]} ");
                }
                Write("\n");
            }

        }
    }
}