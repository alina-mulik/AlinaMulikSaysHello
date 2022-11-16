namespace Classes7._3
{
    public class MobilePhone : DeviceAbstractClass, ITakePhoto
    {
        private double _numberOfPixelsInCamera;
        public override string Description
        {
            get
            {
                return $"Price: {Price}, model:{ModelName}, number of pixels in camera: {NumberOfPixelsInCamera}";
            }
        }
        public double NumberOfPixelsInCamera { get => _numberOfPixelsInCamera; set => _numberOfPixelsInCamera = value; }

        public MobilePhone(string? modelName, decimal price, double numberOfPixelsInCamera) : base(modelName, price)
        {
            NumberOfPixelsInCamera = numberOfPixelsInCamera;
        }

        public void TakePhoto()
        {
            Console.WriteLine("Press button on the screen and photo is ready");
        }

        public override void TurnOn()
        {
            Console.WriteLine("Press left side button");
        }
    }
}
