using System;

namespace Learn_C_
{
    public class Dice
    {
        private Random random;
        public Dice()
        {
            random = new Random();
        }
        public int ThrowDice(int diceFaces=6)
        {
            return random.Next(1, diceFaces+1);
        }
    }
}