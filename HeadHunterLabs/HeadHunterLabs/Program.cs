using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadHunterLabs
{
    class Program
    {
        //Рассмотрим спираль, в которой, начиная с 1 в центре, последовательно расставим числа по часовой стрелке, 
        //пока не получится спираль 5 на 5 

        //21 22 23 24 25
        //20  7  8  9 10
        //19  6  1  2 11
        //18  5  4  3 12
        //17 16 15 14 13
        //Можно проверить, что сумма всех чисел на диагоналях равна 101. 

        //Чему будет равна сумма чисел на диагоналях, для спирали размером 1169 на 1169?

        //Ответ: 1065691377

        static void Main(string[] args)
        {
            int n = 1169;
            int halfSize = (n - 1) / 2; //количество кругов без учета внутренней единицы

            long sum = 1; //сумма всех диагональных чисел
            int curNum; //число, которое на данном круге возводим в квадрат, на каждом круге прибавляем к нему 2
            int curQuad = 1; //квадрат этого числа

            for (int i = 0; i < halfSize; i++)
            {
                curQuad+=2;

                curNum = curQuad * curQuad;

                for (int k = 0; k < 4; k++)
                {
                    sum += curNum;
                    curNum -= (curQuad - 1);
                }
            }

            Console.WriteLine("Ответ: " + sum);
            Console.ReadLine();
        }
    }
}
