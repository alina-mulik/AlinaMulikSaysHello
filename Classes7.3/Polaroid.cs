namespace Classes7._3
{
    public class Polaroid : DeviceAbstractClass, IPrint, ITakePhoto
    {
        public Polaroid(string? modelName, decimal price, int paperWidth, int paperHeight, double numberOfPixelsInCamera) : base(modelName, price, paperWidth, paperHeight, numberOfPixelsInCamera)
        {
        }

        public void TakePhoto()
        {
            Console.WriteLine("Press black button at the top and photo is ready");
        }

        public void Print()
        {
            Console.WriteLine("Printing...");
        }

        public override void TurnOn()
        {
            Console.WriteLine("Press right side button");
        }
    }
}
