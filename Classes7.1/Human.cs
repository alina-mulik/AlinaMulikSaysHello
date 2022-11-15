using System.Drawing;

namespace Classes7._1
{
    public class Human : LivingBeingAbstractClass
    {
        private string _gender;
        public override string Name { get => name; set => name = value; }
        public override int Age { get => age; set => age = value; }
        public string? Gender { get => _gender; set => _gender = value; }

        public Human(string name, int age, string? gender) : base(name, age)
        {
            Gender = gender;
        }

        public override void Move()
        {
            Console.WriteLine($"The human {Name} is going: *sounds of footsteps*");
            pointsOfHappiness++;
        }

        public override void Eat()
        {
            Console.WriteLine($"The human {Name} is eating burger: *om-nom-nom-nom*");
            pointsOfHappiness++;
        }

        public void Drink()
        {
            Console.WriteLine($"The human {Name} is drinking water: *sounds of gulping*");
            pointsOfHappiness++;
        }

        public void Travel()
        {
            Console.WriteLine($"The human {Name} is traveling on a car: *sounds of car engine*");
            pointsOfHappiness++;
        }

        public void Work()
        {
            Console.WriteLine($"The human {Name} is working: *sounds of keyboard typing*");
            pointsOfHappiness++;
        }

        public void Rest()
        {
            Console.WriteLine($"The human {Name} is resting: *sounds of deep breething*");
            pointsOfHappiness++;
        }

        public override bool IsHappy()
        {
            if (pointsOfHappiness < 3)
            {
                isHappy = false;
                return isHappy;
            }

            isHappy = true;
            return isHappy;
        }
    }
}
