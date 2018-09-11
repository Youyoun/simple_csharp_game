namespace Learn_C_
{
    abstract public class Character
    {
        protected Dice dice;
        public Character()
        {
            this.dice = new Dice();
        }
        abstract public void Attack(Character character);
        abstract public void TakeDamage(int damage);
        public virtual int ThrowDice()
        {
            return this.dice.ThrowDice();
        }
        public virtual bool isAlive { get; protected set; }
    }
}