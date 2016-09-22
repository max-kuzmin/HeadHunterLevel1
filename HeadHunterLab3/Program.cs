using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadHunterLab3
{
    class Program
    {
        //Число 125874 и результат умножения его на 2 — 251748 можно получить друг из друга перестановкой цифр.

        //Найдите наименьшее положительное натуральное x такое, что числа 5*x, 6*x можно получить друг из друга перестановкой цифр.

        //Ответ: 9 (45, 54)

        static void Main(string[] args)
        {
            string one, two;
            bool flag = true;
            int i, k;

            //для каждого числа
            for (int x = 1; true; x++)
            {
                one = (x * 5).ToString();
                two = (x * 6).ToString();

                if (one.Length == two.Length)
                {
                    flag = true;
                    //для каждой цифры 1 числа
                    for (i = 0; i < one.Length; i++)
                    {
                        //для каждой цифры 2 числа
                        for (k = 0; k < two.Length; k++)
                        {
                            //если цифры равны, удаляем ее из 2 числа
                            if (one[i] == two[k])
                            {
                                two = two.Remove(k, 1);
                                break;
                            }
                            //если до конца 2 числа не нашли цифру, то выход
                            else if (k == (two.Length - 1))
                            {
                                flag = false;
                                break;
                            }
                        }

                        if (flag == false) break;
                    }

                    if (flag == true)
                    {
                        Console.WriteLine("Ответ: " + x + " ("+x*5 + ", " + x*6 + ")");
                        if (x > 100000)
                        {
                            Console.ReadLine();
                            return;
                        }
                    }
                }


            }
        }
    }
}
