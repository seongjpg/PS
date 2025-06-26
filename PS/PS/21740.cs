using static System.Console;
using System.Text;

namespace _21740
{
    class DODO
    {

        static string Reverse(string x)
        {
            string rtn = "";
            for (int i = x.Length - 1; i >= 0; i--)
            {
                switch (x[i])
                {
                    case '0':
                        rtn += "0";
                        break;
                    case '1':
                        rtn += "1";
                        break;
                    case '2':
                        rtn += "2";
                        break;
                    case '5':
                        rtn += "5";
                        break;
                    case '6':
                        rtn += "9";
                        break;
                    case '8':
                        rtn += "8";
                        break;
                    case '9':
                        rtn += "6";
                        break;
                }
            }
            return rtn;
        }

        static bool CMP(string reStr, string chall)
        {
            //가장 중요한 건 길이
            if (reStr.Length < chall.Length)
                return true;
            //길이가 같은 경우, 뒤집은 숫자의 크기 비교
            else if (reStr.Length == chall.Length)
            {
                string rRev = Reverse(reStr);
                string cRev = Reverse(chall);
                //Write($"cmp : {rRev} {cRev}\n");
                for (int j = 0; j < rRev.Length; j++)
                {
                    if (Convert.ToInt32(rRev[j]) < Convert.ToInt32(cRev[j]))
                    {
                        return true;
                        //21 -> 12
                        //12 -> 21
                    }
                    else if (Convert.ToInt32(rRev[j]) > Convert.ToInt32(cRev[j]))
                        return false;
                }
            }
            return false;
        }
        static void Main()
        {
            StringBuilder sb = new StringBuilder();
            int n = int.Parse(ReadLine());
            string[] arr = ReadLine().Split();
            List<string> strs = new List<string>();
            for (int i = 0; i < n; i++)
                strs.Add(arr[i]);

            //한 번 더 쓸 녀셕 정하기-reuse
            int reuse = 0;

            for (int i = 0; i < n; i++)
            {
                string reStr = strs[reuse];
                string chall = strs[i];
                //길이 비교
                reuse = CMP(reStr, chall) ? i : reuse;
            }
            //Write($"reuse string : {strs[reuse]}\n");
            strs.Add(strs[reuse]);
            strs.Sort((a, b) =>
            {
                int rtn = 0;
                int aLen = a.Length; int bLen = b.Length;
                string arev = Reverse(a); string brev = Reverse(b);
                int len = aLen*bLen;
                for (int i = 0; i < len; i++)
                {
                    rtn = Convert.ToInt32(arev[i % aLen]).CompareTo(Convert.ToInt32(brev[i % bLen]));
                    if (rtn != 0) break;
                }
                return rtn;
            });
            for (int i = 0; i <= n; i++)
            {
                sb.Append(strs[i]);
            }
            sb.Append("\n");
            //debug
            /*
             sb.Append("\nreversed : ");
            for (int i = n; i>=0; i--)
            {
                string rev = Reverse(strs[i]);
                sb.Append(rev);
            }
            */
            Write(sb);
        }
    }
}