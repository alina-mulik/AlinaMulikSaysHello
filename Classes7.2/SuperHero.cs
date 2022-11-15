namespace Classes7._2
{
    public class SuperHero : IHero, ISaveHumanity
    {
        private int _numberOfLives;
        public int NumberOfLives { get => _numberOfLives; set => _numberOfLives = value; }
        public bool isGood { get => true; }

        public SuperHero(int numberOfLives)
        {
            NumberOfLives = numberOfLives;
        }

        public void BeHero()
        {
            Console.WriteLine("Hello! I am superhero. I am:");
            Console.WriteLine("Adopting a superhero mindset.");
            Console.WriteLine("Practicing mindfulness.");
            Console.WriteLine("Choosing empathy.");
            Console.WriteLine($"Say Hero Motto:{IHero.HeroMotto}");
            Console.WriteLine("---------------");
        }

        public int GetNumberOfLives()
        {
            return NumberOfLives;
        }

        public void Heal()
        {
            NumberOfLives++;
        }

        public void SaveHumanityFromAntiHero(AntiHero antihero)
        {
            antihero.NumberOfLives = 0;
            Console.WriteLine("The Hero is killing Anti-Hero!");
            Console.WriteLine($"The number of lives of Anti-Hero is {antihero.NumberOfLives} now!");
            Console.WriteLine("The Anti-Hero was killed! The Humanity was saved!");
        }
    }
}
