﻿using Classes7._2;

namespace Main7._2
{
    public class Program
    {
        static void Main(string[] args)
        {
            SuperHero superHero = new SuperHero(10);
            AntiHero antiHero = new AntiHero(10, "sword");

            superHero.BeHero();
            antiHero.BeHero();
            antiHero.UseWeapon(antiHero.Weapon, superHero);
            superHero.Heal();
            superHero.SaveHumanityFromAntiHero(antiHero);
        }
    }
}
