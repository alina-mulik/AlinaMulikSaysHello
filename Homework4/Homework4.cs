using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    public class Homework4
    {
        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            //Task3();
            //Task4();
            //Task5();
            //Task6();
            Task7();
            //Task8();
            //Task9();
        }

        /* Task 1
        Пользователь вводит любое положительное число. Написать программу, которая считает сумму чисел от 0 до введенного числа.
        Результат вычисления вывести в консоль.*/

        private static void Task1()
        {
            Console.WriteLine("Task 1");
            Console.WriteLine("Enter the number:");
            var num = Console.ReadLine();
            try
            {
                var convertedNumInt32 = Convert.ToInt32(num);
                var summ = 0;
                for (int i = 0; i <= convertedNumInt32; i++)
                {
                    summ += i;
                }
                Console.WriteLine($"The summ of numbers in this number is: {summ}.");
            }
            catch (FormatException)
            {
                Console.WriteLine("You've entered not an integer value. Can't convert it.");
            }
        }

        /* Task 2
        Используя цикл while, вывести в консоль таблицу умножения для числа 3.
        */

        private static void Task2()
        {
            Console.WriteLine("Task 2");
            Console.WriteLine("Multiplication table for number 3:");
            var number3 = 3;
            var numberForMultiplication = 1;
            while (numberForMultiplication < 11)
            {
                var multiplicationResult = number3 * numberForMultiplication;
                Console.WriteLine($"{number3} * {numberForMultiplication} = {multiplicationResult}");
                numberForMultiplication++;
            }
        }

        /* Task 3
        Создать массив чисел [3, 5, 9, 8, 15]. Найдите произведение этих чисел и вывести в консоль результат.
        */

        private static void Task3()
        {
            Console.WriteLine("Task 3");
            int[] ints = new int[] { 3, 5, 9, 8, 15 };
            var multiplicationResult = 1;
            foreach (int i in ints)
            {
                multiplicationResult *= i;
            }
            Console.WriteLine($"Multiplication result for numbers in [3, 5, 9, 8, 15] array: {multiplicationResult}");
        }

        /* Task 4
        Написать программу, которая подсчитывает, сколько раз необходимо поделить число 2048 на 2, чтобы оно стало меньше 10.
        */

        private static void Task4()
        {
            Console.WriteLine("Task 4");
            var num = 2048;
            var numberOfDivisions = 0;
            while (num > 10)
            {
                num /= 2;
                numberOfDivisions++;
            }
            Console.WriteLine($"The number of divisions for 2048 till it becomes less than 10 is: {numberOfDivisions}");
        }

        /* Task 5
        Создать массив строк. Написать программу, которая анализирует созданный массив и в случае наличие строки со значением “Hello”,
        выводит в консоль слово “Labas!” и выходит из цикла.
        */

        private static void Task5()
        {
            Console.WriteLine("Task 5");
            string[] namesOfHogwartsStudents = new string[] { "Harry", "Ron", "Neville", "Hello", "Hermione", "Pansy" };
            foreach (var item in namesOfHogwartsStudents)
            {
                if (item == "Hello")
                {
                    Console.WriteLine("Labas!");
                    break;
                }
            }
        }

        /* Task 6
         Создайте массив чисел. Напишите программу, которая подсчитывает сумму первого
        и последнего элемента массива и выводит ее в консоль.
         */

        private static void Task6()
        {
            Console.WriteLine("Task 6");
            int[] ints = new int[] { 10, 3, 5, 9, 8, 15, 45 };
            var summ = ints[0] + ints[ints.Length - 1];
            Console.WriteLine($"{ints.First()} + {ints.Last()} = {summ}");
        }

        /* Task 7
         Найдите сумму индексов минимального и максимального элементов массива.
         */

        private static void Task7()
        {
            Console.WriteLine("Task 7");
            int[] ints = new int[] { 1, 0, 5, 9, 8, 99, 15, 7 };
            var numOfMax = 0;
            var numOfMin = 0;

            foreach (var item in ints)
            {
                foreach (var item2 in ints)
                {
                    if (item < item2)
                    {
                        numOfMin = item2;
                    }

                    else if (item > item2)
                    {
                        numOfMax = item2;
                    }
                }
            }

            var maxIndex = Array.IndexOf(ints, numOfMax);
            var minIndex = Array.IndexOf(ints, numOfMin);
            var summ = maxIndex + minIndex;
            Console.WriteLine($"{maxIndex} + {minIndex} = {summ}");
        }

        /* Task 8
         Создайте массив чисел и отсортируйте его элементы в порядке возрастания.
         */

        private static void Task8()
        {
            Console.WriteLine("Task 8");
            int[] ints = new int[] { 1, 0, 5, 89, 9, 80, 99, 15, 7, 3 };
            Array.Sort(ints);
            Console.WriteLine("Sorted array:");
            Array.ForEach(ints, i => Console.WriteLine(i));
        }

        /* Task 9
         Выведите в консоль таблицу умножения для чисел от 1 до 10.
         */

        private static void Task9()
        {
            Console.WriteLine("Task 9");
            Console.WriteLine("Full Multiplication Table: ");
            int[] ints = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (var item in ints)
            {
                var count = 1;
                var numberForIncreasing = 0;
                while (count < 11)
                {
                    var numberForMultiplication = 1;
                    var sumOfNumbers = numberForMultiplication + numberForIncreasing;
                    var multiplicationResult = item * sumOfNumbers;
                    Console.WriteLine($"{item} * {sumOfNumbers} = {multiplicationResult}");
                    count++;
                    numberForIncreasing++;
                }
                Console.WriteLine("________________");
            }
        }
    }
}
