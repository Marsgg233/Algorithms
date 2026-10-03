using System;

namespace KT_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("КТ-6");
            Console.WriteLine();

            RunTwoPointersTests();
            RunSlidingWindowTests();
            PrintExplanations();

            Console.WriteLine();
            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }

        private static void RunTwoPointersTests()
        {
            Console.WriteLine("Часть 1: Метод поиска пары с заданной суммой (два указателя)");

            int[] arr1 = new int[] { 1, 3, 5, 7, 11, 15 };
            int target1 = 16;
            PrintPairTestResult(arr1, target1);

            int[] arr2 = new int[] { 2, 4, 6, 8, 10 };
            int target2 = 12;
            PrintPairTestResult(arr2, target2);

            int[] arr3 = new int[] { 1, 2, 3, 4, 10 };
            int target3 = 25;
            PrintPairTestResult(arr3, target3);

            Console.WriteLine();
        }

        private static void PrintPairTestResult(int[] arr, int target)
        {
            Console.Write("Массив: [");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                if (i < arr.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine($"] | Целевая сумма: {target}");

            (int, int)? result = AlgorithmsKT6.FindPairWithSum(arr, target);
            if (result.HasValue)
            {
                Console.WriteLine($"Найдена пара: ({result.Value.Item1}, {result.Value.Item2})");
            }
            else
            {
                Console.WriteLine("Пара не найдена (результат null)");
            }
        }

        private static void RunSlidingWindowTests()
        {
            Console.WriteLine("Часть 2: Метод поиска наименьшего подмассива (скользящее окно)");

            int[] arr1 = new int[] { 2, 3, 1, 2, 4, 3 };
            int minSum1 = 7;
            PrintSubarrayTestResult(arr1, minSum1);

            int[] arr2 = new int[] { 1, 4, 4 };
            int minSum2 = 4;
            PrintSubarrayTestResult(arr2, minSum2);

            int[] arr3 = new int[] { 1, 2, 3 };
            int minSum3 = 10;
            PrintSubarrayTestResult(arr3, minSum3);

            Console.WriteLine();
        }

        private static void PrintSubarrayTestResult(int[] arr, int minSum)
        {
            Console.Write("Массив: [");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                if (i < arr.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine($"] | Минимальная сумма: {minSum}");

            int length = AlgorithmsKT6.MinSubarrayLength(arr, minSum);
            Console.WriteLine($"Длина наименьшего подмассива: {length}");
        }

        private static void PrintExplanations()
        {
            Console.WriteLine("Письменное объяснение логики решений и сравнение сложностей:");
            Console.WriteLine();
            Console.WriteLine("1. Часть 1 (Два указателя для поиска пары в отсортированном массиве):");
            Console.WriteLine("Идея метода заключается в использовании двух указателей, один из которых указывает на начало массива (левый), а второй на конец массива (правый).");
            Console.WriteLine("На каждой итерации вычисляется сумма элементов под этими указателями.");
            Console.WriteLine("Если сумма равна целевому значению, пара найдена и возвращается результат.");
            Console.WriteLine("Если сумма меньше целевого значения, необходимо увеличить сумму, поэтому левый указатель сдвигается вправо.");
            Console.WriteLine("Если сумма больше целевого значения, необходимо уменьшить сумму, поэтому правый указатель сдвигается влево.");
            Console.WriteLine("Почему движение указателей не пропускает ответ: поскольку массив отсортирован, увеличение левого указателя гарантированно дает большую или равную сумму с тем же правым элементом, а уменьшение правого указателя гарантированно дает меньшую или равную сумму с тем же левым элементом. Никакие другие комбинации не могут дать правильную сумму, так как элементы вне диапазона [left, right] уже были исключены как слишком маленькие или слишком большие.");
            Console.WriteLine("Сравнение сложностей: полный перебор всех пар требует проверки каждого элемента с каждым, что дает сложность O(n^2). Метод двух указателей перемещает каждый указатель максимум n раз, что обеспечивает линейную сложность O(n).");
            Console.WriteLine();
            Console.WriteLine("2. Часть 2 (Скользящее окно переменного размера для поиска подмассива):");
            Console.WriteLine("Идея метода заключается в поддержании динамического окна с границами left и right.");
            Console.WriteLine("Правый указатель расширяет окно вправо, добавляя элементы к текущей сумме.");
            Console.WriteLine("Как только сумма становится больше или равна заданной минимальной сумме, фиксируется длина текущего окна, после чего левый указатель сдвигается вправо для поиска более короткого подходящего подмассива.");
            Console.WriteLine("Почему метод не пропускает ответ: правый указатель исследует все возможные правые границы, а цикл сжатия слева проверяет все минимально допустимые левые границы для каждой правой границы. Ни один подходящий подмассив минимальной длины не может быть пропущен, так как окно сжимается только тогда, когда условие суммы уже выполнено.");
            Console.WriteLine("Сравнение сложностей: наивный перебор всех возможных подмассивов требует O(n^2) или O(n^3) операций. Метод скользящего окна обрабатывает каждый элемент массива не более двух раз (по одному разу для каждого указателя), что обеспечивает сложность O(n).");
        }
    }
}
