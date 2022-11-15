namespace Classes7._3
{
    public class Printer : DeviceAbstractClass, IPrint
    {
        public Printer(string? modelName, decimal price, int paperWidth, int paperHeight) : base(modelName, price, paperWidth, paperHeight)
        {
        }

        public new string Description
        {
            get
            {
                return $"Price: {price}, model:{modelName}";
            }
        }

        public void Print()
        {
            Console.WriteLine("Printing...");
        }

        public override void TurnOn()
        {
            Console.WriteLine("Press button at the top");
        }
    }
}
