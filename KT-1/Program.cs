using System;

namespace KT_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("КТ-1");
            Console.WriteLine();

            RunListAndStackDemo();
            RunBracketBalancerTests();
            RunExpressionEvaluatorTests();
            RunExceptionTests();

            Console.WriteLine();
            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }

        private static void RunListAndStackDemo()
        {
            Console.WriteLine("Часть 1 и 2: Список и стек");

            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);
            list.AddFirst(5);

            Console.Write("Элементы списка: ");
            foreach (int item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Количество: {list.Count}, Содержит 10: {list.Contains(10)}, Содержит 99: {list.Contains(99)}");

            int removed = list.RemoveFirst();
            Console.WriteLine($"Удалено RemoveFirst: {removed}, Количество: {list.Count}");

            MyStack<string> stack = new MyStack<string>();
            stack.Push("Первый");
            stack.Push("Второй");
            stack.Push("Третий");

            Console.WriteLine($"Количество в стеке: {stack.Count}, Пуст: {stack.IsEmpty}");
            Console.WriteLine($"Peek: {stack.Peek()}");
            Console.WriteLine($"Pop: {stack.Pop()}");
            Console.WriteLine($"Pop: {stack.Pop()}");
            Console.WriteLine($"Количество после двух Pop: {stack.Count}, Peek: {stack.Peek()}");
            Console.WriteLine();
        }

        private static void RunBracketBalancerTests()
        {
            Console.WriteLine("Часть 3: Проверка скобок");

            string[] expressions = new string[]
            {
                "(a + b) * [c - d]",
                "{[()()]}",
                "([)]",
                "((a + b)",
                ""
            };

            bool[] expected = new bool[] { true, true, false, false, true };

            for (int i = 0; i < expressions.Length; i++)
            {
                string expr = expressions[i];
                bool result = BracketBalancer.IsBalanced(expr);
                bool success = (result == expected[i]);
                string displayExpr = string.IsNullOrEmpty(expr) ? "\"\"" : $"\"{expr}\"";
                Console.WriteLine($"Выражение: {displayExpr,-20} Результат: {result,-5} Ожидание: {expected[i],-5} Статус: {(success ? "OK" : "FAIL")}");
            }
            Console.WriteLine();
        }

        private static void RunExpressionEvaluatorTests()
        {
            Console.WriteLine("Часть 4: Вычисление выражений");

            string[] exprs = new string[]
            {
                "3 + 4 * 2",
                "(3 + 4) * 2",
                "10 / 2 - 3",
                "2 * (3 + (4 - 1))",
                "5 / 0"
            };

            for (int i = 0; i < exprs.Length; i++)
            {
                string expr = exprs[i];
                Console.Write($"Выражение: \"{expr,-20}\" Результат: ");
                try
                {
                    double result = ExpressionEvaluator.Evaluate(expr);
                    Console.WriteLine($"{result}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
            Console.WriteLine();
        }

        private static void RunExceptionTests()
        {
            Console.WriteLine("Тесты исключений для пустых структур");

            SinglyLinkedList<int> emptyList = new SinglyLinkedList<int>();
            try
            {
                emptyList.RemoveFirst();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Исключение RemoveFirst: {ex.Message} (OK)");
            }

            MyStack<int> emptyStack = new MyStack<int>();
            try
            {
                emptyStack.Pop();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Исключение Pop: {ex.Message} (OK)");
            }

            try
            {
                emptyStack.Peek();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Исключение Peek: {ex.Message} (OK)");
            }
        }
    }
}
