namespace Classes7._2
{
    interface IEvil
    {
        public const string Motto = "I have no fear!";
        public string Weapon { get; set; }

        public void UseWeapon(string weapon, SuperHero hero);

        public void KillHero(SuperHero hero);
    }
}
