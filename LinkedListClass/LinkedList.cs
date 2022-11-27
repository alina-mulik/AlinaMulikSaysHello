namespace LinkedListClass
{
    public class LinkedList
    {
        private LinkedListNode _head;
        private LinkedListNode _current;
        public static int counter;

        public LinkedList()
        {
            _head = null;
            _current = null;
            counter = 0;
        }

        public void AddNodeToFront(int new_data)
        {
            LinkedListNode new_node = new LinkedListNode(new_data);
            new_node.next = _head;
            _head = new_node;
            counter++;
        }

        public void InsertSelectedNumAtPosition(LinkedListNode prev_node, int newdata)
        {
            if (prev_node == null)
            {
                Console.WriteLine("The given previous node is null");
                return;
            }
            LinkedListNode new_node = new LinkedListNode(newdata);
            new_node.next = prev_node.next;
            prev_node.next = new_node;
            counter++;
        }

        public void PrintLinkedList()
        {
            LinkedListNode runner = _head;
            while (runner != null)
            {
                Console.WriteLine(runner.data);
                runner = runner.next;
            }
        }

        public void InsertNewNodeByData(int data, int newData)
        {
            LinkedListNode pointer = _head;
            while (pointer != null)
            {
                if (pointer.data == data)
                {
                    InsertSelectedNumAtPosition(pointer, newData);
                }
                Console.WriteLine(pointer.data);
                pointer = pointer.next;
            }
        }

        public bool Contains(LinkedListNode listToCompare2)
        {
            LinkedListNode pointer = _head;
            while (pointer != null)
            {
                if (pointer.data == listToCompare2.data)
                {
                    return true;
                }
                pointer = pointer.next;
            }

            return false;
        }

        public LinkedList CompareTwoListsAndReturnCommonValuesList(LinkedList listToCompare2)
        {
            var list = new LinkedList();
            LinkedListNode pointer = _head;
            while (pointer != null)
            {
                if (listToCompare2.Contains(pointer))
                {
                    list.AddNodeToFront(pointer.data);
                }
                pointer = pointer.next;
            }

            return list;
        }
    }
}
