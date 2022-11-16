namespace Classes7._1
{
    public abstract class LivingBeingAbstractClass
    {
        protected bool IsHappy;
        protected int PointsOfHappiness;
        protected static int CounterOfLivingBeings;
        protected string? Name;
        protected int Age;
        public abstract string LivingBeingName { get ; set; }
        public abstract int LivingBeingAge { get; set; }

        public LivingBeingAbstractClass(string? name, int age)
        {
            Name = name;
            Age = age;
            CounterOfLivingBeings++;
        }

        public abstract void Move();

        public abstract void Eat();

        public abstract bool IsLivingBeingHappy();

        public static int OutputCounterOfLivingBeings()
        {
            return CounterOfLivingBeings;
        }

        public int OutputPointsOfHappiness()
        {
            return PointsOfHappiness;
        }
    }
}
