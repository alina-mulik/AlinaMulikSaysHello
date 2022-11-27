namespace ListsHomework9
{
    public class Program
    {
        static void Main(string[] args)
        {
            var listOfNumbersForTesting = new List<int> { 2, 19, 10, 8, 4, 3, 7, 9, 16, 31};
            var listOfWordsForTesting = new List<string> { "Goblin", "Werewolf", "Assassin", "Demon", "Elf", "Yeti", "Vampire", "Spider", "Golem", "Witch" };

            // Task 1
            Console.WriteLine(GetSumOfTheList(listOfNumbersForTesting));

            // Task 2
            Console.WriteLine(GetElementOfTheListWith5Letters(listOfWordsForTesting));

            // Task 3
            Console.WriteLine(GetElementOfTheListWithNLetters(listOfWordsForTesting));
        }

        /* Task 1. Напишите метод для нахождения суммы всех четных чисел в списке.
         В Main создайте список, содержащий не менее 10 целых чисел, вызовите свой метод
          и выдите полученный результат.*/
        private static int GetSumOfTheList(List<int> listOfInts)
        {
            var result = listOfInts.Where(d => d % 2 == 0).Sum();

            return result;
        }

        /* Task 2. В Main создайте список строк, где содержатся слова разной длины.
        * Напишите статический метод для вывода каждого слова из списка, состоящего ровно из 5 букв.*/
        private static string GetElementOfTheListWith5Letters(List<string> listOfStrings)
        {
            var result = listOfStrings.Where(d => d.Length == 5);

            return String.Join(",", result);
        }

        /* Task 3. В Main создайте список строк, где содержатся слова разной длины.
        * Напишите статический метод для вывода каждого слова из списка, состоящего ровно из 5 букв.
        Измените свой код, чтобы предложить пользователю ввести длину слова для поиска. (через LINQ)*/
        private static string GetElementOfTheListWithNLetters(List<string> listOfStrings)
        {
            while (true)
            {
                Console.WriteLine("Please, enter the number of letters in the word to select from the list:");
                try
                {
                    var numberOfLetters = Convert.ToInt32(Console.ReadLine());
                    var result = listOfStrings.Where(d => d.Length == numberOfLetters);

                    return String.Join(",", result);
                }
                catch (FormatException)
                {
                    Console.WriteLine("You've entered the wrong value. Please, try again.");
                }
            }
        }
    }
}
