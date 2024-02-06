using System;
using System.Xml.Linq;
namespace interactiveStory
{
    class versionOne
    {
        static void Main(string[] args)
        {
            int health = 0, loot = 0, door = 0, rooms = 0;
            Random r = new Random();
            bool win = false;
            Console.WriteLine("You are walking through a cave trying to aquire loot.");
            Console.WriteLine("What is the name of your character? ");
            string name = Console.ReadLine();
            initValues(ref health, ref loot, r);
            while (health > 0 && win==false)
            {
                door = chooseDoor();
                if(door == 1)
                    actions(r.Next(4), ref health, ref loot);
                else if(door == 2)
                    actions(r.Next(4), ref health, ref loot);
                else
                    actions(r.Next(4), ref health, ref loot);
                checkResults(ref rooms, ref loot, ref health, ref win);
            }
            if (win)
                Console.WriteLine("You collected enough loot and exited the cave!");
            else if (health <= 0)
                Console.WriteLine("You ran out of health and did not collect enough loot.");
        }

        private static void checkResults(ref int rooms, ref int loot, ref int health, ref bool win)
        {
            rooms += 1;
            Console.WriteLine("_____________ Rooms Cleared " + rooms + " ______________");
            Console.WriteLine("Health: " + health + " Loot: " + loot);
            if (loot >= 150)
                win = true;
        }

        private static void actions(int v, ref int health, ref int loot)
        {
            switch(v)
            {
                case 0:
                    Console.WriteLine("You stumbled into a camp of goblins and had to fight your way out.");
                    Console.WriteLine("You lost 2 health but gained 10 loot.");
                    health -= 2;
                    loot += 10;
                    break;
                case 1:
                    Console.WriteLine("You fell into a pit trap and had to climb out.");
                    Console.WriteLine("You lost 1 health.");
                    health -= 1; 
                    break;
                case 2:
                    Console.WriteLine("You found a chest in the room.");
                    Console.WriteLine("You gained 20 loot.");
                    loot += 20;
                    break;
                case 3:
                    Console.WriteLine("You found a pot in the coner and smashed it. You found gold!");
                    Console.WriteLine("You gained 10 loot.");
                    loot += 10;
                    break;
                case 4:
                    Console.WriteLine("You found a pot in the corner and smashed it. There was a snake!");
                    Console.WriteLine("You lost 2 health.");
                    health -= 2;
                    break;
                case 5:
                    Console.WriteLine("You found an old pack. It has some loot and food!");
                    Console.WriteLine("You gained 3 health and 25 loot.");
                    health += 3;
                    loot += 25;
                    break;
                default:
                    Console.WriteLine("The room is empty.");
                    Console.WriteLine("Nothing happens.");
                    break;
            }
        }

        private static int chooseDoor()
        {
            Console.WriteLine("You see three doors in the room, what door do you enter 1, 2 or 3?");
            int door = int.Parse(Console.ReadLine());

            while(door != 1 && door != 2 && door != 3)
            {
                Console.WriteLine("You entered an invalid number, please enter a 1, 2, or 3");
                door = int.Parse(Console.ReadLine());
            }
            return door;
        }

        private static void initValues(ref int health, ref int loot, Random r)
        {
            health = r.Next(10) + 1;
            return;
        }
    }
}