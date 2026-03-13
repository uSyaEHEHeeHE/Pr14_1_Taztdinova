using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract14_Taztdinova
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("n=");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Ошибка: ввод не может быть пустым!");
                }
                else if (!int.TryParse(input, out int n))
                {
                    Console.WriteLine("Ошибка: нужно ввести целое число!");
                }
                else if (n <= 0)
                {
                    Console.WriteLine("Ошибка: число должно быть больше 0!");
                }
                else
                {
                    ProcessStack(n);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }

        static void ProcessStack(int n)
        {
            Stack<int> stack = new Stack<int>();
            stack.Clear();

            for (int i = 1; i <= n; i++)
            {
                stack.Push(i);
            }


            Console.WriteLine($"Размерность стека: = {stack.Count()}");

            if (stack.Count() > 0)
            {
                Console.WriteLine($"Верхний элемент стека: = {stack.Peek()}");
            }

            Console.WriteLine($"Размерность стека: = {stack.Count()}");

            Console.Write("Содержимое стека = ");

            while (stack.Count() > 0)
            {
                Console.Write($"{stack.Pop()} ");
            }

            Console.WriteLine($"\nНовая размерность стека: = {stack.Count()}");
        }
    }
}
