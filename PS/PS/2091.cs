using static System.Console;

namespace _2091
{
    class Coin
    {
        static void Main(){
            string[] coins = ReadLine().Split();
            int charge = int.Parse(coins[0]); 
            int cent = int.Parse(coins[1]); int nickel = int.Parse(coins[2]); 
            int dime = int.Parse(coins[3]); int quarter = int.Parse(coins[4]);
            int[] quantity = { 1, 5, 10, 25 };
            int[] amt = { cent, nickel, dime, quarter };
            int[,] coin = new int[4, charge+1];
            int[,,] eachCoin = new int[4, charge + 1, 4];
            int[,] add = { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
            //1센트만으로 채워지는 경우 표현. 만일 동전이 부족한 경우, -1로 표현
            for (int i = 1; i <= charge; i++)
            {
                if (cent >= i)
                {
                    coin[0, i] = i;
                    eachCoin[0, i, 0] = i;
                }
                else
                {
                    coin[0, i] = -1;
                    eachCoin[0, i, 0] = -1;
                }
            }
                

            for (int i = 1; i < 4; i++)
            {
                int cur = quantity[i]; // 현재 선택한 동전의 값어치

                for (int j = 1; j <= charge; j++)
                {
                    //j는 현재 확인하고 있는 비용, 이 비용이 cur보다 작으면 위의 원소를 고정적으로 가져와야 한다.
                    if (cur > j)
                    {
                        coin[i, j] = coin[i - 1, j];
                        eachCoin[i, j, 0] = eachCoin[i - 1, j, 0]; eachCoin[i, j, 1] = eachCoin[i - 1, j, 1];
                        eachCoin[i, j, 2] = eachCoin[i - 1, j, 2]; eachCoin[i, j, 3] = eachCoin[i - 1, j, 3];
                    }
                        
                    //cur 이상의 값을 가지는 경우
                    else
                    {
                        //coin[i, j - cur] + 1과 coin[i - 1, j]의 비용을 비교하여, 큰 걸 coin[i, j]에 삽입
                        if (coin[i, j - cur] + 1 > coin[i - 1, j] && eachCoin[i, j-cur, i] + 1 <= amt[i]) // 왼쪽에서 가져옴
                        {
                            coin[i, j] = coin[i, j - cur] + 1;
                            eachCoin[i, j, 0] = eachCoin[i, j - cur, 0]; eachCoin[i, j, 1] = eachCoin[i, j - cur, 1];
                            eachCoin[i, j, 2] = eachCoin[i, j - cur, 2]; eachCoin[i, j, 3] = eachCoin[i, j - cur, 3];
                            eachCoin[i, j, i]++;
                        }
                        else
                        {
                            coin[i, j] = coin[i - 1, j];
                            eachCoin[i, j, 0] = eachCoin[i - 1, j, 0]; eachCoin[i, j, 1] = eachCoin[i - 1, j, 1];
                            eachCoin[i, j, 2] = eachCoin[i - 1, j, 2]; eachCoin[i, j, 3] = eachCoin[i - 1, j, 3];
                        }
                        

                    }
                }
            }
            //debug
            /*
            for (int i = 0; i < 4; i++)
            {
                Write($"amt : {quantity[i]}\n");
                for (int j = 0; j <= charge; j++)
                {
                    Write($"{coin[i, j]} ");
                }
                Write("\n");
            }
            */
            if (eachCoin[3, charge, 0] < 0 || eachCoin[3, charge, 1] < 0 || eachCoin[3, charge, 2] <0 || eachCoin[3, charge, 3] < 0)
                eachCoin[3, charge, 0] = eachCoin[3, charge, 1] = eachCoin[3, charge, 2] = eachCoin[3, charge, 3] = 0;

            Write($"{eachCoin[3, charge, 0]} {eachCoin[3, charge, 1]} {eachCoin[3, charge, 2]} {eachCoin[3, charge, 3]}");
        }
    }
}

//dp로 풀기