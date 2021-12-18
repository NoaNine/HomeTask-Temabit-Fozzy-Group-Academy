using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintAlphabet
{
    class Program
    {
        static void Main(string[] args)
        {
            char letter;
            Console.WriteLine("Please Enter Any one Alphabate Which you want to print");
            letter = char.Parse(Console.ReadLine());
            switch (letter)
            {
                case 'a':
                case 'A':
                    Alphabet.A();
                    break;

                case 'b':
                case 'B':
                    Alphabet.B();
                    break;

                case 'c':
                case 'C':
                    Alphabet.C();
                    break;

                case 'd':
                case 'D':
                    Alphabet.D();
                    break;

                case 'e':
                case 'E':
                    Alphabet.E();
                    break;

                case 'f':
                case 'F':
                    Alphabet.F();
                    break;

                case 'g':
                case 'G':
                    Alphabet.G();
                    break;

                case 'h':
                case 'H':
                    Alphabet.H();
                    break;

                case 'i':
                case 'I':
                    Alphabet.I();
                    break;

                case 'j':
                case 'J':
                    Alphabet.J();
                    break;

                case 'k':
                case 'K':
                    Alphabet.K();
                    break;

                case 'l':
                case 'L':
                    Alphabet.L();
                    break;

                case 'm':
                case 'M':
                    Alphabet.M();
                    break;

                case 'n':
                case 'N':
                    Alphabet.N();
                    break;

                case 'o':
                case 'O':
                    Alphabet.O();
                    break;

                case 'p':
                case 'P':
                    Alphabet.P();
                    break;

                case 'q':
                case 'Q':
                    Alphabet.Q();
                    break;

                case 'r':
                case 'R':
                    Alphabet.R();
                    break;

                case 's':
                case 'S':
                    Alphabet.S();
                    break;

                case 't':
                case 'T':
                    Alphabet.T();
                    break;

                case 'u':
                case 'U':
                    Alphabet.U();
                    break;

                case 'v':
                case 'V':
                    Alphabet.V();
                    break;

                case 'w':
                case 'W':
                    Alphabet.W();
                    break;

                case 'x':
                case 'X':
                    Alphabet.X();
                    break;

                case 'y':
                case 'Y':
                    Alphabet.Y();
                    break;

                case 'z':
                case 'Z':
                    Alphabet.Z();
                    break;
            }
            Console.ReadKey();
        }
    }
}
