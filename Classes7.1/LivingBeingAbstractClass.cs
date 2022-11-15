namespace Classes7._1
{
    public abstract class LivingBeingAbstractClass
    {
        public bool isHappy;
        public int pointsOfHappiness;
        public static int counterOfLivingBeings;
        public string? name;
        public int age;
        public abstract string Name { get ; set; }
        public abstract int Age { get; set; }

        public LivingBeingAbstractClass(string? name, int age)
        {
            Name = name;
            Age = age;
            counterOfLivingBeings++;
        }

        public abstract void Move();

        public abstract void Eat();

        public abstract bool IsHappy();

    }
}
