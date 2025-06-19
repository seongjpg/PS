using static System.Console;
using System.Collections.Generic;

namespace _11000
{
    class ClassRom
    {
        static void Main()
        {
            StreamReader rd = new StreamReader(Console.OpenStandardInput());
            int n = int.Parse(rd.ReadLine());
            int[][] classes = new int[n][];
            for (int i = 0; i < n; i++)
            {
                string[] st = rd.ReadLine().Split();
                classes[i] = new int[] { int.Parse(st[0]), int.Parse(st[1]) };
            }
            Array.Sort(classes, (a, b) => a[0].CompareTo(b[0]) == 0 ? a[1].CompareTo(b[1]) : a[0].CompareTo(b[0]));
            //Debug
            //for (int i = 0; i < n; i++) Write($"{classes[i][0]} {classes[i][1]}\n");
            PriorityQueue<int, int> end = new PriorityQueue<int, int>();
            end.Enqueue(0, 0);
            for (int i = 0; i < classes.Length; i++)
            {
                //마지막으로 끝난 수업이 현재 확인하는 수업보다 일찍 끝난 경우 - 한 강의실에 배정 가능하므로 minheap의 제일 앞 원소를 갱신.
                int elem = end.Dequeue();
                if (elem <= classes[i][0])
                {
                    //debug
                    //Write($"change {elem} -> {classes[i][1]}\n");
                    elem = classes[i][1];
                }

                //그렇지 않은 경우 다른 강의실에 배정해야 하므로 우선순위 큐에 추가.
                else
                {
                    //debug
                    //Write($"add {classes[i][1]}\n");
                    end.Enqueue(classes[i][1], classes[i][1]);
                }
                    

                end.Enqueue(elem, elem);
            }            
            Write(end.Count);
        }
    }
}