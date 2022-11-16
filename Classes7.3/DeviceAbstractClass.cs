namespace Classes7._3
{
    public abstract class DeviceAbstractClass
    {
        protected string? ModelName;
        protected decimal Price;
        public virtual string Description { get; }

        public DeviceAbstractClass(string? modelName, decimal price)
        {
            this.ModelName = modelName;
            this.Price = price;
        }

        public abstract void TurnOn();

        public void TunrnOff()
        {
            Console.WriteLine("Press Turn Off button");
        }
    }
}
