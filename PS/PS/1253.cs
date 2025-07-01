using static System.Console;

namespace _1253
{
    class Good
    {
        static int BinarySearch(List<int[]> arr, int val)
        {

            int start = 1; int end = arr.Count - 1;
            int id = (start + end) / 2;
            int cnt = 0;
            while (arr[id][0] != val)
            {
                cnt++;
                if (arr[id][0] < val)
                    (start, end) = (id + 1, end);
                if (arr[id][0] > val)
                    (start, end) = (start, id);
                id = (start + end) / 2;
                if (cnt > 30)
                {
                    id = -1; break;
                }
            }
            return id;
        }
        static void Main()
        {
            int n = int.Parse(ReadLine());
            string[] x = ReadLine().Split();
            List<int[]> amt = new List<int[]>() { };
            List<int[]> originAmt = new List<int[]>() { };
            int[] fakeInts = { int.MinValue, 0 };
            int ans = 0;
            amt.Add(fakeInts);
            originAmt.Add(fakeInts);
            int[] ints = new int[n];
            for (int i = 0; i < n; i++)
            {
                ints[i] = int.Parse(x[i]);
            }
            Array.Sort(ints);
            for (int i = 0; i < n; i++)
            {
                if (amt[amt.Count - 1][0] != ints[i])
                {
                    int[] add = { ints[i], 1 };
                    int[] originAdd = { ints[i], 1 };
                    amt.Add(add);
                    originAmt.Add(originAdd);
                }
                else
                {
                    amt[amt.Count - 1][1]++;
                    originAmt[amt.Count - 1][1]++;
                }
                    
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i+1; j < n; j++)
                {
                    int a = ints[i]; int b = ints[j];
                    int id = BinarySearch(amt, a + b);
                    if (id >= 1 && amt[id][1] > 0)
                    {
                        
                        if ((((a == 0 && b != 0) || (a != 0 && b == 0)) && originAmt[id][1] <= 1) || ((a == 0 && b == 0 && originAmt[id][1] <= 2)))
                        {
                            //Write($"{(((a == 0 && b != 0) || (a != 0 && b == 0)) && originAmt[id][1] <= 1)}\n");
                        }
                        else
                        {
                            ans += amt[id][1]; amt[id][1] = 0;
                        }
                        
                    }
                }
            }
            Write(ans);
        }
    }
}

/*
 반례
3
0 5 5

3
0 0 1

ans : 0
output : 3

3
0 -5 5

ans : 1
output : 3

0과 더해지면 본인이 나오기에, 그 상황이 문제가 됨. 그렇지만 0과 더해지는 수가 두개 이상 입력된 상태면 문제 없음.

 */