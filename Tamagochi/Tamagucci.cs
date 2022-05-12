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





        //Lista av lärda utlärda ord som Tamagochin kan. Börjar med bara 
        private List<string> words = new List<string>() { "Hello" };
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





    }
}