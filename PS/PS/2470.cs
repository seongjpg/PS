using static System.Console;

namespace _2470
{
    class FrontEnd
    {
        static void Main()
        {
            int n = int.Parse(ReadLine());
            string[] str = ReadLine().Split();
            int[] arr = new int[n];
            for (int i = 0; i < n; i++) arr[i] = int.Parse(str[i]);
            Array.Sort(arr);
            int front = 0; int end = arr.Length-1; // 앞과 뒤를 가리키는 인덱스 설정
            int amt = int.MaxValue;
            int ansF = 0; int ansE = arr.Length - 1;
            while (front < end)
            {
                int mix = arr[front] + arr[end];
                int absMix = Math.Abs(mix);
                if (Math.Abs(mix) < amt) {
                    // 새로운 값과 현재 amt와의 절댓값을 비교. 새로운 값이 더 작은 경우 amt, ansF, ansE 갱신. 
                    amt = absMix;
                    ansF = front; ansE = end;                
                }
                if (amt == 0) break; // 이것때문에 TLE가 발생하는 문제..
                if (mix > 0) end--; // mix의 값이 양수인 경우, end 인덱스를 1 감소
                else if (mix < 0) front++; // mix 값이 음수인 경우, front 인덱스를 1 증가.
            }
            Write($"{arr[ansF]} {arr[ansE]}");
        }
    }
}