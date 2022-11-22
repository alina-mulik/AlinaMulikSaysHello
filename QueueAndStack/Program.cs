namespace QueueAndStack
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Task 1:
            var newQueue = AddValuesOfTheQueue();
            Console.WriteLine($"The queue with the deleted element {DeleteValueInTheQueue(newQueue)}");

            // Task 2:
            var newStack = AddValuesOfTheStack();
            SortStackDesc(newStack);
        }

        /* Task 1. Создайте Queue. Добавьте занчения в очередь с при помощи ввода с консоли.
         * Реализуйте операцию: GetMaxValue, которая возвращает максимальное значение,
         * хранящееся в данный момент в очереди, не удаляя его. Каждый раз, когда текущий максимум
         * удаляется из очереди, операция GetMaxValue очереди должна отражать новый самый большой сохраненный элемент.*/
        public static Queue<int> AddValuesOfTheQueue()
        {
            while (true)
            {
                Console.WriteLine("Enter int values separated by comma and a space: ");
                var value = Console.ReadLine();
                try
                {
                    var convertedValue = value.Split(", ").ToList();
                    var nums = new Queue<int>();
                    foreach (var item in convertedValue)
                    {
                        nums.Enqueue(int.Parse(item));
                    }
                    Console.WriteLine($"The maximum element of the queue is: {GetMaxValue(nums)}");

                    return nums;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You've entered invalid value");
                }
            }
        }

        public static int GetMaxValue(Queue<int> queue)
        {
            return queue.Max();
        }

        public static Queue<int> DeleteValueInTheQueue(Queue<int> queueToDeleteFrom)
        {
            Console.WriteLine("Enter the value to delete: ");
            var value = Convert.ToInt32(Console.ReadLine());
            queueToDeleteFrom = new Queue<int>(queueToDeleteFrom.Where(x => x != value)) { };
            Console.WriteLine($"The maximum element of the queue is: {GetMaxValue(queueToDeleteFrom)}");

            return queueToDeleteFrom;
        }

        /* Task 2. Напишите программу, которая принимает на вход три буквы и отображает их в обратном порядке.
         * Используйте Stack.*/
        public static Stack<char> AddValuesOfTheStack()
        {
            while (true)
            {
                Console.WriteLine("Enter 3 char values separated by comma and a space: ");
                var value = Console.ReadLine();
                try
                {
                    var convertedValue = value.Split(", ").ToList();
                    var chars = new Stack<char>();
                    foreach (var item in convertedValue)
                    {
                        if (convertedValue.IndexOf(item) > 2)
                        {
                            Console.WriteLine("You've entered more than 3 characters!");
                            break;
                        }
                        chars.Push(Convert.ToChar(item));
                    }

                    return chars;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You've entered invalid value!");
                }
            }
        }

        public static void SortStackDesc(Stack<char> stack)
        {
            var orderedList = stack.OrderByDescending(x => x).ToList();
            Console.WriteLine("Stack sorted by desc:");
            foreach (var item in orderedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
