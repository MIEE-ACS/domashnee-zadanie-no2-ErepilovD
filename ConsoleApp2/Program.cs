using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    class Program
    {
        static double Segment4(double x)
        {
            double y = x - 9;
            return y;
        }
        static double Segment3(double x)
        {
            double y = -2 * (x - 4.5);
            return y;
        }
        static double Segment2(double x, double r)
        {
            double y = -3 * Math.Sin(Math.Acos(x / 3)) + 3;
            return y;
        }
        static double Segment1()
        {
            return 3;
        }


        static void Main(string[] args)
        {
            double x, r;

            //Ввод аргумента
            while (true)
            {
                Console.WriteLine("Введите значение аргумента:");

                if (double.TryParse(Console.ReadLine(), out x) && (x >= -7) && (x <= 11))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректно введеное значение аргумента! (Для повтороного ввода, нажмите любую клавишу)");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            //Ввод радиуса
            while (true)
            {
                Console.WriteLine("Введите значение радиуса:");

                if (double.TryParse(Console.ReadLine(), out r) && (r > 0))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректно введенный радиус! (Для повтороного ввода, нажмите любую клавишу)");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            //Вывод значение при определенном аргументе:
            if (x <= -3)
            {
                Console.WriteLine($"y({x}) = {Segment1()}");
            }
            else if (x > -3 && x <= 3)
            {
                //Проверка на вхождение в область определения:
                if (Segment2(x, r) is Double.NaN)
                {
                    Console.WriteLine("Функция неопределена в данной точке!");
                }
                else Console.WriteLine($"y({x}) = {Segment2(x, r)}");
            }
            else if (x > 3 && x <= 6)
            {
                Console.WriteLine($"y({x}) = {Segment3(x)}");
            }
            else if (x > 6 && x <= 11)
            {
                Console.WriteLine($"y({x}) = {Segment4(x)}");
            }


            //Вывод значений:
            Console.WriteLine();
            for (double X = -7; X <= 11; X += 0.1)
            {
                if (X < -3)
                {
                    Console.WriteLine("y({0:0.00}) = {1:0.00}", X, Segment1());
                }
                else if (X < 3)
                {
                    if (Segment2(X, r) is Double.NaN)
                    {
                        Console.WriteLine("-");
                    }
                    else Console.WriteLine("y({0:0.00}) = {1:0.00}", X, Segment2(X, r));
                }
                else if (X < 6)
                {
                    Console.WriteLine("y({0:0.00}) = {1:0.00}", X, Segment3(X));
                }
                else if (X < 11)
                {
                    Console.WriteLine("y({0:0.00}) = {1:0.00}", X, Segment4(X));
                }
            }

            Console.ReadKey();
        }
    }
}