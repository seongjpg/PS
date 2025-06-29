using static System.Console;
using System.Collections.Generic;

namespace _4485
{
    class Link
    {
        struct Amt
        {
            public int v;
            public int x;
            public int y;
        }
        static void Main(){
            int n = int.Parse(ReadLine());
            int cnt = 0;
            while (n != 0)
            {
                cnt++;
                int[,] rupee = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    string[] r = ReadLine().Split();
                    for (int j = 0; j < n; j++)
                    {
                        rupee[i, j] = int.Parse(r[j]);
                    }
                }
                int[,] minLost = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                        minLost[i, j] = 100000000;
                }
                PriorityQueue<Amt, int> forwardStat = new PriorityQueue<Amt, int>();
                Amt amtStat = new Amt();
                amtStat.v = rupee[0, 0]; amtStat.x = 0; amtStat.y = 0;
                forwardStat.Enqueue(amtStat, amtStat.v);

                while (forwardStat.Count > 0)
                {
                    amtStat = forwardStat.Dequeue();
                    if (amtStat.x == n-1 && amtStat.y == n - 1)
                    {
                        Write($"Problem {cnt}: {amtStat.v}\n");
                        break;
                    }
                    minLost[amtStat.y, amtStat.x] = amtStat.v;
                   // Write($"{amtStat.y}, {amtStat.x}\namt : {amtStat.v}\n");
                    //상
                    if (amtStat.y > 0)
                    {
                        if (amtStat.v + rupee[amtStat.y-1, amtStat.x] < minLost[amtStat.y-1, amtStat.x])
                        {
                            Amt newElem = new Amt();
                            newElem.v = amtStat.v + rupee[amtStat.y - 1, amtStat.x];
                            newElem.y = amtStat.y - 1; newElem.x = amtStat.x;
                            forwardStat.Enqueue(newElem, newElem.v);
                        }
                    }

                    //하
                    if (amtStat.y < n-1)
                    {
                        if (amtStat.v + rupee[amtStat.y + 1, amtStat.x] < minLost[amtStat.y + 1, amtStat.x])
                        {
                            Amt newElem = new Amt();
                            newElem.v = amtStat.v + rupee[amtStat.y + 1, amtStat.x];
                            newElem.y = amtStat.y + 1; newElem.x = amtStat.x;
                            forwardStat.Enqueue(newElem, newElem.v);
                        }
                    }

                    //좌
                    if (amtStat.x > 0)
                    {
                        if (amtStat.v + rupee[amtStat.y, amtStat.x - 1] < minLost[amtStat.y, amtStat.x - 1])
                        {
                            Amt newElem = new Amt();
                            newElem.v = amtStat.v + rupee[amtStat.y, amtStat.x - 1];
                            newElem.y = amtStat.y; newElem.x = amtStat.x - 1;
                            forwardStat.Enqueue(newElem, newElem.v);
                        }
                    }

                    //우
                    if (amtStat.x < n-1)
                    {
                        if (amtStat.v + rupee[amtStat.y, amtStat.x+1] < minLost[amtStat.y , amtStat.x + 1])
                        {
                            Amt newElem = new Amt();
                            newElem.v = amtStat.v + rupee[amtStat.y, amtStat.x + 1];
                            newElem.y = amtStat.y; newElem.x = amtStat.x + 1;
                            forwardStat.Enqueue(newElem, newElem.v);
                        }
                    }
                    
                }

               
                n = int.Parse(ReadLine());
            }
            
            
            
        }
    }
}


/*
 1. 구조체(배열도 ㄱㅊ)를 선언. (현재 먹은 도둑루피 + 뻗어나갈 곳에 있는 도둑루피), 뻗어나갈 위치의 좌표값을 보유함.
2. 도둑루피의 값을 기준으로 최소힙 적용, 현재 방향으로 가지 않은 방향을 우선순위 큐에 삽입.
3. 꺼낸 위치의 좌표값이 n-1, n-1인 경우 출력
 */