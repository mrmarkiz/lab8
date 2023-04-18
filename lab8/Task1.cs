using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    internal class Task1
    {
        public static void Run()
        {
            Console.Write("Enter first fraction(a/b): ");
            int a, b, choice;
            Fraction fraction1, fraction2, result;
            string[] input = Console.ReadLine().Split('/');
            if (input.Length < 2)
            {
                a = 0;b = 0;
            }
            else
            {
                int.TryParse(input[0], out a);
                int.TryParse(input[1], out b);
            }
            fraction1 = new Fraction(a, b);
            Console.Write("Enter second fraction(a/b): ");
            input = Console.ReadLine().Split('/');
            if (input.Length < 2)
            {
                a = 0; b = 0;
            }
            else
            {
                int.TryParse(input[0], out a);
                int.TryParse(input[1], out b);
            }
            fraction2 = new Fraction(a, b);
            do
            {
                Console.WriteLine("Enter what to do(1 - show Fractions, 2 - show their Sum, 3 - show their Dif, 4 - show their Mult, 5 - show their Div):");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"Fraction 1 : {fraction1}");
                        Console.WriteLine($"Fraction 2 : {fraction2}");
                        Console.WriteLine();
                        break;
                    case 2:
                        result = fraction1 + fraction2;
                        Console.WriteLine($"Result: {result}");
                        break;
                    case 3:
                        result = fraction1 - fraction2;
                        Console.WriteLine($"Result: {result}");
                        break;
                    case 4:
                        result = fraction1 * fraction2;
                        Console.WriteLine($"Result: {result}");
                        break;
                    case 5:
                        result = fraction1 / fraction2;
                        Console.WriteLine($"Result: {result}");
                        break;
                }
            } while (choice != 0);
        }
    }

    public struct Fraction
    {
        public int numerator;
        public int denominator;

        public Fraction()
        {
            numerator = 0;
            denominator = 0;
        }

        public Fraction(int num, int denom)
        {
            if (denom == 0) 
            {
                numerator = 0;
                denominator = 0;
                return;
            }
            if ((denom < 0 && num < 0) || denom < 0)
            {
                num *= -1;
                denom *= -1;
            }
            numerator = num;
            denominator = denom;
        }

        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            if (a.denominator == 0 && b.denominator == 0)
            {
                return new Fraction();
            }
            else if(a.denominator ==0)
            {
                return b;
            }
            else if(b.denominator == 0)
            {
                return a;
            }

            Fraction result = new Fraction();

            if (a.denominator == b.denominator)
            {
                result.denominator = a.denominator;
                result.numerator = a.numerator * b.numerator;
            }
            else if (a.denominator % b.denominator == 0)
            {
                result.denominator = a.denominator;
                result.numerator = a.numerator + (b.numerator * (a.denominator / b.denominator));
            }
            else if (b.denominator % a.denominator == 0)
            {
                result.denominator = b.denominator;
                result.numerator = b.numerator + (a.numerator * (b.denominator / a.denominator));
            }
            else
            {
                int c = a.denominator * b.denominator;
                result.denominator = c;
                result.numerator = a.numerator * (c / a.denominator) + b.numerator * (c / b.denominator);
            }

            return result;
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            b.numerator *= -1;
            return a + b;
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            if (a.denominator == 0 || b.denominator == 0)
            {
                return new Fraction();
            }

            Fraction result = new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);
            return result;
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (a.denominator == 0 || b.numerator == 0)
            {
                return new Fraction();
            }
            int tmp = b.numerator;
            b.numerator = b.denominator;
            b.denominator = tmp;
            return a * b;
        }
    }
}
