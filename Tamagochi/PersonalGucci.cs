using System;

namespace Tamagochi
{
    public class PersonalGucci : Tamagucci
    {

        private Random generator = new Random();
        //Tamagochi börjar med 0 xp.
        int xp = 0;
        //Tamagochi är level 1. 
        int level = 1;

        Weapon w;



        //En random generator bestämmer hur mycket xp tamagochin får, mellan 1-4. 
        public void LevelUp()
        {
            int x = generator.Next(1, 4);

            //xp är += x.
            xp += x;
            //Tamagochin's level är 1 i början. När Tamagochin får 10 xp så ökar level med 1. xp delas med 10, och det är en int, så det finns endast hela tal. om xp är 9, så blir talet 0, men om det blir 10 eller över så blir talet 1. 
            level = 1 + xp / 10;


            if (w == null && level == 5)
            {

                w = new RandomWeapon();
                Console.WriteLine($"Your Tamagucci is now level 5. It has therefore equipped a weapon. It's weapon is: {w.name}. ");
            }

        }
        //Printar ut tamagochin's level. 
        public void PrintLevel()
        {


            int l = level;



            Console.WriteLine($"Level: {level}");

        }


    }
}