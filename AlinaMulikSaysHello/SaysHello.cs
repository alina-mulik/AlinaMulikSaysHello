namespace AlinaMulikSaysHello
{
    public class SaysHello
    {
        static void Main(string[] args)
        {
            SaysHelloFunc();
        }

        private static void SaysHelloFunc()
        {
            Console.WriteLine("Hi!");
            {
                while (true)
                {
                    Console.WriteLine("What's your name?");
                    string userName = Console.ReadLine();

                    if (userName != string.Empty)
                    {
                        Console.WriteLine($"Nice to meet you, {userName}!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please, enter your name!");
                    }
                }
            }
        }
    }
}
