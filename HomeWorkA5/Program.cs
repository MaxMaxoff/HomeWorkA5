using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Библиотека для упрощения работы с консолью.
// https://github.com/MaxMaxoff/SupportLibrary
using SupportLibrary;

/// <summary>
/// Максим Торопов
/// Ярославль
/// https://github.com/MaxMaxoff
/// 
/// Домашняя работа "Алгоритмы и структуры данных"
/// 5 урок
/// </summary>
namespace HomeWorkA5
{
    class Program
    {
        /// <summary>
        /// 1. Реализовать перевод из 10 в 2 систему счисления с использованием стека.
        /// </summary>
        static void Task1()
        {
            SupportMethods.PrepareConsoleForHomeTask("1. Реализовать перевод из 10 в 2 систему счисления с использованием стека.\n");
            int number = SupportMethods.RequestIntValue("Please type number: ");

            // if number is negative print "-" and convert to positive
            if (number < 0)
            {
                Console.Write("-");
                number *= -1;
            }

            // try-catch section
            try
            {
                // new stack with default size 10
                TNode<int> stack = new TNode<int>(10);

                // put to stack
                do
                {
                    stack.Push(number % 2);
                    // Console.Write(number % 2);
                    number /= 2;
                } while (number > 0);

                // get from stack and print
                while (!stack.IsEmpty)
                {
                    var top = stack.Pop();
                    Console.Write($"{top}");
                }
            }
            catch (InvalidOperationException ex)
            {
                SupportMethods.Pause(ex.Message);
            }

            SupportMethods.Pause();
        }

        /// <summary>
        /// 2. Добавить в программу “реализация стека на основе односвязного списка” проверку на выделение памяти.
        /// Если память не выделяется, то выводится соответствующее сообщение.
        /// Постарайтесь создать ситуацию, когда память не будет выделяться (добавлением большого количества данных).
        /// </summary>
        static void Task2()
        {
            // uncomment WriteLines in TNode Class and run Task1();
            // Task1();
        }

        /// <summary>
        /// 3. Написать программу, которая определяет, является ли введенная скобочная последовательность правильной.
        /// Примеры правильных скобочных выражений: (), ([])(), {}(), ([{}]), неправильных — )(, ())({), (, ])}), ([(]) для скобок [,(,{.
        /// Например: (2+(2*2)) или[2 /{5*(4+7)}]
        /// </summary>
        static void Task3()
        {
            SupportMethods.PrepareConsoleForHomeTask("3. Написать программу, которая определяет, является ли введенная скобочная последовательность правильной.\n" +
                "Примеры правильных скобочных выражений: (), ([])(), {}(), ([{}]), неправильных — )(, ())({), (, ])}), ([(]) для скобок [,(,{." +
                "Например: (2+(2*2)) или[2 /{5*(4+7)}]\n");

            string str = SupportMethods.RequestString("Please type sequence: ");
            
            char[] arr = str.ToCharArray();

            // new stack
            TNode<char> stack = new TNode<char>(str.Length);
                        
            bool flag = true;
            int i = 0;

            try
            {
                while (flag && i < str.Length)
                {
                    switch (str[i])
                    {
                        case '[':
                        case '(':
                        case '{':
                            stack.Push(str[i]);
                            // Console.WriteLine(str[i]);
                            break;

                        case ']':
                        case ')':
                        case '}':
                            var top = stack.Pop();
                            if (str[i] == ']') if (top != '[') flag = false;
                            if (str[i] == ')') if (top != '(') flag = false;
                            if (str[i] == '}') if (top != '{') flag = false;
                            break;

                        default:
                            break;
                    }
                    i++;
                }
            }
            catch (InvalidOperationException ex)
            {
                SupportMethods.Pause(ex.Message);
                flag = false;
            }

            if (flag && stack.IsEmpty) SupportMethods.Pause("All OK!");
            else SupportMethods.Pause("Something Wrong!");

        }

        /// <summary>
        /// 4. *Создать функцию, копирующую односвязный список (то есть создает в памяти копию односвязного списка, без удаления первого списка).
        /// </summary>
        static void Task4()
        {

        }

        /// <summary>
        /// 5. **Реализовать алгоритм перевода из инфиксной записи арифметического выражения в постфиксную.
        /// </summary>
        static void Task5()
        {
            SupportMethods.PrepareConsoleForHomeTask("5. **Реализовать алгоритм перевода из инфиксной записи арифметического выражения в постфиксную.\n");
            string str = SupportMethods.RequestString("Please type record: ");

            TNode<string> stack = new TNode<string>(str.Length);

            string[] a;            
            a = str.Split(' ');

            string[] b = new string [a.Length];

            int i = 0;
            int j = 0;

            try
            {
                while (i < a.Length)
                {
                    switch (a[i])
                    {
                        case "+":
                        case "-":
                            if (stack.IsEmpty) stack.Push(a[i]);
                            else
                            {
                                while (!stack.IsEmpty && stack.Peek() != "(")
                                {
                                    b[j] = stack.Pop();
                                    j++;
                                }
                                stack.Push(a[i]);
                            }
                            break;
                        case "*":
                        case "/":
                            if (stack.IsEmpty) stack.Push(a[i]);
                            else
                            {
                                while (!stack.IsEmpty && stack.Peek() != "(" && (stack.Peek() == "*" || stack.Peek() == "/"))
                                {
                                    b[j] = stack.Pop();
                                    j++;
                                }
                                stack.Push(a[i]);
                            }
                            break;

                        case ")":
                            var top2 = stack.Pop();
                            do
                            {
                                if (top2 != "(") b[j] = top2;
                                j++;
                                top2 = stack.Pop();
                            } while (top2 != "(");
                            break;

                        case "(":
                            stack.Push(a[i]);
                            break;

                        default:
                            b[j] = a[i];
                            j++;
                            break;
                    }
                    i++;
                }

                while (!stack.IsEmpty)
                {
                    var top2 = stack.Pop();
                    b[j] = top2;
                    j++;
                } 

            }
            catch (InvalidOperationException ex)
            {
                SupportMethods.Pause(ex.Message);
            }

            for (int ii = 0; ii < b.Length; ii++)
                Console.Write(b[ii]);

            SupportMethods.Pause();

        }

        /// <summary>
        /// 6. *Реализовать очередь.
        /// </summary>
        static void Task6()
        {

        }

        static void Main(string[] args)
        {
            do
            {
                SupportMethods.PrepareConsoleForHomeTask("1 - Task 1\n" +
                  "2 - Task 2\n" +
                  "3 - Task 3\n" +
                  "4 - Task 4\n" +
                  "5 - Task 5\n" +
                  "6 - Task 6\n" +
                  "0 (Esc) - Exit\n");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        Task1();
                        break;
                    case ConsoleKey.D2:
                        Task2();
                        break;
                    case ConsoleKey.D3:
                        Task3();
                        break;
                    case ConsoleKey.D4:
                        Task4();
                        break;
                    case ConsoleKey.D5:
                        Task5();
                        break;
                    case ConsoleKey.D6:
                        Task6();
                        break;
                    case ConsoleKey.D0:
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }
            } while (true);
        }
    }
}
