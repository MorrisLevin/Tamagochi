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

        public string name = "Tamagochi";

        public void Feed()
        {

            Tick();

            hunger -= 3;


        }

        public void Hi()
        {

            int i = generator.Next(words.Count);

            Console.WriteLine(words[i]);

            Tick();

            ReduceBoredom();

        }

        public void Teach(string word)
        {
            words.Add(word);
            Tick();

            ReduceBoredom();
        }

        public void Tick()
        {
            boredom += 1;
            hunger += 1;

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
            boredom -= 3;
        }




    }
}