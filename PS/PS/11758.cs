using static System.Console;

namespace _11758
{
    class CCW
    {
        static int IsCCW(double dx_1, double dy_1, double dx_2, double dy_2)
        {
            int rtn = 0;
            if (dy_1 / dx_1 == dy_2 / dx_2) return 0;
            decimal l_1 = Convert.ToDecimal(Math.Sqrt(dx_1 * dx_1 + dy_1 * dy_1));
            decimal l_2 = Convert.ToDecimal(Math.Sqrt(dx_2 * dx_2 + dy_2 * dy_2));
            decimal s_1 = Convert.ToDecimal(dy_1) / l_1; decimal s_2 = Convert.ToDecimal(dy_2) / l_2;
            decimal c_1 = Convert.ToDecimal(dx_1) / l_1; decimal c_2 = Convert.ToDecimal(dx_2) / l_2;
            decimal sin = s_1*c_2 - s_2*c_1;

            if (sin == 0) return 0;
            //Write($"sin : {sin}\n");
            return sin > 0 ? -1 : 1;
        }
        static void Main()
        {
            double[][] p = new double[3][];
            double dx_1, dy_1, dx_2, dy_2;
            for (int i = 0; i < 3; i++)
            {
                string[] str = ReadLine().Split();
                double[] px = { double.Parse(str[0]), double.Parse(str[1]) };
                p[i] = px;
            }
            //dx_1, dy_1은 p2-p1의 변량, dx_2, dy_2는 p3-p1의 변량
            dx_1 = p[1][0] - p[0][0]; dx_2 = p[2][0] - p[0][0];
            dy_1 = p[1][1] - p[0][1]; dy_2 = p[2][1] - p[0][1];
            Write(IsCCW(dx_1, dy_1, dx_2, dy_2));
        }
    }
}