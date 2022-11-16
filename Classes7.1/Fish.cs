namespace Classes7._1
{
    public class Fish : LivingBeingAbstractClass
    {
        private string _colour;

        public override string LivingBeingName { get => Name; set => Name = "Fish " + value; }
        public override int LivingBeingAge { get => Age; set => Age = value; }
        public string Colour { get => _colour; set => _colour = value; }

        public Fish(string colour, string name, int age) : base(name, age)
        {
            Colour = colour;
        }

        public override void Eat()
        {
            Console.WriteLine($"The {LivingBeingName} is eating worms: *om-nom-nom-nom*");
            PointsOfHappiness++;
        }

        public override void Move()
        {
            Console.WriteLine($"The {LivingBeingName} is moving in the water silently.");
            PointsOfHappiness++;
        }

        public void Play()
        {
            Console.WriteLine($"The {LivingBeingName} is playing with other fishes.");
            PointsOfHappiness++;
        }

        public void Hide()
        {
            Console.WriteLine($"The {LivingBeingName} is hiding from predator.");
            PointsOfHappiness++;
        }

        public void MakeBubbles()
        {
            Console.WriteLine($"The {LivingBeingName} is making bubbles: *bul-bulk-bul*");
            PointsOfHappiness++;
        }

        public override bool IsLivingBeingHappy()
        {
            if (PointsOfHappiness < 2)
            {
                IsHappy = false;
                return IsHappy;
            }
            IsHappy = true;

            return IsHappy;
        }
    }
}
