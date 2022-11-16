namespace Classes7._3
{
    public abstract class DeviceAbstractClass
    {
        protected string? ModelName;
        protected decimal Price;
        public virtual string Description  => $"Price: {Price}, model:{ModelName}";

        public DeviceAbstractClass(string? modelName, decimal price)
        {
            this.ModelName = modelName;
            this.Price = price;
        }

        public abstract void TurnOn();

        public void TurnOff()
        {
            Console.WriteLine("Press Turn Off button");
        }
    }
}
