using System.Collections.Generic;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace LinkedListHomework9
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Task 1
            Console.WriteLine("Task 1");
            int[] numbers = { 2, 4, 3, 2, 8, 2, 5, 1, 2 };
            LinkedList<int> numbersLinkedList = new LinkedList<int>(numbers);
            InsertNodesAfterSelectedValue(numbersLinkedList, 2, 10);

            // Task 2
            Console.WriteLine("\nTask 2");
            int[] list1 = { 2, 4, 34, 2, 8, 25, 5, 106, 2 };
            int[] list2 = { 2, 4, 8, 77, 8, 2, 5, 109, 2 };
            LinkedList<int> numbersLinkedList1 = new LinkedList<int>(list1);
            LinkedList<int> numbersLinkedList2 = new LinkedList<int>(list2);
            Console.WriteLine($"Common values between 2 linked lists:");
            var commonValuesLinkedList = GetCommonValuesFromTwoLinkedLists(numbersLinkedList1, numbersLinkedList2);
            OutPutLinkedListValues(commonValuesLinkedList);
        }

        /* Task 1. Создайте LinkedList и два элемента, вставьте второй элемент
         * после каждого вхождения первого элемента в списке. https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=net-6.0
         * Итак, если список равен [2,4,3,2,8,2,5,1,2], а элементы равны 2 и 10,
         * результатом будет [2,10,4,3,2,10,8,2,10,5,1,2,10] */
        private static void InsertNodesAfterSelectedValue(LinkedList<int> linkedList, int firstElement, int secondElement)
        {
            var changedList = linkedList.ToList();
            LinkedList<int>.Enumerator em = linkedList.GetEnumerator();
            var indexHelper = 0;
            while (em.MoveNext())
            {
                indexHelper++;
                if (em.Current == firstElement)
                {
                    var indexInList = indexHelper;
                    changedList.Insert(indexInList, secondElement);
                    indexHelper++;
                }
            }
            LinkedList<int> numbersLinkedList = new LinkedList<int>(changedList);
            Console.WriteLine($"Linked List after the Insertion of {firstElement} after the {secondElement}:");
            OutPutLinkedListValues(numbersLinkedList);
        }

        /* Task 2. Объединить два связанных списка чисел, включив в окончательный список только те числа,
         * которые встречаются в обоих спискаx.
         * Итак, если списки [1,3,4,7,12] и [1,5,7,9], результат будет [1,7].*/
        private static LinkedList<int> GetCommonValuesFromTwoLinkedLists(LinkedList<int> linkedList1, LinkedList<int> linkedList2)
        {
            var linkedListConverted1 = linkedList1.ToList();
            var linkedListConverted2 = linkedList2.ToList();
            var commonList = linkedListConverted1.Intersect(linkedListConverted2);
            LinkedList<int> numbersLinkedList = new LinkedList<int>(commonList);

            return numbersLinkedList;
        }

        private static void OutPutLinkedListValues(LinkedList<int> linkedList)
        {
            foreach (int element in linkedList)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }
}
