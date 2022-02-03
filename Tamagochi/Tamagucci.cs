using System.Security.Cryptography;
using System.Collections.Generic;
using System;

namespace Tamagochi
{
    public class Tamagucci
    {


        private int hunger = 0;

        private int boredom = 0;




        private List<string> words = new List<string>() { "Hello" };

        private bool isAlive = true;

        private Random generator = new Random();

        public string name = "";
        public Tamagucci()
        {


            Console.WriteLine("Name your Tamagochi: ");

            name = Console.ReadLine();

            Console.WriteLine($"Your tamagochi's name is now {name}");

        }
        public void Feed()
        {
            int t = generator.Next(1, 5);


            hunger -= t;
            Tick();


        }

        public void Hi()
        {

            int i = generator.Next(words.Count);

            Console.WriteLine(words[i]);


            ReduceBoredom();
            Tick();

        }

        public void Teach(string word)
        {
            words.Add(word);

            ReduceBoredom();
            Tick();
        }





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


        public void PrintStats()
        {

            int y = hunger;
            int u = boredom;


            Console.WriteLine($"Hunger: {hunger}");
            Console.WriteLine($"Boredom: {boredom}");

        }

        public bool GetAlive()
        {
            return isAlive;
        }

        private void ReduceBoredom()
        {
            int b = generator.Next(1, 5);


            boredom -= b;
            Tick();

        }



      
    }
}