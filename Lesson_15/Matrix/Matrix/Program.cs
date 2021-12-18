using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Matrix
{
    class Print
    {
        private static Random _random = new Random();
        private static object block = new object();

        private char[] _simbol = new char[] {'Q','W','E','R','T','Y','U','I','O','P','A','S','D','F','G',
                                           'H','J','K','L','Z','X','C','V','B','N','M','1','2','3','4',
                                           '5','6','7','8','9','0','Й','Ц','У','К','Е','Н','Г','Ш','Щ',
                                           'З','Х','Ъ','Ф','Ы','В','А','П','Р','О','Л','Д','Ж','Э','Я',
                                           'Ч','С','М','И','Т','Ь','Б','Ю','№','@','#','%','$','&','?'};
        public void PrintLetter()
        {
            int randomLengthLine = _random.Next(4, 8);
            int randomLeftPosition = _random.Next(0, Console.WindowWidth);
            int randomTopPosition = _random.Next(0, Console.WindowHeight);
            for (int i = 0; i <= randomLengthLine; i++)
                lock(block)
                {
                    if ((randomTopPosition + i + 1) <= Console.WindowHeight)
                    {
                        Console.SetCursorPosition(randomLeftPosition, randomTopPosition + i);
                        if (i == randomLengthLine)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(_simbol[_random.Next(0, 75)]);
                        }
                        else
                            if (i == randomLengthLine - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(_simbol[_random.Next(0, 75)]);
                        }
                        else
                            if (i <= randomLengthLine - 2)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(_simbol[_random.Next(0, 75)]);
                        }
                        Thread.Sleep(10);
                    }
                    else continue;
                }
            for (int i = 0; i <= randomLengthLine; i++)
                if ((randomTopPosition + randomLengthLine) <= Console.WindowHeight)
                {
                    Console.SetCursorPosition(randomLeftPosition, randomTopPosition + i);
                    Console.Write(" ");
                    Thread.Sleep(1000);
                }
                else continue;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Print print = new Print();
            for (; ; )
            {
                Thread thread = new Thread(new ThreadStart(print.PrintLetter));
                thread.Start();
                Thread.Sleep(100);
            }
            Console.ReadKey();
        }
    }
}
