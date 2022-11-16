using Classes7._3;

namespace Main7._3
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create instances of classes Printer, Polaroid, MobilePhone
            Printer lg = new Printer("23078", 2300, 15, 30);
            Polaroid panasonic = new Polaroid("78097", 1500, 10, 15, 5.00);
            MobilePhone iphone = new MobilePhone("13 Pro", 9000, 25.00);

            // Test some functions of these technical devices
            Console.WriteLine($"Printer description:{lg.Description}");
            Console.WriteLine($"Paper width: {lg.PaperWidth}");
            Console.WriteLine($"Paper height: {lg.PaperHeight}");
            Console.WriteLine("Testing Printer functions:");
            lg.TurnOn();
            lg.Print();
            lg.TurnOff();
            Console.WriteLine("---------------------");

            Console.WriteLine($"Polaroid description:{panasonic.Description}");
            Console.WriteLine($"Paper width: {panasonic.PaperWidth}");
            Console.WriteLine($"Paper height: {panasonic.PaperHeight}");
            Console.WriteLine("Testing Polaroid functions:");
            panasonic.TurnOn();
            panasonic.TakePhoto();
            panasonic.Print();
            panasonic.TurnOff();
            Console.WriteLine("---------------------");

            Console.WriteLine($"IPhone description:{iphone.Description}");
            Console.WriteLine("Testing IPhone functions:");
            iphone.TurnOn();
            iphone.TakePhoto();
            iphone.TurnOff();
        }
    }
}
