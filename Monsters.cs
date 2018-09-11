using System;

namespace Learn_C_
{
    public class EasyMonster : Character
    {
        public EasyMonster()
        {
            this.isAlive = true;
        }
        public override void Attack(Character character)
        {
            Console.WriteLine("Monster Attacked!");
            if (this.ThrowDice() >= character.ThrowDice())
            {
                Console.WriteLine("Monster deals 10 damage");
                character.TakeDamage(10);
            }
            else
            {
                Console.WriteLine("Monster missed!");
            }
        }
        public override void TakeDamage(int damage)
        {
            this.isAlive = false;
        }
    }
    public class HardMonster : EasyMonster
    {
        public override void Attack(Character character)
        {
            base.Attack(character);
            int specialAttackDice = this.ThrowDice();
            if (this.ThrowDice() < 6)
            {
                Console.WriteLine($"Monster throws fireball! It deals {specialAttackDice * 5} damage.");
                character.TakeDamage(specialAttackDice * 5);
            }
        }
    }
}