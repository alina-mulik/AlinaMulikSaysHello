using System;

namespace Classes7._3
{
    public class Polaroid : DeviceAbstractClass, IPrint, ITakePhoto
    {
        private double _numberOfPixelsInCamera;
        private int _paperWidth;
        private int _paperHeight;
        public override string Description
        {
            get
            {
                return $"Price: {Price}, model:{ModelName}, number of pixels in camera: {NumberOfPixelsInCamera}";
            }
        }
        public double NumberOfPixelsInCamera { get => _numberOfPixelsInCamera; set => _numberOfPixelsInCamera = value; }
        public int PaperHeight { get => _paperHeight; set => _paperWidth = value; }
        public int PaperWidth { get => _paperWidth; set => _paperWidth = value; }

        public Polaroid(string? modelName, decimal price, int paperWidth, int paperHeight, double numberOfPixelsInCamera) : base(modelName, price)
        {
            NumberOfPixelsInCamera = numberOfPixelsInCamera;
            _paperWidth = paperWidth;
            _paperHeight = paperHeight;
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
