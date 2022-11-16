using System.Drawing;

namespace Classes7._1
{
    public class Human : LivingBeingAbstractClass
    {
        private string _gender;
        public override string LivingBeingName { get => Name; set => Name = value; }
        public override int LivingBeingAge { get => Age; set => Age = value; }
        public string? Gender { get => _gender; set => _gender = value; }

        public Human(string name, int age, string? gender) : base(name, age)
        {
            Gender = gender;
        }

        public override void Move()
        {
            Console.WriteLine($"The human {LivingBeingName} is going: *sounds of footsteps*");
            PointsOfHappiness++;
        }

        public override void Eat()
        {
            Console.WriteLine($"The human {LivingBeingName} is eating burger: *om-nom-nom-nom*");
            PointsOfHappiness++;
        }

        public void Drink()
        {
            Console.WriteLine($"The human {LivingBeingName} is drinking water: *sounds of gulping*");
            PointsOfHappiness++;
        }

        public void Travel()
        {
            Console.WriteLine($"The human {LivingBeingName} is traveling on a car: *sounds of car engine*");
            PointsOfHappiness++;
        }

        public void Work()
        {
            Console.WriteLine($"The human {LivingBeingName} is working: *sounds of keyboard typing*");
            PointsOfHappiness++;
        }

        public void Rest()
        {
            Console.WriteLine($"The human {LivingBeingName} is resting: *sounds of deep breething*");
            PointsOfHappiness++;
        }

        public override bool IsLivingBeingHappy()
        {
            if (PointsOfHappiness < 3)
            {
                IsHappy = false;
                return IsHappy;
            }
            IsHappy = true;

            return IsHappy;
        }
    }
}
