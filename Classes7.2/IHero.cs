namespace Classes7._2
{
    interface IHero
    {
        public const string HeroMotto = "I have no fear!";
        public int NumberOfLives { get; set; }
        public bool IsGood { get; }

        public void BeHero();

        public int GetNumberOfLives();
    }
}
