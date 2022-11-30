using GenericsClasses;

namespace GenericsMain
{
    public class Program
    {
        static void Main(string[] args)
        {
            /* Task 1. Напишите обобщенный класс, который может хранить в массиве объекты любого типа.
             * Кроме того, данный класс должен иметь методы для добавления данных в массив, удаления из
             * массива, получения элемента из массива по индексу и метод, возвращающий длину массива.
             * A. Создайте три класса: Human (абстрактный – поля имя, фамилия + конструктор) -> Woman и Man
             * (наследники с двумя конструкторами:
            1. Без параметров, полям задаются значения по умолчанию,
            2. С параметрами имя и фамилия)
             * Б. Измените обобщённый массив так, чтобы он мог использовать тип только Woman и Man*/
            Console.WriteLine("Task 1:");
            Man jack = new Man("Jack", "Sparrow");
            Man johnny = new Man("Johnny", "Depp");
            GenericArrayClass <Man> array = new GenericArrayClass<Man>(jack);
            array.AddObjectToArray(johnny);
            array.AddObjectToArray(new Man("Bobby", "Hendrikson"));
            var element = array.GetObjectFromArrayByIndex(2);
            array.OutputFirstNamesOfItemsInArray();
            array.RemoveObjectsFromArray(element);
            array.OutputFirstNamesOfItemsInArray();


            /* Task 2. В классе с методом Main напишите обобщённый метод, который который будет
             * генерировать заданное количество элементов, элементы могут быть только типа
             * Man и Woman и должны создаваться через вызов конструктора их класса new()*/
            Console.WriteLine("----------");
            Console.WriteLine("Task 2:");
            CreateDefaultObjects(5, array);

            /* Task 3. В обобщённом классе создайте метод ToString(), который будет в зависимости
             * от типа обобщения выводить имена всех людей, а также сообщение “There’re only women”
             * или “There’re only men”*/
            Console.WriteLine("----------");
            Console.WriteLine("Task 3:");
            array.ToString();
        }

        public static void CreateDefaultObjects<T>(int numberOfObjects, GenericArrayClass<T> arrayToAddAt) where T : Human, new()
        {
            for (int i = 0; i < numberOfObjects; i++)
            {
                T human = new T();
                arrayToAddAt.AddObjectToArray(human);
            }
            arrayToAddAt.OutputFirstNamesOfItemsInArray();
        }
    }
}
