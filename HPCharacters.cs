using System;

namespace Learn_C_
{
    public class HealthCharacter : Character
    {
        public int hp { get; protected set; }
        public override bool isAlive
        {
            get
            {
                return this.hp > 0;
            }
        }
        public override void Attack(Character character)
        {
            if (character.ThrowDice() <= this.ThrowDice())
            {
                character.TakeDamage(this.LanceDe(25));
            }
        }
        public override void TakeDamage(int damage)
        {
            this.hp -= damage;
        }
        protected int LanceDe(int DiceFaces)
        {
            return this.dice.ThrowDice(DiceFaces);
        }
    }

    public class Player : HealthCharacter
    {
        public Player(int hp)
        {
            this.hp = hp;
        }

        public bool Shield()
        {
            return this.ThrowDice() <= 2;
        }

        public override void TakeDamage(int damage)
        {
            if (!this.Shield())
            {
                base.TakeDamage(damage);
            }
            else
            {
                Console.WriteLine("Your magical shield protected you!");
            }
        }
    }
    public class Boss : HealthCharacter
    {
        public Boss(int hp)
        {
            this.hp = hp;
        }
        public override void TakeDamage(int damage)
        {
            if (damage > 0)
            {
                base.TakeDamage(damage);
                Console.WriteLine($"Boss took {damage} damage! Remaining HP: {this.hp}");

            }
        }
    }

}