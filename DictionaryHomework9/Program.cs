using CityClass;

namespace DictionaryHomework9
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Task 1
            Console.WriteLine("Task 1");
            AddValuesToDictAndOutputThem();

            // Task 2
            Console.WriteLine("Task 2");
            List<string> listOfString = new List<string> { "Bear", "Wolf", "Rabbit", "Elephant", "Snake", "Frog", "Dog", "Cat", "Bat", "Lemur"};
            List<int> listOfInts = new List<int> { 3, 7, 1, 9, 99, 51, 2, 90, 67, 77 };
            var newDict = SortAndUnionGivenListsToDict(listOfString, listOfInts);
            OutputDictionaryKeysValuesTask2(newDict);

            // Task 3
            Console.WriteLine("Task 3");
            City newYork = new City(8468000, 302.6);
            City oslo = new City(634293, 175.3);
            City copenhagen = new City(602481, 69.42);
            City vienna = new City(1897000, 160.1);
            City brno = new City(379526, 88.87);
            Dictionary<string, City> citiesDictionary= new Dictionary<string, City>
            {
                { "New York", newYork },
                { "Oslo", oslo },
                { "Copenhagen", copenhagen },
                { "Vienna", vienna },
                { "Brno", brno }
            };
            Console.WriteLine("Sorted City Dictionary by Square:");
            var sortedCitiesDictBySquare = SortCityDictBySquare(citiesDictionary);
            OutputDictionaryKeysValuesTask3(sortedCitiesDictBySquare);
            Console.WriteLine("Sorted City Dictionary by Population Desc:");
            var sortedCitiesDictByPopulation = SortDescCityDictByPopulation(citiesDictionary);
            OutputDictionaryKeysValuesTask3(sortedCitiesDictByPopulation);
            var totalPopulationFromAllCities = CountAllPopulation(citiesDictionary);
            Console.WriteLine($"Total population from all cities: {totalPopulationFromAllCities}");
        }

        /* Task 1. Добавьте новое значение, ключом которого является ваше имя, а значение — ваш возраст.
         * Сделайте это с помощью метода Add. Затем добавьте еще одно значение в словарь, используя нотацию индекса.
         * На этот раз используйте другое имя и другой возраст. Наконец, прочитайте первый элемент, который вы добавили
         * в словарь, и запишите его в консоль с помощью Console.WriteLine.*/
        public static void AddValuesToDictAndOutputThem()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.Add("Alina", 26);
            dictionary["Kate"] = 29;
            try
            {
                var searchedElement = dictionary.First();
                Console.WriteLine("Key of the first element in the Dict: {0}; Value is: {1}", searchedElement.Key, searchedElement.Value);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("The key is not found.");
            }
        }

        /* Task 2. Создайте два списка, в каждом 10 значений. Первый список типа int, где значения
         * заданы не по-порядку. Второй список типа string, значения так же заданы не по алфавиту.
         * Напишите метод, который совершает операции сортировки двух списков, списка int – по возрастанию,
         * списка string – по убыванию. Затем данный метод объединяет списки в словарь. Полученный словарь
         * выведите на консоль*/
        public static Dictionary<string, int> SortAndUnionGivenListsToDict(List<string> stringList, List<int> intList)
        {
            var orderedStrigList = stringList.OrderByDescending(p => p).ToList();
            var orderedIntsList = intList.OrderBy(p => p).ToList();
            var dic = orderedStrigList.Select((k, i) => new { k, v = orderedIntsList[i] })
              .ToDictionary(x => x.k, x => x.v);

            return dic;
        }

        public static void OutputDictionaryKeysValuesTask2(Dictionary<string, int> dictionary)
        {
            foreach (var (key, value) in dictionary)
            {
                Console.WriteLine($"{key}: {value}");
            }
        }

        /* Task 3. Создайте класс City, где есть поля int население, double площадь. Создайте словарь, где Key – название города,
        а Value – сооттветствующий названию города объект типа City. Создайте 5 элементов для словаря.
        Отсортируйте словарь по площади города и выведите на консоль
        Остортируйте словарь по населению в обратном порядке и выведите на консоль
        Подсчитайте общее население все городов и выведите на консоль */
        public static Dictionary<string, City> SortCityDictBySquare(Dictionary<string, City> cityDict)
        {
            var ordered = cityDict.OrderBy(x => x.Value.Square).ToDictionary(x => x.Key, x => x.Value);

            return ordered;
        }

        public static Dictionary<string, City> SortDescCityDictByPopulation(Dictionary<string, City> cityDict)
        {
            var ordered = cityDict.OrderByDescending(x => x.Value.Population).ToDictionary(x => x.Key, x => x.Value);

            return ordered;
        }

        public static int CountAllPopulation(Dictionary<string, City> cityDict)
        {
            var totalPopualtion = cityDict.Sum(x => x.Value.Population);

            return totalPopualtion;
        }

        public static void OutputDictionaryKeysValuesTask3(Dictionary<string, City> dictionary)
        {
            foreach (var (key, value) in dictionary)
            {
                Console.WriteLine($"{key}: Population - {value.Population}, Square - {value.Square}");
            }
        }
    }
}
