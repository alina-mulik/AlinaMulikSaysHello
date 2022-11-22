namespace DictionaryHomework9
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Task 1
            Task1AddValuesToDictAndOutputThem();
        }

        /* Task 1. Добавьте новое значение, ключом которого является ваше имя, а значение — ваш возраст.
         * Сделайте это с помощью метода Add. Затем добавьте еще одно значение в словарь, используя нотацию индекса.
         * На этот раз используйте другое имя и другой возраст. Наконец, прочитайте первый элемент, который вы добавили
         * в словарь, и запишите его в консоль с помощью Console.WriteLine..*/
        public static void Task1AddValuesToDictAndOutputThem()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.Add("Alina", 26);
            dictionary["Kate"] = 29;
            try
            {
                var search = dictionary.Where(p => p.Key.Contains("Alina"));
                foreach (var result in search)
                {
                    Console.WriteLine("Product Name: {0}, Age: {1}", result.Key, result.Value);
                }
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("The key is not found.");
            }
        }
    }
}
