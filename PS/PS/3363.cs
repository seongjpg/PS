using static System.Console;

namespace _3363
{
    class Coin
    {
        static void Main()
        {
            List<string[]> strings = new List<string[]>();
            string[] isFake = new string[13];
            string ans = "";
            for (int i = 0; i < 3; i++)
            {
                string str = ReadLine();
                if (string.IsNullOrWhiteSpace(str))
                {
                    //Write($"detect {str}\n");
                    str = ReadLine();
                }
                string[] arr = str.Split();
                    if (arr[4] == ">") // x x x x < y y y y 형태를 일관적으로 유지시키고 싶음
                    {
                        (arr[0], arr[8]) = (arr[8], arr[0]);
                        (arr[1], arr[7]) = (arr[7], arr[1]);
                        (arr[2], arr[6]) = (arr[6], arr[2]);
                        (arr[3], arr[5]) = (arr[5], arr[3]);
                        arr[4] = "<";
                    }
                    strings.Add(arr);
                    //for (int j = 0; j < 9; j++) Write($"{arr[j]} ");
                    //Write("\n");
            }
                        
            for (int i = 0; i < strings.Count; i++)
            {
                if (strings[i][4] == "<")
                {
                    bool[] arr = new bool[13];
                    //왼쪽은 "-", 오른쪽은 "+" isFake에 적기.
                    for (int j = 0; j < 4; j++)
                    {
                        int id = int.Parse(strings[i][j]);
                        arr[id] = true;
                        
                        if (isFake[id] == "+" || isFake[id] == "0")
                            isFake[id] = "0";
                        else isFake[id] = "-";
                    }
                    for (int j = 5; j < 9; j++)
                    {
                        int id = int.Parse(strings[i][j]);
                        arr[id] = true;
                        
                        if (isFake[id] == "-" || isFake[id] == "0")
                            isFake[id] = "0";
                        else isFake[id] = "+";
                    }
                    for (int j = 1; j < 13; j++)
                    {
                        if (!arr[j]) isFake[j] = "0"; 
                    }
                }
                if (strings[i][4] == "=") // isFake의 후보에서 제거.
                {
                    for (int j = 0; j <4;  j++)
                    {
                        int id = int.Parse(strings[i][j]);
  
                        isFake[id] = "0";
                        //Write($"id : {id}\n");
                    }
                    for (int j = 5; j < 9;  j++)
                    {
                        int id = int.Parse(strings[i][j]);

                        isFake[id] = "0";
                        //Write($"id : {id}\n");
                    }
                }
                //for (int t = 1; t < 13; t++) Write($"{t} : {isFake[t]} \n");
                //Write("\n");
            }
            int cntMinus = 0; int cntPlus = 0; int cntZero = 0;
            for (int i = 1; i < 13; i++)
            {
                switch (isFake[i])
                {
                    case "-":
                        cntMinus++;
                        break;
                    case "0":
                        cntZero++;
                        break;
                    case "+":
                        cntPlus++;
                        break;
                }                    
            }

            //정상
            if ((cntMinus == 1 && cntPlus == 0) || (cntPlus == 1 && cntMinus == 0))
            {
                for (int i = 1; i < 13; i++)
                {
                    if (isFake[i] != "0")
                    {
                        ans = $"{i}{isFake[i]}";
                        break;
                    }
                }
            }
            else if (cntZero == 12)
                ans = "impossible";
            else ans = "indefinite";
            WriteLine(ans);

        }
    }
}