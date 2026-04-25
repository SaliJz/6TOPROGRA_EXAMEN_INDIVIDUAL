using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6toProgra_Examen_Invididual.Characters
{
    public abstract class Character
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int MaxHealth { get; protected set; }
        public int Damage { get; protected set; }

        public bool IsAlive
        {
            get 
            { 
                return Health > 0; 
            }
        }

        protected Character(string name, int health, int damage)
        {
            Name = name;
            MaxHealth = health;
            Health = health;
            Damage = damage;
        }

        public virtual void TakeDamage(int amount)
        {
            if (amount < 0) amount = 0;
            Health -= amount;

            if (Health < 0)
            {
                Health = 0;
            }
        }

        public virtual void Heal(int amount)
        {
            if (amount < 0) amount = 0;
            Health += amount;

            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }

        public virtual void IncreaseDamage(int amount)
        {
            if (amount > 0)
            {
                Damage += amount;
            }
        }
    }
}