using LinkedListClass;
using System.Threading;

namespace LinkedListHomework9
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Task 1
            Console.WriteLine("Task 1.");
            LinkedList linked = new LinkedList();
            linked.AddNodeToFront(2);
            linked.AddNodeToFront(3);
            linked.AddNodeToFront(2);
            linked.AddNodeToFront(5);
            linked.AddNodeToFront(2);
            Console.WriteLine("Linked list BEFORE adding new nodes after every node with data=2:");
            linked.PrintLinkedList();
            Console.WriteLine("Linked list AFTER adding new nodes after every node with data=2:");
            linked.InsertNewNodeByData(2, 10);
            linked.PrintLinkedList();

            // Task 2
            Console.WriteLine("Task 2.");
            Console.WriteLine("Common numbers in 2 Linked Lists:");
            var linkedList1 = new LinkedList();
            linkedList1.AddNodeToFront(1);
            linkedList1.AddNodeToFront(2);
            linkedList1.AddNodeToFront(3);
            linkedList1.AddNodeToFront(4);
            linkedList1.AddNodeToFront(5);
            linkedList1.AddNodeToFront(6);
            var linkedList2 = new LinkedList();
            linkedList2.AddNodeToFront(1);
            linkedList2.AddNodeToFront(2);
            linkedList2.AddNodeToFront(3);
            linkedList2.AddNodeToFront(8);
            linkedList2.AddNodeToFront(9);
            linkedList2.AddNodeToFront(10);
            var commonList = linkedList1.CompareTwoListsAndReturnCommonValuesList(linkedList2);
            commonList.PrintLinkedList();
        }
        /* Task 1. Создайте LinkedList и два элемента, вставьте второй элемент
         * после каждого вхождения первого элемента в списке. https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=net-6.0
         * Итак, если список равен [2,4,3,2,8,2,5,1,2], а элементы равны 2 и 10,
         * результатом будет [2,10,4,3,2,10,8,2,10,5,1,2,10] */

        /* Task 2. Объединить два связанных списка чисел, включив в окончательный список только те числа,
         * которые встречаются в обоих спискаx.
         * Итак, если списки [1,3,4,7,12] и [1,5,7,9], результат будет [1,7].*/
    }
}
