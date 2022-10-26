namespace AlinaMulikSaysHello
{
    public class Homework3
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
            Task7();
            Task8();
            Task9();
        }

        /* Task 1
         Создайте переменную «num» со значением 20. Добавьте к ней число 5.
         Добавление выполните за счет сокращенной записи добавления числа к переменной.Выведите на экран информацию в следующем формате:
         «Переменная: var», где var – это ваша переменная num.*/

        private static void Task1()
        {
            Console.WriteLine("Task 1");
            var num = 20;
            num += 5;
            Console.WriteLine($"Variable: {num}");
        }

        /* Task 2
        Напишите программу, которая будет получать от пользователя четырёхзначное число, которое представляет собой n дней.
        Посчитайте и выведите в консоль сколько данное количество дней составляет лет, месяцев, дней.
        (5 лет, 2 месяца, 1 день).*/

        private static void Task2()
        {
            Console.WriteLine("Task 2");
            Console.WriteLine("Enter the number of days, which contains at least 4 symbols:");
            var daysQuantity = Console.ReadLine();
            if (daysQuantity.Length < 4)
            {
                Console.WriteLine("You've entered the number less, in which there are less than 4 symbols.");
            }
            else
            {
                try
                {
                    var numberOfYears = Int32.Parse(daysQuantity) / 365;
                    var numberOfMonth = (Int32.Parse(daysQuantity) % 365) / 30;
                    var numberOfDays = (Int32.Parse(daysQuantity) % 365) % 30;
                    Console.WriteLine(
                        $"You've entered: {numberOfYears} years, {numberOfMonth} month, {numberOfDays} days.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("You've entered not an integer value. Can't convert it.");
                }
            }
        }

        /* Task 3
        Создайте программу, которая будет принимать число (n), введенное пользователем,
        и выдавать результат в виде (n + n * 2).*/

        private static void Task3()
        {
            Console.WriteLine("Task 3");
            Console.WriteLine("Enter the number:");
            var n = Console.ReadLine();
            try
            {
                var parsedN = Int32.Parse(n);
                var result = parsedN + parsedN * 2;
                Console.WriteLine(result);
            }

            catch (FormatException)
            {
                Console.WriteLine("You've entered not an integer value. Can't convert it.");
            }
        }

        /* Task 4
        Создайте переменные для хранения следующий значений: -34, 4, 'Hello', 'R', 23.093433222, 40000, true, 0.
        Продумайте типы данных для переменных, чтобы они максимально подходили под каждое значение.*/

        private static void Task4()
        {
            Console.WriteLine("Task 4");
            sbyte number1 = -37;
            Console.WriteLine($"{number1.GetType()}");
            byte number2 = 4;
            Console.WriteLine($"{number2.GetType()}");
            string hello3 = "Hello";
            Console.WriteLine($"{hello3.GetType()}");
            char r4 = 'R';
            Console.WriteLine($"{r4.GetType()}");
            double number5 = 23.093433222;
            Console.WriteLine($"{number5.GetType()}");
            int number6 = 40000;
            Console.WriteLine($"{number6.GetType()}");
            bool boolean7 = true;
            Console.WriteLine($"{boolean7.GetType()}");
            byte zero8 = 0;
            Console.WriteLine($"{zero8.GetType()}");
        }

        /* Task 5
        Получите от пользователя данные и запишите их в переменные с типами данных: short, ulong, char, double. */

        private static void Task5()
        {
            Console.WriteLine("Task 5");
            Console.WriteLine("Enter the number from -32768 to 32767:");
            var number1 = Console.ReadLine();
            try
            {
                short result1 = Convert.ToInt16(number1);
                Console.WriteLine(result1.GetType());
            }

            catch (FormatException)
            {
                Console.WriteLine("You've entered not an integer value. Can't convert it.");
            }

            Console.WriteLine("Enter the number from 0 to 18 446 744 073 709 551 615:");
            var number2 = Console.ReadLine();
            try
            {
                ulong result2 = Convert.ToUInt64(number2);
                Console.WriteLine(result2.GetType());
            }

            catch (FormatException)
            {
                Console.WriteLine("You've entered not an integer value. Can't convert it.");
            }

            Console.WriteLine("Enter one character:");
            var number3 = Console.ReadLine();
            try
            {
                char result3 = Convert.ToChar(number3);
                Console.WriteLine(result3.GetType());
            }

            catch (FormatException)
            {
                Console.WriteLine("You've entered wrong value. Can't convert it.");
            }

            Console.WriteLine("Enter a fractional number from ±5.0*10-324 до ±1.7*10308:");
            var number4 = Console.ReadLine();
            try
            {
                double result4 = Convert.ToDouble(number4);
                Console.WriteLine(result4.GetType());
            }

            catch (FormatException)
            {
                Console.WriteLine("You've entered wrong value. Can't convert it.");
            }
        }

        /* Task 6
        Создайте переменную со значением -5. Выполните над ней операции: умножьте её на 7; выполните декременацию (уменьшение на один). */
        private static void Task6()
        {
            Console.WriteLine("Task 6");
            var num = 5;
            Console.WriteLine($"5 multiplied by 7: {num * 7}");
            Console.WriteLine($"5 reduced by 1: {--num}");
        }

        /* Task 7
        Попросите пользователя ввести число. Выведите на экран информацию о том, чётное число или нет. */
        private static void Task7()
        {
            Console.WriteLine("Task 7");
            Console.WriteLine("Enter a number:");
            var num = Console.ReadLine();
            try
            {
                var convertedNum = Convert.ToInt32(num);
                Console.WriteLine(
                    (convertedNum % 2 == 0) ? "The entered number is even." : "The entered number is odd.");
            }

            catch (FormatException)
            {
                Console.WriteLine("You've entered wrong value. Can't convert it.");
            }
        }

        /* Task 8
        Попросите пользователя ввести число и присвойте введённое значение переменной A. Используя конструкцию if else,
        создайте проверку, которая выведет на экран слово "Working" в случае если переменная А будет меньше чем 50 и не равна 37,
        но при этом не меньше или равна 32.
        Допишите в само условие ИЛИ проверку: если число А будет равным 0 или 15, то условие также будет выполняться. */
        private static void Task8()
        {
            Console.WriteLine("Task 8");
            Console.WriteLine("Enter a number:");
            var a = Console.ReadLine();
            try
            {
                var convertedA = Convert.ToInt32(a);
                if (convertedA != 37 & convertedA < 50 & convertedA >= 32 | convertedA == 0 || convertedA == 15)
                {
                    Console.WriteLine("Working");
                }
                else
                {
                    Console.WriteLine("Not working");
                }
            }

            catch (FormatException)
            {
                Console.WriteLine("You've entered wrong value. Can't convert it.");
            }
        }

        /* Task 9
        Попросите пользователя ввести два числа, а также арифметическое действие (+, -, *, /).
        В зависимости от символа, который будет введен, выполните математические действия над числами,
        которые ввел пользователь.
        Для проверки данных используйте оператор switch case.*/
        private static void Task9()
        {
            Console.WriteLine("Task 9");
            Console.WriteLine("Enter first number:");
            var firstNumber = Console.ReadLine();
            Console.WriteLine("Enter second number:");
            var secondNumber = Console.ReadLine();
            Console.WriteLine("Select operation (+, -, *, /):");
            var operation = Console.ReadLine();

            try
            {
                var convertedFirstNumber = Convert.ToInt32(firstNumber);
                var convertedSecondNumber = Convert.ToInt32(secondNumber);
                switch (operation)
                {
                    case ("+"):
                    {
                        Console.WriteLine($"{convertedFirstNumber + convertedSecondNumber}");
                        break;
                    }
                    case ("-"):
                    {
                        Console.WriteLine($"{convertedFirstNumber - convertedSecondNumber}");
                        break;
                    }
                    case ("*"):
                    {
                        Console.WriteLine($"{convertedFirstNumber * convertedSecondNumber}");
                        break;
                    }
                    case ("/"):
                    {
                        Console.WriteLine($"{convertedFirstNumber / convertedSecondNumber}");
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Sorry. I don't know this type of operation.");
                        break;
                    }
                }
            }

            catch (FormatException)
            {
                Console.WriteLine("You've entered wrong value. Can't convert it.");
            }
        }
    }
}
