using Classes7._3;

namespace Main7._3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Printer lg = new Printer("23078", 2300, 15, 30);
            Polaroid panasonic = new Polaroid("78097", 1500, 10, 15, 5.00);
            MobilePhone iphone = new MobilePhone("13 Pro", 9000, 25.00);

            Console.WriteLine("Testing Printer functions:");
            lg.TurnOn();
            lg.Print();
            lg.TunrnOff();
            Console.WriteLine("---------------------");

            Console.WriteLine("Testing Polaroid functions:");
            panasonic.TurnOn();
            panasonic.TakePhoto();
            panasonic.Print();
            panasonic.TunrnOff();
            Console.WriteLine("---------------------");

            Console.WriteLine("Testing IPhone functions:");
            iphone.TurnOn();
            iphone.TakePhoto();
            iphone.TunrnOff();
        }
    }
}
