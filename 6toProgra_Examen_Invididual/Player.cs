using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6toProgra_Examen_Invididual
{
    internal class Player
    {
        private static readonly Random rng = new Random();
        public string Name { get; private set; }
        public int MaxHP { get; private set; }
        public int CurrentHP { get; private set; }
        public int Damage { get; private set; }
        public bool IsAlive => CurrentHP > 0;

        public Player(string name, int hp, int damage)
        {
            Name = name;
            MaxHP = hp;
            CurrentHP = hp;
            Damage = damage;
        }

        public int TakeDamage(int amount)
        {
            int current = Math.Min(amount, CurrentHP);
            CurrentHP -= current;
            return current;
        }

        public int Attack()
        {
            int variation = (int)(Damage * 0.2);
            return Damage + rng.Next(-variation, variation + 1);
        }
    }
}