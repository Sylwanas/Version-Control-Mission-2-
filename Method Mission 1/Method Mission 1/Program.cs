using System;
using System.Collections.Generic;
using System.Linq;

namespace Lists_Boss_Level
{
    internal class Program
    {
        static void SimulateCombat(List<string> characters, string monsterName, int monsterHP, int savingThrowDC)
        {
            //Variables
            var random = new Random();
            int roll2D6 = 0;
            int roll1D20 = 0;

            //Damage Calculations
            while (monsterHP > 0)
            {
                foreach (var character in characters)
                {
                    for (int b = 0; b < 2; b++)
                    {
                        roll2D6 += random.Next(1, 7);
                    }
                    Console.Write(character);
                    Console.Write($" deals {roll2D6} damage!");
                    monsterHP -= roll2D6;
                    if (monsterHP <= 0)
                    {
                        monsterHP = 0;
                        Console.WriteLine($" The {monsterName} has {monsterHP} HP remaining.");
                        Console.WriteLine("\nTriomphe! The companions continue to Paris! Tous pour un, un pour tous!\n");
                        break;
                    }
                    Console.Write($" The {monsterName} has {monsterHP} HP remaining.");
                    Console.WriteLine();
                    roll2D6 = 0;
                }
                //DC Save
                roll1D20 = random.Next(1, 21);
                if (roll1D20+3 <= savingThrowDC && monsterHP > 0)
                {
                    int randomChar = random.Next(characters.Count);
                    Console.Write(characters[randomChar]);
                    Console.Write($" rolls a {roll1D20} and is turnt to mush!\n\n");
                    characters.Remove(characters[randomChar]);
                }
                else if (roll1D20 >= savingThrowDC && monsterHP > 0)
                {
                    int randomChar = random.Next(characters.Count);
                    Console.Write(characters[randomChar]);
                    Console.Write($" rolls a {roll1D20} and is not turnt to mush!\n\n");
                }
                //Everyone Dead Check
                if (characters.Count == 0)
                {
                    Console.WriteLine("All of the companions are dead! Merde!");
                    Environment.Exit(0);
                }
            }
        }
        static void Main(string[] args)
        {
            //Variables
            var characters = new List<string> { "Athos", "Porthos", "Aramis", "d'Artagnan" };

            //Flavor
            Console.Write("Companions ");
            Console.Write(string.Join(", ", characters));
            Console.WriteLine(" walk on the road to Paris.");

            //Calling
            SimulateCombat(characters, "orc", 15, 10);
            SimulateCombat(characters, "azer", 39, 18);
            SimulateCombat(characters, "troll", 84, 16);

            //Characters Alive
            if (characters.Count == 1)
            {
                Console.Write("Only ");
                Console.Write(string.Join(" ",characters));
                Console.Write(" has survived.\n");
                Environment.Exit(0);
            }
            if (characters.Count <= 1);
            {
                Console.Write(string.Join(", ", characters));
                Console.Write(" have survived!\n");
                Environment.Exit(0);
            }
        }
    }
}