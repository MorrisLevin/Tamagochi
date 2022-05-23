using System.Threading;
using System.Security.Cryptography;
using System.Collections.Generic;
using System;

namespace Tamagochi
{
    public class Tamagucci
    {

        //Hungern/Boredom av ens Tamagochi.
        private int hunger = 0;

        private int boredom = 0;

        //Tamagochi börjar med 0 xp.
        int xp = 0;
        //Tamagochi är level 1. 
        int level = 1;

        public Weapon w;

        public Shovel s;



        //Lista av lärda utlärda ord som Tamagochin kan. Börjar med bara 
        private List<string> words = new List<string>() { "Hello" };

        private List<string> treasures = new List<string>() { "Crown", "Book", "Message in a bottle", "Coin", "Necklace" };

        //Tamagichi lever
        private bool isAlive = true;

        private Random generator = new Random();

        public string name = "";
        public Tamagucci()
        {
            //Ge din tamagochi ett namn.

            Console.WriteLine("Name your Tamagochi: ");

            name = Console.ReadLine();

            Console.WriteLine($"Your tamagochi's name is now {name}");

        }
        //Mata din tamagochi.
        public void Feed()
        {
            int t = generator.Next(1, 5);


            hunger -= t;


        }
        //Tamagochi säger ett av orden som den lärt sig, samt så blir dess boredom lägre.
        public void Hi()
        {

            int i = generator.Next(words.Count);

            Console.WriteLine(words[i]);


            ReduceBoredom();

        }
        //Tamagochi lär sig ett nytt ord som spelaren skriver, samt så blir dess boredom lägre.
        public void Teach(string word)
        {
            words.Add(word);

            ReduceBoredom();

        }




        //Ger spelaren mer hunger och boredom, och om dessa värden går över 10 så dör tamagochin.
        public void Tick()
        {

            int r = generator.Next(1, 3);
            int t = generator.Next(1, 3);

            boredom += r;
            hunger += t;

            if (boredom == 10)
            {
                isAlive = false;
            }
            else if (hunger == 10)
            {
                isAlive = false;
            }

        }

        //Printar tamagochins hunger och boredom för spelaren.
        public void PrintStats()
        {

            int y = hunger;
            int u = boredom;


            Console.WriteLine($"Hunger: {hunger}");
            Console.WriteLine($"Boredom: {boredom}");

        }
        //Ser till att tamagochin inte är död än.
        public bool GetAlive()
        {
            return isAlive;
        }
        //Tar bort boredom.
        private void ReduceBoredom()
        {
            int b = generator.Next(1, 5);


            boredom -= b;

        }




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

            if (s == null && level == 10)
            {

                s = new Shovel();
                Console.WriteLine($"Your Tamagucci is now level 10. It has therefore equipped a Shovel. Use the shovel to find treasures. ");
            }



        }
        //Printar ut tamagochin's level. 
        public void PrintLevel()
        {


            int l = level;



            Console.WriteLine($"Level: {level}");

        }


        public void Dig()
        {

            int t = generator.Next(treasures.Count);

            Console.WriteLine("Your Tamagotchi tried digging a bit, and it found a:");

            Console.WriteLine(treasures[t]);

        }


    }
}