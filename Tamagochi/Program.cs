using System.Collections.Generic;
using System.Linq;
using System;

namespace Tamagochi
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tamagucci> tamaguccis = new List<Tamagucci>();

            tamaguccis.Add(new Tamagucci());
            Player player = new Player();
            PersonalGucci pgucci = new PersonalGucci();

            string answer = "";




            int i = 0;


            //Menas isAlive är sant så spelas loopen om och om igen.
            while (tamaguccis[i].GetAlive() == true)
            {
                //Mäter tiden från när loopen börjar/börjar om igen.
                DateTime start = DateTime.Now;
                //Spelaren får välja vad dem vill göra.
                Console.WriteLine($"Do you want to 1. Teach {tamaguccis[i].name} a new word? 2. Say hi to {tamaguccis[i].name}? 3. Feed {tamaguccis[i].name}? 4. Do nothing?  5. Make a new tomagotchi? 6. Switch your tamagotchi? 7. Work and earn money? 8. Check {tamaguccis[i].name}'s level?");

                answer = Console.ReadLine();

                if (answer == "1")
                {

                    //Om spelaren har mindre money än 1, så kan man inte avsluta den action som man vill.
                    if (player.HasMoneyLeft() == true)
                    {




                        Console.WriteLine($"What new word would you like to teach {tamaguccis[i].name}?");

                        string w = Console.ReadLine();

                        tamaguccis[i].Teach(w);
                    }
                    else
                    {
                        Console.WriteLine("You have no money to do that task. You need to work to get money");
                    }

                }
                else if (answer == "2")
                {

                    if (player.HasMoneyLeft() == true)
                    {

                        Console.WriteLine($"You said hi to {tamaguccis[i].name}. {tamaguccis[i].name} says: ");

                        tamaguccis[i].Hi();

                    }
                    else
                    {
                        Console.WriteLine("You have no money to do that task. You need to work to get money");
                    }

                }
                else if (answer == "3")
                {
                    if (player.HasMoneyLeft() == true)
                    {

                        tamaguccis[i].Feed();

                        Console.WriteLine($"You fed {tamaguccis[i].name}. ");
                    }
                    else
                    {
                        Console.WriteLine("You have no money to do that task. You need to work to get money");
                    }

                }
                else if (answer == "4")
                {

                    tamaguccis[i].Tick();

                    Console.WriteLine("You did...nothing");

                }
                else if (answer == "5")
                {
                    if (player.HasMoneyLeft() == true)
                    {
                        tamaguccis.Add(new Tamagucci());
                    }
                    else
                    {
                        Console.WriteLine("You have no money to do that task. You need to work to get money");
                    }
                }

                else if (answer == "6")
                {
                    Console.WriteLine("Write down the name of the tamagothi you want to choose.");

                    //Spelaren skriver ner namnet på Tamagothcin som dem vill spela med. Om validAnswer, alltså namnet dem skriver passar med en av tamagotchin i listan, så byts tamagotchin ut.
                    string choice = Console.ReadLine();
                    bool validAnswer = tamaguccis.Any(t => t.name == choice);


                    //Om svaret inte passar en Tamagotchi, så svarar programmet med att den inte finns, och man måste skriva om.
                    i = tamaguccis.FindIndex(0, t => t.name == choice);
                    if (validAnswer == false)
                    {
                        Console.WriteLine("That is not a Tamagothi.");

                    }
                }
                else if (answer == "7")
                {
                    player.Money();
                    player.CheckMoney();
                }
                else if (answer == "8")
                {
                    if (player.HasMoneyLeft() == true)
                        pgucci.PrintLevel();
                }
                else
                {
                    Console.WriteLine("You have no money to do that task. You need to work to get money");
                }

                //Bytder den nuvarande tiden till tiden då man har avslutat en action.
                DateTime end = DateTime.Now;
                //Mäter tiden mellan när man avslutat sin senaste action med en ny action.
                TimeSpan span = end - start;

                //Mäter timespan seconds. Om det är delbart med 10, så läggs en extra tick till. Om det är mellan 10-19, så blir det en extra tick, och mellan 20-29 så blir det 2 extra ticks, osv. Detta är pga att det är en int.
                for (int h = 0; h < span.Seconds / 10; h++)
                {
                    tamaguccis[h].Tick();

                }

                pgucci.LevelUp();



                //Startar om loopen och clearar all text.
                Console.WriteLine("Press Enter to continue");

                Console.ReadLine();

                Console.Clear();




            }
            //Om isAlive är false så avslutas loopen och samtidigt programmet.
            Console.WriteLine($"{tamaguccis[i].name} has unfortunetly died. Better luck next time.");
            Console.WriteLine("Press Enter to quit");
            Console.ReadLine();

        }
    }
}
