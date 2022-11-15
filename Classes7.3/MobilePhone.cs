namespace Classes7._3
{
    public class MobilePhone : DeviceAbstractClass, ITakePhoto
    {
        public MobilePhone(string? modelName, decimal price, double numberOfPixelsInCamera) : base(modelName, price, numberOfPixelsInCamera)
        {
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
