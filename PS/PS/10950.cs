using static System.Console;

namespace _10950{
    class AB{
        static void Main(){
            int n= int.Parse(ReadLine());
            for (int i = 0; i < n; i++){
                string[] ab = ReadLine().Split();
                Write($"{int.Parse(ab[0]) + int.Parse(ab[1])}\n");
            }
        }
    }
    
}
