using System;
using System.Collections.Generic;

namespace KT_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("КТ-3");
            Console.WriteLine();

            BinarySearchTree bst = new BinarySearchTree();

            Console.WriteLine("Вставка элементов: 50, 30, 70, 20, 40, 60, 80, 30 (дубликат)");
            int[] valuesToInsert = new int[] { 50, 30, 70, 20, 40, 60, 80, 30 };
            for (int i = 0; i < valuesToInsert.Length; i++)
            {
                bst.Insert(valuesToInsert[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Обходы дерева:");
            PrintList("InOrder (по возрастанию):", bst.InOrderTraversal());
            PrintList("PreOrder (прямой):       ", bst.PreOrderTraversal());
            PrintList("PostOrder (обратный):    ", bst.PostOrderTraversal());
            Console.WriteLine();

            Console.WriteLine("Проверка Contains:");
            int[] searchValues = new int[] { 40, 90, 50, 10 };
            for (int i = 0; i < searchValues.Length; i++)
            {
                int val = searchValues[i];
                bool found = bst.Contains(val);
                Console.WriteLine($"Элемент {val} присутствует: {found}");
            }
            Console.WriteLine();

            Console.WriteLine("Проверка удаления узлов:");
            
            Console.WriteLine("Удаление листа (20):");
            bst.Remove(20);
            PrintList("InOrder после удаления 20:", bst.InOrderTraversal());

            Console.WriteLine("Удаление узла с одним потомком (30 имеет правого потомка 40, или после удаления 20...):");
            // У 30 левый 20 (удалили), правый 40. У 30 один потомок 40 (если 20 удален).
            bst.Remove(30);
            PrintList("InOrder после удаления 30:", bst.InOrderTraversal());

            Console.WriteLine("Удаление узла с двумя потомками (50 - корень):");
            bst.Remove(50);
            PrintList("InOrder после удаления 50:", bst.InOrderTraversal());

            Console.WriteLine();
            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }

        private static void PrintList(string title, List<int> list)
        {
            Console.Write($"{title} ");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{list[i]} ");
            }
            Console.WriteLine();
        }
    }
}
