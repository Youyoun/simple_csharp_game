using System;

namespace Learn_C_
{
    class Program
    {
        static Character getMonster()
        {
            Random random = new Random();
            int monsterType = random.Next(2);
            if (monsterType == 0)
            {
                Console.WriteLine("Easy Monster Ahead");
                return new EasyMonster();
            }
            else if (monsterType == 1)
            {
                Console.WriteLine("Hard Monster Ahead");
                return new HardMonster();
            }
            else
            {
                Console.WriteLine("Monster type unknown.");
                throw new ApplicationException();
            }
        }
        static void Main(string[] args)
        {
            int score = 0;
            int monsterNumber = 1;
            Console.WriteLine("Game started !");
            Player newHero = new Player(150);
            while (newHero.isAlive && monsterNumber <= 10)
            {
                Console.WriteLine($"Engaging monster number {monsterNumber}");
                Character monster = getMonster();
                while (monster.isAlive)
                {
                    newHero.Attack(monster);
                    if (monster.isAlive) {
                        Console.WriteLine("Hero missed!");
                        monster.Attack(newHero);
                    }
                    if (!newHero.isAlive) {
                        break;
                    }
                }
                if (monster is HardMonster)
                {
                    score += 2;
                }
                else
                {
                    score += 1;
                }
                monsterNumber += 1;
                Console.WriteLine($"Your hero successfully killed the monster! Current HP: {newHero.hp}");
            }
            if (newHero.isAlive) {
                Console.WriteLine("Good job on getting here. Your Hero will now fight the Boss.");
                Character boss = new Boss(250);
                while (boss.isAlive && newHero.isAlive) {
                    newHero.Attack(boss);
                    if (!boss.isAlive) {
                        Console.WriteLine("Your Hero Vanguished the Boss!");
                        score += 10;
                        break;
                    }
                    boss.Attack(newHero);
                    Console.WriteLine($"Hero HP: {newHero.hp}");
                }
            }
            Console.WriteLine($"Game Ended ! Your hero scored: {score}");
        }
    }
}