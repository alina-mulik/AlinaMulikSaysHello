namespace LinkedListClass
{
    public class LinkedListNode
    {
        internal int data;
        internal LinkedListNode next;
        internal LinkedListNode previous;

        public LinkedListNode(int value)
        {
            data = value;
            next = null;
        }

        public bool NodeEqualsData(int data)
        {
            if (this.data == data)
            {
                return true;
            }

            return false;
        }
    }
}
