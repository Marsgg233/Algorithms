using System;

namespace KT_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("КТ-2");
            Console.WriteLine();

            RunSortingTests();
            RunBinarySearchTests();
            RunBoundsTests();

            Console.WriteLine();
            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }

        private static void RunSortingTests()
        {
            Console.WriteLine("Часть 1 и 2: Сортировки");

            int[][] testArrays = new int[][]
            {
                new int[] { },
                new int[] { 5 },
                new int[] { 3, 1, 2 },
                new int[] { 5, 4, 3, 2, 1 },
                new int[] { 2, 2, 1, 1, 3 },
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
            };

            for (int i = 0; i < testArrays.Length; i++)
            {
                int[] original = testArrays[i];

                int[] mergeCopy = (int[])original.Clone();
                int[] quickCopy = (int[])original.Clone();
                int[] refCopy = (int[])original.Clone();

                if (mergeCopy.Length > 0)
                {
                    SortingAlgorithms.MergeSort(mergeCopy, 0, mergeCopy.Length - 1);
                }

                if (quickCopy.Length > 0)
                {
                    SortingAlgorithms.QuickSort(quickCopy, 0, quickCopy.Length - 1);
                }

                Array.Sort(refCopy);

                bool mergeOk = AreArraysEqual(mergeCopy, refCopy);
                bool quickOk = AreArraysEqual(quickCopy, refCopy);

                Console.WriteLine($"Тест сортировки {i + 1} | Слияние: {(mergeOk ? "OK" : "FAIL")} | Быстрая: {(quickOk ? "OK" : "FAIL")}");
            }
            Console.WriteLine();
        }

        private static void RunBinarySearchTests()
        {
            Console.WriteLine("Часть 3: Бинарный поиск");

            int[] sortedArr = new int[] { 1, 3, 5, 7, 9, 11 };
            int[] targets = new int[] { 7, 1, 11, 4 };

            for (int i = 0; i < targets.Length; i++)
            {
                int target = targets[i];
                int index = SearchAlgorithms.BinarySearch(sortedArr, target);
                Console.WriteLine($"Поиск элемента {target} | Индекс: {index}");
            }
            Console.WriteLine();
        }

        private static void RunBoundsTests()
        {
            Console.WriteLine("Часть 4: Границы диапазона");

            int[] sortedArr = new int[] { 1, 2, 2, 2, 4, 5, 5, 7 };
            int[] targets = new int[] { 2, 5, 7, 4, 8 };

            for (int i = 0; i < targets.Length; i++)
            {
                int target = targets[i];
                int lower = SearchAlgorithms.LowerBound(sortedArr, target);
                int upper = SearchAlgorithms.UpperBound(sortedArr, target);
                int count = upper - lower;

                Console.WriteLine($"Элемент {target} | LowerBound: {lower} | UpperBound: {upper} | Количество: {count}");
            }
            Console.WriteLine();
        }

        private static bool AreArraysEqual(int[] a, int[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
