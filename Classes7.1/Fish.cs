namespace Classes7._1
{
    public class Fish : LivingBeingAbstractClass
    {
        private string _colour;

        public override string Name { get => name; set => name = "Fish " + value; }
        public override int Age { get => age; set => age = value; }
        public string Colour { get => _colour; set => _colour = value; }

        public Fish(string colour, string name, int age) : base(name, age)
        {
            Colour = colour;
        }

        public override void Eat()
        {
            Console.WriteLine($"The {Name} is eating worms: *om-nom-nom-nom*");
            pointsOfHappiness++;
        }

        public override void Move()
        {
            Console.WriteLine($"The {Name} is moving in the water silently.");
            pointsOfHappiness++;
        }

        public void Play()
        {
            Console.WriteLine($"The {Name} is playing with other fishes.");
            pointsOfHappiness++;
        }

        public void Hide()
        {
            Console.WriteLine($"The {Name} is hiding from predator.");
            pointsOfHappiness++;
        }

        public void MakeBubbles()
        {
            Console.WriteLine($"The {Name} is making bubbles: *bul-bulk-bul*");
            pointsOfHappiness++;
        }

        public override bool IsHappy()
        {
            if (pointsOfHappiness < 2)
            {
                isHappy = false;
                return isHappy;
            }

            isHappy = true;
            return isHappy;
        }
    }
}
