using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2
{
    class All
    {
        static void Main(string[] args)
        {
            Season();
            SmartHome();
            Arithmetic();
            //Six_Six_Six.Unit();
            //Six_Six_Six.Sum();
            int r = 20;
            Letter.Print_X(r);
            Console.WriteLine();
            Console.WriteLine();
            Letter.Print_N(r);
            Console.WriteLine();
            Console.WriteLine();
            Letter.Print_Z(r);
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
        }
        static void Season()
        {
                Console.WriteLine("Введите число месяца от 1 до 12");
                int number = Convert.ToInt32(Console.ReadLine());
                if (number >= 1 && number <= 2)
                    Console.WriteLine("Снежинка");
                else
                    if (number >= 3 && number <= 5)
                    Console.WriteLine("Озеленение");
                else
                    if (number >= 6 && number <= 9)
                    Console.WriteLine("Солнышко");
                else
                    if (number >= 10 && number <= 12)
                    Console.WriteLine("Листья");
                else
                    Console.WriteLine("Неверное число");
        }
        static void SmartHome()
        {
                Console.WriteLine("Введите сценарий");
                int number = Convert.ToInt32(Console.ReadLine());
                switch (number)
                {
                    case 1:
                        Console.WriteLine("Выключает свет в доме;" +
                            "\nВыключает кондиционер;" +
                            "\nЗакрывает все окна и двери;" +
                            "\nСтавит дом на сигнализацию; ");
                        break;
                    case 2:
                    Console.WriteLine("Снимает с дома на сигнализацию;" +
                        "\nВключает кондиционер;" +
                        "\nВключает кофе-машину; ");
                        break;
                    case 3:
                        Console.WriteLine("Запускает работу пылесоса; " +
                            "\nЗапускает стиральную машину;" +
                            "\nЗапускает посудомойную машину; ");
                        break;
                    case 8:
                        Console.WriteLine("Запускает работу пылесоса; " +
                            "\nЗапускает стиральную машину;" +
                            "\nЗапускает посудомойную машину; ");
                    break;
                    default:
                        Console.WriteLine("Отправляет сообщение в охранную службу; " +
                            "\nОтправляет сообщение хозяину дома;" +
                            "\nЗапускает робота-машину ‘ЗЛАЯ СОБАКА’;");
                        break;
                }
        }
        static void Arithmetic()
        {
            int num = 8;
            int range_min = 3;
            int range_max = 104;
            int sum = 0;
            int step = 0;
            while (range_min <= range_max)
            {
                if (range_min % num == 0)
                    sum += range_min;
                if (range_min % num == 0)
                    step++;
                range_min++;
            }
            int arithmet = sum / step;
            Console.Write("Среднее арифметическое: ");
            Console.WriteLine(arithmet);
        }
    }
static class Letter
{
    public static void Print_X(int r)
    {
    int x = 0;
    int y = 0;
        while (x <= r)
        {
            while (y <= r)
            {
                if (x == y || y == r - x)
                    Console.Write("*");
                else
                    Console.Write(".");
                y++;
            }
            y = 0;
            Console.WriteLine();
            x++;
        }
    }
    public static void Print_Z(int r)
    {
        int x = 0;
        int y = 0;
        while (x <= r)
        {
                while (y <= r)
                {
                    if (x == 0 || y == r - x || x == r)
                        Console.Write("*");
                    else
                        Console.Write(".");
                    y++;
                }
                y = 0;
                Console.WriteLine();
                x++;
        }
    }
    public static void Print_N(int r)
    {
        int x = 0;
        int y = 0;
        while (x <= r)
        {
                while (y <= r)
                {
                    if (y == 0 || x == y || y == r)
                        Console.Write("*");
                    else
                        Console.Write(".");
                    y++;
                }
                y = 0;
                Console.WriteLine();
                x++;
        }
    }
}
    //public static class Six_Six_Six
    //{
    //    private static List<int> _list = new List<int>();

    //    public static void Unit()
    //    {
    //        int num = 0;
    //        Console.WriteLine("Введите число:");
    //        while (num != 666)
    //        {
    //            string input = Console.ReadLine();
    //            bool res = int.TryParse(input, out num);
    //            if (res)
    //                _list.Add(num);
    //            else
    //                Console.WriteLine("Неверный ввод");
    //        }
    //    }
    //    public static int Sum()
    //    {
    //        int sum = 0;
    //        foreach (int item in _list)
    //        {
    //            sum += item;
    //        }
    //        return sum;
    //    }
    //}
}



