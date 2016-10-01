using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace HeadHunterLab6
{
    class Program
    {

        //Если мы возьмем 47, перевернем его и сложим, получится 47 + 74 = 121 — число-палиндром.

        //Если взять 349 и проделать над ним эту операцию три раза, то тоже получится палиндром: 
        //349 + 943 = 1292
        //1292 + 2921 = 4213
        //4213 + 3124 = 7337

        //Найдите количество положительных натуральных чисел меньших 12222 таких, что из них нельзя получить палиндром за 50 или менее применений описанной операции(операция должна быть применена хотя бы один раз).

        //Ответ: 319

        static void Main(string[] args)
        {

            int max = 12222;

            BigInteger cur, inverse; //текущее число и перевернутое
            char[] curChars; //символы текущего числа
            string curStr;
            bool flag; //флаг, является ли число полиндромом


            int polyndromsCount = 0;

            //для каждого числа
            for (int i = 1; i < max; i++)
            {
                cur = i;
                //суммируем с инверсией 50 раз
                for (int k = 0; k < 50; k++)
                {
                    //получаем инверсию
                    curChars = cur.ToString().ToCharArray();
                    Array.Reverse(curChars);
                    inverse = BigInteger.Parse(new string(curChars));

                    //суммируем
                    cur = cur + inverse;
                    curStr = cur.ToString();

                    //проверяем, является ли полиндромом
                    flag = true;
                    for (int m = 0; m <= (curStr.Length / 2); m++)
                    {
                        if (curStr[m] != curStr[curStr.Length - 1 - m])
                        {
                            flag = false;
                            break;
                        }
                    }

                    //увеличиваем счетчик
                    if (flag == true)
                    {
                        polyndromsCount++;
                        break;
                    }

                }
            }

            //количество неполиндромов
            Console.WriteLine("Ответ: " + (max - 1 - polyndromsCount));
            Console.ReadLine();
        }
    }
}
