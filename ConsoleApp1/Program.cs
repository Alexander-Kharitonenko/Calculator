using Microsoft.VisualBasic;
using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using static System.Math;


namespace Calculator
{
    class Program
    {
        public static void Main()
        {
            char Operator = '\0';
            double X = 0.0d;
            double Y = 0.0d;
            double Result1 = 0.0d;
            int Couunt = 0;



            while (true)
            {


                Console.WriteLine(
                    "Ведите числа и действие в формате 4 + 3 (через пробел)\n" +

                    "*********************************************************************************\n" +

                    "Если хотите вычеслить факториал введите значение в формате 4 f (через пробел)\n" +

                    "*********************************************************************************\n" +

                    "Если хотите вычеслить Квадрат числа введите значение и степень возведения в фрмате 4 k 3 (через пробел)");

                string text = Console.ReadLine();

                try
                {

                    for (int i = 0; i < text.Length; ++i)
                    {

                        Couunt++;
                        if (Couunt <= 3 & text[2] == 'f')
                        {
                            text = text + " 0";
                        }
                        else
                        {
                            break;
                        }


                    }


                    string[] tv = text.Split(" ").Where(x => x != " ").ToArray();





                    X = double.Parse(tv[0]);
                    Operator = char.Parse(tv[1]);
                    Y = double.Parse(tv[2]);

                }
                catch (FormatException)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы ввели значения не через пробел либо проводите операции не над положительными целыми числами");
                    Console.ResetColor();
                    Main();


                }
                catch (IndexOutOfRangeException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("вы ввели значения в неправильном формате, попробуйте ещё");
                    Console.ResetColor();
                    Main();
                }


                Console.WriteLine(
                                         "\t\t\tВы ввели исходные данные\n" +
                    " ВЫ точно хотите узнать результат? Введите Y - (если да) или N - (если нет) ");

                string text1 = Console.ReadLine();
                Console.WriteLine();


                if (text1 == "Y")
                {

                    Calkulator(Operator, X, out Result1, Y);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Результат {Result1}");
                    Console.ResetColor();
                    Environment.Exit(0); break;
                }
                else if (text1 == "N")
                {
                    Environment.Exit(0); break;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы ввели не верный символ попробуйте повторить все действия заново");
                    Console.ResetColor();
                    Main();
                }


            }

        }

        public static void Calkulator(char Operator, double x, out double Result1, double y = 0.0)
        {
            if (Operator == '+' | Operator == '-' | Operator == '*' | Operator == '/' | Operator == 'f' | Operator == 'k')
            {

                Result1 = 0.0d;

                switch (Operator)
                {

                    case '+': Result1 = x + y; break;
                    case '-': Result1 = x - y; break;
                    case '*': Result1 = x * y; break;
                    case '/': Result1 = x / y; ; break;
                    case 'f': Result1 = CalculateFactorial(x, y); break;
                    case 'k': Result1 = CalculateSquared(x, y); break;

                }


            }

            else
            {
                Result1 = 0.0d;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Недопустимый знак операции попробуйте ещё раз");
                Console.ResetColor();

                Main();
            }

        }
        static double CalculateFactorial(double x, double y = 0.0)
        {
            if (x == 0 | x < 0)
            {
                return 1;
            }
            else
            {
                return x * CalculateFactorial(x - 1);
            }
        }
        static double CalculateSquared(double x, double y)
        {
            return Pow(x, y);
        }

    }
}
