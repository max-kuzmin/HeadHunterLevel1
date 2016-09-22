using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadHunterLab4
{
    class Program
    {
        //Дано равенство, в котором цифры заменены на буквы:
        //rxxv + rqq = ryxv

        //Найдите сколько у него решений, если различным буквам соответствуют различные цифры(ведущих нулей в числе не бывает).
        //Ответ: 450

        static void Main(string[] args)
        {
            int r, x, q, v, y;
            int one, two, sum;
            int count = 0;

            //полным перебором проверяем все цифры
            for (r = 1; r <= 9; r++)
            {
                for (x = 0; x <= 9; x++)
                {
                    for (q = 0; q <= 9; q++)
                    {
                        for (v = 0; v <= 9; v++)
                        {
                            for (y = 0; y <= 9; y++)
                            {
                                //составляем числа из цифр
                                one = int.Parse(r.ToString() + x.ToString() + x.ToString() + v.ToString());
                                two = int.Parse(r.ToString() + q.ToString() + q.ToString());
                                sum = int.Parse(r.ToString() + y.ToString() + x.ToString() + v.ToString());

                                //сравниваем
                                if (one + two == sum)
                                {
                                    count++;
                                    Console.WriteLine(one.ToString() + "+" + two.ToString() + "=" + sum.ToString());
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Ответ: " + count);
            Console.ReadLine();
        }
    }
}
