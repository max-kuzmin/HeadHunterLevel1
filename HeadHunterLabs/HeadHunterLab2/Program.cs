using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadHunterLab2
{
    class Program
    {

        //В некоторых числах можно найти последовательности цифр, которые в сумме дают 10. К примеру, в числе 3523014 целых четыре таких последовательности:
        //3523014
        //3523014
        //3523014
        //3523014

        //Можно найти и такие замечательные числа, каждая цифра которых входит в по крайней мере одну такую последовательность.
        //Например, 3523014 является замечательным числом, а 28546 — нет (в нём нет последовательности цифр, дающей в сумме 10 и при этом включающей 5). 

        //Найдите количество этих замечательных чисел в интервале[1, 1900000] (обе границы — включительно).
        //Ответ: 38535

        static void Main(string[] args)
        {

            int n = 1900000; //макс число
            int count = 0; //кол-во замечательных чисел
            int sum;
            string str;
            int i, k, m, s;
            bool[] states = new bool[10]; //показывает, входят ли цифры числа в последовательности

            //для всех чисел интервала
            for (i = 1; i <= n; i++)
            {
                str = i.ToString();
                sum = 0;

                //проверка что сумма всех чисел не меньше 10
                for (k = 0; k < str.Length; k++)
                {
                    sum += str[k] - 48;
                    states[k] = false;
                }
                if (sum < 10) continue;

                //для каждого символа, кроме последнего
                for (k = 0; k < (str.Length - 1); k++)
                {
                    sum = 0;
                    //начиная с него находим цепочку символов, чья сумма = 10
                    for (m = k; m < str.Length; m++)
                    {
                        sum += str[m] - 48;
                        if (sum == 10)
                        {
                            //если цепочка найдена, помечаем цифры
                            for (s = k; s <= m; s++)
                            {
                                states[s] = true;
                            }
                            break;
                        }
                        else if (sum > 10) break;
                    }

                    //если дошли до конца числа, выход из цикла
                    //if (m == (str.Length - 1)) break;
                }

                //проверяем все цифры числа, входят ли они в цепочки
                for (k = 0; k < str.Length; k++)
                {
                    if (states[k] == false) break;
                    else if (k == (str.Length - 1))
                    {
                        count++;
                        if (count % 10000 == 0) Console.WriteLine(i);
                    }
                }


            }

            Console.WriteLine("Ответ: " + count);
            Console.ReadLine();
        }
    }
}
