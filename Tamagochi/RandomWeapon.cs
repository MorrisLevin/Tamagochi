using System.Linq;
using System.ComponentModel.DataAnnotations;
using System;
using System.Security.Cryptography;
using System.Collections.Generic;


namespace Tamagochi
{
    public class RandomWeapon : Weapon
    {


        private Random generator = new Random();
        Dictionary<string, int> randomWeapon = new Dictionary<string, int>() {
            {"Sword", 8},
            {"Spear", 10},
            {"Axe", 14},
            {"Mace", 12}
        };

        public RandomWeapon()
        {

            int i = generator.Next(randomWeapon.Keys.Count);

            string wKey = randomWeapon.Keys.ToList()[i];

            damage = randomWeapon[wKey];

            name = wKey;



        }



    }
}