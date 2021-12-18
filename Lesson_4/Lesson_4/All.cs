using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4
{
    class All
    {
        // Циклический сдвиг строк матрицы вниз
        static void RotateDown(int[][] mtr)
        {
            /* Получаем размерность (число строк) */
            int M = mtr.GetLength(0);

            // Запоминаем нижнюю строку
            int[] temp = mtr[M - 1];
            for (int i = M - 1; i > 0; i--)
            {
                // Сдвиг (перемещаем адреса строк)
                mtr[i] = mtr[i - 1];
            }
            // Устанавливаем верхнюю строку
            mtr[0] = temp;
        }

        // Вывод матрицы
        static void Print(int[][] mtr)
        {
            // Определение числа строк
            int M = mtr.GetLength(0);

            for (int i = 0; i < M; i++)
            {
                /*
                 *	Обходимся без получения размерности
                 */

                // Перебор элементов строки
                foreach (int j in mtr[i])
                {
                    Console.Write("{0,8}", j);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // Инициализация матрицы случайными значениями
        static void Init(int[][] mtr)
        {
            // Инициализация генератора случайных чисел
            Random rand = new Random();

            /* Получаем размерность (число строк) */
            int M = mtr.GetLength(0);

            for (int i = 0; i < M; i++)
            {
                /*
                 	Другой способ получения размерности 
                                (число столбцов)
                */
                int N = mtr[i].Length;
                for (int j = 0; j < N; j++)
                {
                    // Забиваем массив случайными числами
                    // от 0 до 99999
                    mtr[i][j] = rand.Next(100000);
                }
            }
        }

        static void Main()
        {
            // Число строк
            uint M = 0;

            Console.WriteLine("Введите количество строк: ");
            try
            {
                // Ввод числа строк с клавиатуры
                M = Convert.ToUInt32(Console.ReadLine());
            }
            catch (OverflowException ex)
            {
                // В случае ошибочного ввода (переполнения)
                Console.WriteLine(ex.Message + " Use default size (=10)");
            }
            catch (FormatException ex)
            {
                // В случае ошибочного ввода
                Console.WriteLine(ex.Message + " Use default size (=10)");
            }

            // Если все плохо, то создадим массив из 10 строк
            if (M == 0)
                M = 10;

            // Создание массива ("указателей")
            int[][] ar = new int[M][];

            // Число столбцов
            uint N = 0;

            for (int i = 0; i < M; i++)
            {
                Console.WriteLine("Введите количество столбцов: ");
                try
                {
                    // Ввод числа столбцов для каждой строки
                    N = Convert.ToUInt32(Console.ReadLine());
                }
                catch (OverflowException ex)
                {
                    // В случае ошибочного ввода (переполнения)
                    Console.WriteLine(ex.Message + " Use default size (=10)");
                }
                catch (FormatException ex)
                {
                    // В случае ошибочного ввода
                    Console.WriteLine(ex.Message + " Use default size (=10)");
                }

                // Если все плохо, то создадим массив из 10 элементов
                if (N == 0)
                    N = 10;

                // Создание массива
                ar[i] = new int[N];
            }

            Console.WriteLine("\"Ступенчатая матрица\":");
            // Инициализация
            Init(ar);
            // Вывод
            Print(ar);

            Console.WriteLine("Та же матрица после серии циклических сдвигов:");

            for (int i = 0; i < M; i++)
            {
                // Циклический сдвиг
                RotateDown(ar);
                // Вывод
                Print(ar);
            }
        }
    }
}
