using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pract14_2_Taztdinova
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string ChekText(string expression)
        {
            Stack<char> stack = new Stack<char>();
            List<int> position = new List<int>();

            if (expression.Length > 0 && expression[0] == ')')
            {
                return "Ошибка: нельзя начинать с закрывающейся скобки!";
            }

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];

                if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    if (stack.Count > 0)
                        stack.Pop();
                    else
                        position.Add(i + 1);
                }
            }

            if (stack.Count > 0)
               return $"Не хватает {stack.Count} скобок )";
            else if (position.Count > 0)
                return $"Лишние ) в позициях: {string.Join(", ", position)}";
            else
                return"Скобки сбалансированы!";
        }
        private string FixText(string expression)
        {
            if (expression.Length > 0 && expression[0] == ')')
            {
                return "(" + expression;
            }

            expression = expression.Replace("()", "");

            int open = 0, close = 0;

            foreach (char c in expression)
            {
                if (c == '(') open++;
                if (c == ')') open++;
            }

            if (open > close)
            {
                return expression + new string(')', open - close);
            }
            else if (close > open)
            {
                return new string('(', close - open);
            }
            else
            {
                return expression;
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            string expression = textBoxInput.Text;
            string fileName1 = textBoxFile.Text;
            string fileName2 = textBoxFile2.Text;

            File.AppendAllText(expression, fileName1);

            if (string.IsNullOrEmpty(expression))
            {
                MessageBox.Show("Введите выражение!");
                return;
            }
            if (string.IsNullOrEmpty(fileName1))
            {
                MessageBox.Show("Введите название файла!");
                return;
            }
            if (string.IsNullOrEmpty(fileName2))
            {
                MessageBox.Show("Введите название второго файла!");
                return;
            }
            if (expression.Any(char.IsLetter))
            {
                MessageBox.Show("Ошибка: нельзя вводить буквы!");
                return;
            }

            File.WriteAllText(fileName1, expression);
            string TextFromFile = File.ReadAllText(fileName1);

            Stack stack = new Stack();

            foreach (char c in TextFromFile)
            {
                stack.Push(c);
            }

            using (StreamWriter writer = new StreamWriter(fileName2))
            {
                while (stack.Count > 0)
                {
                    writer.Write(stack.Pop());
                }
            }

            string result = ChekText(expression);
            string fixedExpression = FixText(expression);

            File.WriteAllText(fileName1, fixedExpression);

            MessageBox.Show($"Результат: {result} \n Исправлено: {fixedExpression}");
            textBoxResult.Text = ($"{fixedExpression}");

        }

        private void textBoxFile_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
