using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    internal class Task2
    {
        public static void Run()
        {
            Console.Write("Enter first complex number(a b): ");
            int a, b, choice;
            ComplexNumber number1, number2, result;
            string[] input = Console.ReadLine().Split(' ');
            if (input.Length < 2)
            {
                a = 0; b = 0;
            }
            else
            {
                int.TryParse(input[0], out a);
                int.TryParse(input[1], out b);
            }
            number1 = new ComplexNumber(a, b);
            Console.Write("Enter second complex number(a b): ");
            input = Console.ReadLine().Split(' ');
            if (input.Length < 2)
            {
                a = 0; b = 0;
            }
            else
            {
                int.TryParse(input[0], out a);
                int.TryParse(input[1], out b);
            }
            number2 = new ComplexNumber(a, b);

            do
            {
                Console.WriteLine("Enter what to do(1 - show numbers, 2 - show their Sum, 3 - show their Dif, 4 - show their Mult, 5 - show their Div):");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"Complex number 1 : {number1}");
                        Console.WriteLine($"Complex number 2 : {number2}");
                        Console.WriteLine();
                        break;
                    case 2:
                        result = number1 + number2;
                        Console.WriteLine($"Result: {result}");
                        break;
                    case 3:
                        result = number1 - number2;
                        Console.WriteLine($"Result: {result}");
                        break;
                    case 4:
                        result = number1 * number2;
                        Console.WriteLine($"Result: {result}");
                        break;
                    case 5:
                        result = number1 / number2;
                        Console.WriteLine($"Result: {result}");
                        break;
                }
            } while (choice != 0);
        }
    }

    public struct ComplexNumber
    {
        double a;
        double b;

        public ComplexNumber()
        {
            a = 0;b = 0;
        }

        public ComplexNumber(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public override string ToString()
        {
            return $"{a} + {b}i";
        }

        public static ComplexNumber operator +(ComplexNumber num1, ComplexNumber num2)
        {
            return new ComplexNumber(num1.a + num2.a, num1.b + num2.b);
        }

        public static ComplexNumber operator -(ComplexNumber num1, ComplexNumber num2)
        {
            num2.a *= -1;
            num2.b *= -1;
            return new ComplexNumber(num1.a + num2.a, num1.b + num2.b);
        }

        public static ComplexNumber operator *(ComplexNumber num1, ComplexNumber num2)
        {
            return new ComplexNumber(num1.a * num2.a - num1.b * num2.b, num1.a * num2.b + num1.b * num2.a);
        }

        public static ComplexNumber operator /(ComplexNumber num1, ComplexNumber num2)
        {
            double a = (num1.a * num2.a + num1.b * num2.b) / (num2.a * num2.a + num2.b * num2.b);
            double b = (num1.b * num2.a - num1.a * num2.b) / (num2.a * num2.a + num2.b * num2.b);
            return new ComplexNumber(a, b);
        }
    }
}
