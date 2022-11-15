namespace Classes7._3
{
    public abstract class DeviceAbstractClass
    {
        public double numberOfPixelsInCamera;
        public int paperWidth;
        public int paperHeight;
        public string? modelName;
        public decimal price;
        public string Description
        {
            get
            {
                return $"Price: {price}, model:{modelName}, number of pixels in camera: {numberOfPixelsInCamera}";
            }
        }

        public DeviceAbstractClass(string? modelName, decimal price)
        {
            this.modelName = modelName;
            this.price = price;
        }

        public DeviceAbstractClass(string? modelName, decimal price, double numberOfPixelsInCamera) : this(modelName, price)
        {
            this.numberOfPixelsInCamera = numberOfPixelsInCamera;
        }

        public DeviceAbstractClass(string? modelName, decimal price, int paperWidth, int paperHeight) : this(modelName, price)
        {
            this.paperWidth = paperWidth;
            this.paperHeight = paperHeight;
        }

        public DeviceAbstractClass(string? modelName, decimal price, int paperWidth, int paperHeight, double numberOfPixelsInCamera) : this(modelName, price, paperWidth, paperHeight)
        {
            this.numberOfPixelsInCamera = numberOfPixelsInCamera;
        }

        public abstract void TurnOn();

        public void TunrnOff()
        {
            Console.WriteLine("Press Turn Off button");
        }
    }
}
