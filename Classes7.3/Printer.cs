namespace Classes7._3
{
    public class Printer : DeviceAbstractClass, IPrint
    {
        private int _paperWidth;
        private int _paperHeight;
        public Printer(string? modelName, decimal price, int paperWidth, int paperHeight) : base(modelName, price)
        {
            _paperWidth = paperWidth;
            _paperHeight = paperHeight;
        }

        public int PaperHeight { get => _paperHeight; set => _paperHeight = value; }
        public int PaperWidth { get => _paperWidth; set => _paperWidth = value; }

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
