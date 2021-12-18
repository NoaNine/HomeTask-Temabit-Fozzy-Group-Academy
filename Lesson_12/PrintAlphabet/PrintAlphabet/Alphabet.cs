using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintAlphabet
{
    class Alphabet
    {
        public static void A()
        {
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {
                    if (((Col == 1 || Col == 5) && Row != 0) || ((Row == 0 || Row == 3) && (Col > 1 && Col < 5)))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void B()
        {
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {
                    if (Col == 1 || ((Row == 0 || Row == 3 || Row == 6) && (Col < 5 && Col > 1)) || (Col == 5 && (Row != 0 && Row != 3 && Row != 6)))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void C()
        {
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {
                    if ((Col == 1 && (Row != 0 && Row != 6)) || ((Row == 0 || Row == 6) && (Col > 1 && Col < 5)) || (Col == 5 && (Row == 1 || Row == 5)))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void D()
        {
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {
                    if (Col == 1 || ((Row == 0 || Row == 6) && (Col > 1 && Col < 5)) || (Col == 5 && Row != 0 && Row != 6))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void E()
        {
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {
                    if (Col == 1 || ((Row == 0 || Row == 6) && (Col > 1 && Col < 6)) || (Row == 3 && Col > 1 && Col < 5))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void F()
        {
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {
                    if (Col == 1 || (Row == 0 && Col > 1 && Col < 6) || (Row == 3 && Col > 1 && Col < 5))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void G()
        {
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {
                    if ((Col == 1 && Row != 0 && Row != 6) || ((Row == 0 || Row == 6) && Col > 1 && Col < 5) || (Row == 3 && Col > 2 && Col < 6) || (Col == 5 && Row != 0 && Row != 2 && Row != 6))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void H()
        {
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {
                    if ((Col == 1 || Col == 5) || (Row == 3 && Col > 1 && Col < 6))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void I()
        {
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {
                    if (Col == 3 || (Row == 0 && Col > 0 && Col < 6) || (Row == 6 && Col > 0 && Col < 6))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void J()
        {
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {
                    if ((Col == 4 && Row != 6) || (Row == 0 && Col > 2 && Col < 6) || (Row == 6 && Col == 3) || (Row == 5 && Col == 2))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void K()
        {
            int i, j;
            j = 5;
            i = 0;
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {

                    if (Col == 1 || ((Row == Col + 1) && Col != 0))
                    {
                        Console.Write("*");
                    }
                    else if (Row == i && Col == j)
                    {
                        Console.Write("*");
                        i++;
                        j--;
                    }
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void L()
        {
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {
                    if (Col == 1 || (Row == 6 && Col != 0 && Col < 6))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void M()
        {
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {
                    if (Col == 1 || Col == 5 || (Row == 2 && (Col == 2 || Col == 4)) || (Row == 3 && Col == 3))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void N()
        {
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {
                    if (Col == 1 || Col == 5 || (Row == Col && Col != 0 && Col != 6))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void O()
        {
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {
                    if (((Col == 1 || Col == 5) && Row != 0 && Row != 6) || ((Row == 0 || Row == 6) && Col > 1 && Col < 5))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void P()
        {
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {
                    if (Col == 1 || ((Row == 0 || Row == 3) && Col > 0 && Col < 5) || ((Col == 5 || Col == 1) && (Row == 1 || Row == 2)))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void Q()
        {
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {
                    if ((Col == 1 && Row != 0 && Row != 6) || (Row == 0 && Col > 1 && Col < 5) || (Col == 5 && Row != 0 && Row != 5) || (Row == 6 && Col > 1 && Col < 4) || (Col == Row - 1 && Row > 3))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void R()
        {
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {
                    if (Col == 1 || ((Row == 0 || Row == 3) && Col > 1 && Col < 5) || (Col == 5 && Row != 0 && Row < 3) || (Col == Row - 1 && Row > 2))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void S()
        {
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {
                    if (((Row == 0 || Row == 3 || Row == 6) && Col > 1 && Col < 5) || (Col == 1 && (Row == 1 || Row == 2 || Row == 6)) || (Col == 5 && (Row == 0 || Row == 4 || Row == 5)))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void T()
        {
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {
                    if (Col == 3 || (Row == 0 && Col > 0 && Col < 6))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void U()
        {
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {
                    if (((Col == 1 || Col == 5) && Row != 6) || (Row == 6 && Col > 1 && Col < 5))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void V()
        {
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {
                    if (((Col == 1 || Col == 5) && Row < 5) || (Row == 6 && Col == 3) || (Row == 5 && (Col == 2 || Col == 4)))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void W()
        {
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {
                    if (((Col == 1 || Col == 5) && Row < 6) || ((Row == 5 || Row == 4) && Col == 3) || (Row == 6 && (Col == 2 || Col == 4)))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void X()
        {
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {
                    if (((Col == 1 || Col == 5) && (Row > 4 || Row < 2)) || Row == Col && Col > 0 && Col < 6 || (Col == 2 && Row == 4) || (Col == 4 && Row == 2))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void Y()
        {
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {
                    if (((Col == 1 || Col == 5) && Row < 2) || Row == Col && Col > 0 && Col < 4 || (Col == 4 && Row == 2) || ((Col == 3) && Row > 3))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void Z()
        {
            for (int Row = 0; Row < 7; Row++)
            {
                for (int Col = 0; Col < 7; Col++)
                {
                    if (((Row == 0 || Row == 6) && Col >= 0 && Col <= 6) || Row + Col == 6)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
