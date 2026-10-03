using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace KT_1
{
    public static class ExpressionEvaluator
    {
        public static double Evaluate(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                throw new ArgumentException("Выражение пусто", nameof(expression));
            }

            List<string> postfix = InfixToPostfix(expression);
            return EvaluatePostfix(postfix);
        }

        private static List<string> InfixToPostfix(string expression)
        {
            List<string> output = new List<string>();
            MyStack<char> ops = new MyStack<char>();

            int i = 0;
            while (i < expression.Length)
            {
                char c = expression[i];

                if (char.IsWhiteSpace(c))
                {
                    i++;
                    continue;
                }

                if (char.IsDigit(c) || c == '.')
                {
                    StringBuilder sb = new StringBuilder();
                    while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
                    {
                        sb.Append(expression[i]);
                        i++;
                    }
                    output.Add(sb.ToString());
                    continue;
                }

                if (c == '(')
                {
                    ops.Push(c);
                    i++;
                }
                else if (c == ')')
                {
                    while (!ops.IsEmpty && ops.Peek() != '(')
                    {
                        output.Add(ops.Pop().ToString());
                    }
                    if (ops.IsEmpty)
                    {
                        throw new ArgumentException("Несогласованные скобки");
                    }
                    ops.Pop();
                    i++;
                }
                else if (IsOperator(c))
                {
                    while (!ops.IsEmpty && ops.Peek() != '(' && GetPrecedence(ops.Peek()) >= GetPrecedence(c))
                    {
                        output.Add(ops.Pop().ToString());
                    }
                    ops.Push(c);
                    i++;
                }
                else
                {
                    throw new ArgumentException($"Неверный символ: {c}");
                }
            }

            while (!ops.IsEmpty)
            {
                char op = ops.Pop();
                if (op == '(' || op == ')')
                {
                    throw new ArgumentException("Несогласованные скобки");
                }
                output.Add(op.ToString());
            }

            return output;
        }

        private static double EvaluatePostfix(List<string> postfix)
        {
            MyStack<double> values = new MyStack<double>();

            for (int i = 0; i < postfix.Count; i++)
            {
                string token = postfix[i];

                if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                {
                    values.Push(number);
                }
                else if (token.Length == 1 && IsOperator(token[0]))
                {
                    if (values.Count < 2)
                    {
                        throw new ArgumentException("Неверная структура выражения");
                    }

                    double b = values.Pop();
                    double a = values.Pop();
                    char op = token[0];
                    double result = ApplyOperator(a, b, op);
                    values.Push(result);
                }
                else
                {
                    throw new ArgumentException($"Неверный токен: {token}");
                }
            }

            if (values.Count != 1)
            {
                throw new ArgumentException("Неверная структура выражения");
            }

            return values.Pop();
        }

        private static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        private static int GetPrecedence(char op)
        {
            if (op == '+' || op == '-')
            {
                return 1;
            }
            if (op == '*' || op == '/')
            {
                return 2;
            }
            return 0;
        }

        private static double ApplyOperator(double a, double b, char op)
        {
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    if (b == 0)
                    {
                        throw new DivideByZeroException("Деление на ноль");
                    }
                    return a / b;
                default:
                    throw new ArgumentException($"Неизвестный оператор: {op}");
            }
        }
    }
}
