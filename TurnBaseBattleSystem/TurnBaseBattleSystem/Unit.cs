using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBaseBattleSystem
{
    internal class Unit
    {
        public int CurrentHp { get; set; }
        public int MaxHp { get; set; }
        public int AttackPower { get; set; }
        public int HealPower { get; set; }
        public string UnitName { get; set; }

        private Random random = new Random();

        public Unit(int maxHp, int attackPower, int healPower, string unitName)
        {
            this.CurrentHp = maxHp;
            this.MaxHp = maxHp;
            this.AttackPower = attackPower;
            this.HealPower = healPower;
            this.UnitName = unitName;
        }

        public void Attack(Unit unitToAttack)
        {
            double rng = random.NextDouble();
            rng = rng / 2 + 0.75f;
            int randDamage = (int)(this.AttackPower * rng);
            unitToAttack.TakeDamage(randDamage);
            Console.WriteLine(this.UnitName + " attacks " + unitToAttack.UnitName + " and deals " + randDamage + " damage!");
        }

        public void TakeDamage(int damage)
        {
            CurrentHp -= damage;
        }

        public void Heal()
        {
            double rng = random.NextDouble();
            rng = rng / 2 + 0.75f;
            int heal = (int)(rng * HealPower);
            this.CurrentHp = this.CurrentHp > this.MaxHp ? this.MaxHp : (this.CurrentHp + heal > 100 ? 100 : this.CurrentHp + heal);
            Console.WriteLine(this.UnitName + " healed. Current " + this.UnitName + "'s HP is " + this.CurrentHp +".");
        }
    }
}
