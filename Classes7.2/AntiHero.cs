namespace Classes7._2
{
    public class AntiHero : IHero, IEvil
    {
        private int _numberOfLives;
        private string _weapon;
        public int NumberOfLives { get => _numberOfLives; set => _numberOfLives = value; }
        public bool isGood { get => false; }
        public string Weapon { get => _weapon; set => _weapon = value; }

        public AntiHero(int numberOfLives, string weapon)
        {
            NumberOfLives = numberOfLives;
            weapon = _weapon;
        }

        public void BeHero()
        {
            Console.WriteLine("Hello! I am anti-hero. I am:");
            Console.WriteLine("Adopting a anti-hero mindset.");
            Console.WriteLine("Practicing being evil.");
            Console.WriteLine("Choosing the dark side.");
            Console.WriteLine($"Say Hero Motto:{IHero.HeroMotto}");
            Console.WriteLine("---------------");
        }

        public int GetNumberOfLives()
        {
            return NumberOfLives;
        }

        public void KillHero(SuperHero hero)
        {
            hero.NumberOfLives = 0;
            Console.WriteLine($"The number of lives of Hero is {hero.NumberOfLives} now!");
            Console.WriteLine("The Hero was killed!");
        }

        public void UseWeapon(string weapon, SuperHero hero)
        {
            Console.WriteLine($"Anti-Hero uses the weapon {weapon}");
            hero.NumberOfLives--;
            Console.WriteLine($"The number of lives of Hero is {hero.NumberOfLives} now!");
        }
    }
}
