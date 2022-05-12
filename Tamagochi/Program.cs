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
            //Hela denna klassmetod gör allting i mitt spel, mer eller mindre. Detta är ett stort problem, eftersom det är mer effektivt och stabilt om klassmetoder gör endast en enstaka uppgift. Programmet skulle kunna förbättras genom att skriva om koden i Program.cs, och skapa flera olika klassmetoder som gör samma jobb som hela klassmetoder under
            while (tamaguccis[i].GetAlive() == true)
            {
                //Mäter tiden från när loopen börjar/börjar om igen. Implimenterar tid som en faktor i detta spel.
                DateTime start = DateTime.Now;
                //Hela denna klassmetod baseras på dessa val, då spelares kan bestämma vad deras Tamagutchi gör.
                Console.WriteLine($"Do you want to 1. Teach {tamaguccis[i].name} a new word? 2. Say hi to {tamaguccis[i].name}? 3. Feed {tamaguccis[i].name}? 4. Do nothing?  5. Make a new tomagotchi? 6. Switch your tamagotchi? 7. Work and earn money? 8. Check {tamaguccis[i].name}'s level?");

                answer = Console.ReadLine();

                if (answer == "1")
                {

                    //Om spelaren har mindre money än 1, så kan man inte avsluta den action som man vill.
                    if (player.HasMoneyLeft() == true)
                    {



                        //Lär ut en tamagochi en string som läggs in i en list.
                        Console.WriteLine($"What new word would you like to teach {tamaguccis[i].name}?");

                        string w = Console.ReadLine();

                        tamaguccis[i].Teach(w);

                        player.PayMoney();
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
                        //Säger hej till tamagochin, och tamagochin tar ut en string från listan och svarar med det ordet. Om den inte lärt sig ett ord, så blir det "Hello".
                        Console.WriteLine($"You said hi to {tamaguccis[i].name}. {tamaguccis[i].name} says: ");

                        tamaguccis[i].Hi();

                        player.PayMoney();

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
                        //Höher tamagochin's feed-meter.
                        tamaguccis[i].Feed();

                        Console.WriteLine($"You fed {tamaguccis[i].name}. ");
                        player.PayMoney();
                    }
                    else
                    {
                        Console.WriteLine("You have no money to do that task. You need to work to get money");
                    }

                }
                else if (answer == "4")
                {
                    //Inget händer. 
                    tamaguccis[i].Tick();

                    Console.WriteLine("You did...nothing");
                    //Gör så att spelaren kan skapa en ny tamagochi, och lägger den i en list.
                }
                else if (answer == "5")
                {
                    if (player.HasMoneyLeft() == true)
                    {
                        tamaguccis.Add(new Tamagucci());
                        player.PayMoney();
                    }
                    else
                    {
                        Console.WriteLine("You have no money to do that task. You need to work to get money");
                    }
                }

                else if (answer == "6")
                {
                    Console.WriteLine("Write down the name of the tamagothi you want to choose.");

                    //Spelaren skriver ner namnet på Tamagochin som dem vill spela med. Om svaret är validAnswer, alltså namnet dem skriver passar med en av tamagotchin i listan, så byts tamagotchin ut.
                    string choice = Console.ReadLine();
                    bool validAnswer = tamaguccis.Any(t => t.name == choice);


                    //En for-loop som kollar om svaret inte passar en Tamagotchi, så svarar programmet med att den inte finns, och man måste skriva om.

                    if (validAnswer == true)
                    {
                        i = tamaguccis.FindIndex(0, t => t.name == choice);

                    }
                    else
                    {
                        Console.WriteLine("That is not a Tamagothi.");
                    }
                }
                else if (answer == "7")
                {
                    //Kollar spelarens pengar.
                    player.Money();
                    player.CheckMoney();
                }
                else if (answer == "8")
                {
                    if (player.HasMoneyLeft() == true)
                    {
                        //Kollar ens tamagochis level.
                        pgucci.PrintLevel();
                        player.PayMoney();
                    }
                    else
                    {
                        Console.WriteLine("You have no money to do that task. You need to work to get money");
                    }
                }
                else
                {
                    Console.WriteLine("That is not a valid answer. Please press one of the required numbers.");
                }




                //Byter den nuvarande tiden till tiden då man har avslutat en action. Använder funktionen datetime.
                DateTime end = DateTime.Now;
                //Mäter tiden mellan när man avslutat sin senaste action med en ny action.
                TimeSpan span = end - start;

                //Mäter timespan seconds. Om det är delbart med 10, så läggs en extra tick till. Om det är mellan 10-19, så blir det en extra tick, och mellan 20-29 så blir det 2 extra ticks, osv. Detta är pga att det är en int.
                for (int h = 0; h < span.Seconds / 10; h++)
                {
                    tamaguccis[i].Tick();

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
