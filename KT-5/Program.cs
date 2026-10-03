using System;
using System.Collections.Generic;

namespace KT_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("КТ-5");
            Console.WriteLine();

            RunKadaneTests();
            RunCoinChangeDemo();

            Console.WriteLine();
            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }

        private static void RunKadaneTests()
        {
            Console.WriteLine("Часть 1: Максимальная сумма подмассива (алгоритм Кадане)");

            int[][] testArrays = new int[][]
            {
                new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 },
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { -5, -2, -3, -1 },
                new int[] { 7 }
            };

            for (int i = 0; i < testArrays.Length; i++)
            {
                int[] arr = testArrays[i];
                int result = AlgorithmsKT5.MaxSubarraySum(arr);
                Console.Write("Массив: [");
                for (int j = 0; j < arr.Length; j++)
                {
                    Console.Write(arr[j]);
                    if (j < arr.Length - 1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine($"] | Максимальная сумма: {result}");
            }
            Console.WriteLine();
        }

        private static void RunCoinChangeDemo()
        {
            Console.WriteLine("Часть 2: Сравнение жадного алгоритма и динамического программирования");

            int target1 = 18;
            int[] denoms1 = new int[] { 1, 5, 10 };

            List<int> greedyCoins1 = AlgorithmsKT5.GreedyMakeSum(target1, denoms1);
            int dpCount1 = AlgorithmsKT5.MinCountDP(target1, denoms1);

            Console.WriteLine($"Канонический набор {{1, 5, 10}} для суммы {target1}");
            Console.Write("Жадный алгоритм (монеты): ");
            PrintCollection(greedyCoins1);
            Console.WriteLine($"Количество монет (жадный): {greedyCoins1.Count}");
            Console.WriteLine($"Количество монет (динамическое программирование): {dpCount1}");
            Console.WriteLine();

            int target2 = 6;
            int[] denoms2 = new int[] { 1, 3, 4 };

            List<int> greedyCoins2 = AlgorithmsKT5.GreedyMakeSum(target2, denoms2);
            int dpCount2 = AlgorithmsKT5.MinCountDP(target2, denoms2);

            Console.WriteLine($"Неканонический набор {{1, 3, 4}} для суммы {target2}");
            Console.Write("Жадный алгоритм (монеты): ");
            PrintCollection(greedyCoins2);
            Console.WriteLine($"Количество монет (жадный): {greedyCoins2.Count}");
            Console.WriteLine($"Количество монет (динамическое программирование): {dpCount2}");
            Console.WriteLine();

            Console.WriteLine("Письменное обоснование:");
            Console.WriteLine("Для канонического набора номиналов жадный алгоритм и динамическое программирование дают одинаковый результат, так как каждый больший номинал кратен меньшему.");
            Console.WriteLine("Для неканонического набора номиналов наблюдается расхождение результата.");
            Console.WriteLine("Жадный алгоритм выбирает локально оптимальный шаг, начиная с наибольшего номинала (4), после чего набирает остаток единицами (4 + 1 + 1), что требует 3 монеты.");
            Console.WriteLine("Динамическое программирование исследует все возможные варианты и находит глобальный оптимум (3 + 3), требующий 2 монеты.");
            Console.WriteLine("Вывод: жадный алгоритм не гарантирует минимальное количество монет для произвольных систем номиналов, в то время как динамическое программирование находит точное оптимальное решение.");
        }

        private static void PrintCollection(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{list[i]} ");
            }
            Console.WriteLine();
        }
    }
}
