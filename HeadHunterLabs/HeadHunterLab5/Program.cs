using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadHunterLab5
{
    class Program
    {
        //Определим функцию P(n, k) следующим образом: P(n, k) = 1, если n может быть представлено в виде суммы k простых чисел(простые числа в записи могут повторяться, 1 не является простым числом) и P(n, k) = 0 в обратном случае.
        //К примеру, P(10, 2) = 1, т.к. 10 может быть представлено в виде суммы 3 + 7 или 5 + 5, а P(11,2) = 0, так как никакие два простых числа не могут дать в сумме 11.
        //Определим функцию S(n) как сумму значений функции P(i, k) для всех i и k, таких что 1≤i≤n, 1≤k≤n.Таким образом, S(2) = P(1, 1) + P(2, 1) + P(1, 2) + P(2, 2) = 1, S(10) = 20, S(1000) = 248838.
        //Найдите S(12232).
        //Ответ: 37390032


        static Dictionary<int, bool[]> savedNums;

        static List<int> simpleNumbers;

        static void Main(string[] args)
        {
            int num = 12232; //до какого числа раскладывать
            int sum = 0; //общая сумма
            int stepSum = 0;
            int maxSavedNum = num; //до какого числа сохраняем статистику
            savedNums = new Dictionary<int, bool[]>(); //статистика разложения

            FindSimple(num * 2);

            //для каждого числа
            for (int i = 2; i <= num; i++)
            {
                bool[] status = new bool[i]; //статистика данного числа по кол-ву слагаемых
                RecurCalc(i, 0, status); //рекурсивно ищем кол-во слагаемых

                //до макс числа сохраняем статистику
                if (i <= maxSavedNum)
                {
                    savedNums.Add(i, status);
                }

                //суммируем кол-во разложений
                stepSum = 0;
                for (int k = 0; k < i; k++)
                {
                    if (status[k] == true) stepSum++;
                }
                sum += stepSum;

                if (i%100==0) Console.WriteLine(i + "->" + stepSum);
            }


            Console.WriteLine("Ответ: " + sum);
            Console.ReadLine();
        }

        /// <summary>
        /// Поиск простых чисел
        /// </summary>
        /// <param name="num">Максимальное простое число</param>
        static void FindSimple(int num)
        {
            simpleNumbers = new List<int>();
            simpleNumbers.Add(2);

            bool flag = true;

            //для каждого числа
            for (int i = 3; i <= num; i++)
            {
                flag = true;
                //для каждого предыдущего простого числа
                for (int k = 0; k < simpleNumbers.Count; k++)
                {
                    //проверяем делится ли текущее число на простое
                    if (i % simpleNumbers[k] == 0)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag == true)
                {
                    simpleNumbers.Add(i);
                }
            }
        }


        /// <summary>
        /// Рекурсивное разложение на слагаемые
        /// </summary>
        /// <param name="n">Число для разложения</param>
        /// <param name="depth">Кол-во слагаемых, которые уже вычли из числа</param>
        /// <param name="status">Массив, status[x]=true если число раскладывается на x множителей</param>
        static void RecurCalc(int n, int depth, bool[] status)
        {
            //для всех простых чисел, которые меньше нашего числа
            for (int i = 0; simpleNumbers[i] <= n; i++)
            {
                int newN = n - simpleNumbers[i];

                //если число не разложено до конца
                if (newN >= 2)
                {
                    //если для остатка числа есть статистика
                    if (savedNums.ContainsKey(newN))
                    {
                        //просто копируем ее
                        bool[] saved = savedNums[newN];
                        for (int z = 0; z < saved.Length; z++)
                        {
                            if (saved[z] == true) status[depth + 1 + z] = true;
                        }
                    }
                    //иначе входим в рекурсию
                    else
                    {
                        RecurCalc(newN, depth + 1, status);
                    }
                }
                //иначе помечаем, что число раскладывается на depth множителей
                else if (newN == 0)
                {
                    status[depth] = true;
                    return;
                }

            }

        }
    }
}
