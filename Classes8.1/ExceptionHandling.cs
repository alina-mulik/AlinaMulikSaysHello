namespace Classes8._1
{
    public class ExceptionHandling
    {
        public static void ShowMassiveElement()
        {
            int[] massive = { 8, 7, 1, 4, 2 };

            Console.WriteLine("Input index of element in massive:");
            try
            {
                string? inputedValue = Console.ReadLine();
                string? checkedValue = inputedValue.Equals(string.Empty) ? null : inputedValue;
                int inputtedNumber = int.Parse(checkedValue);
                int massiveElement = massive[inputtedNumber];
                Console.WriteLine($"Massive element that has index {inputedValue} has value {massiveElement}");
            }
            catch (FormatException e) when (LogException(e))
            {
                Console.WriteLine("An exception has been logged.");
            }
            catch (IndexOutOfRangeException e) when (LogException(e))
            {
                Console.WriteLine("An exception has been logged.");
            }
            catch (ArgumentNullException e) when (LogException(e))
            {
                Console.WriteLine("An exception has been logged.");
            }
        }

        private static bool LogException(Exception e)
        {
            Console.WriteLine("-----------");
            Console.WriteLine($"ALARM! System caught an exception:  {e.GetType()}");
            Console.WriteLine($"\tException message: {e.Message}");
            Console.WriteLine($"\tSource: {e.Source}");
            Console.WriteLine($"Call stack:{e.StackTrace}");
            Console.WriteLine("-----------");
            return true;
        }


    }
}
