using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6toProgra_Examen_Invididual
{
    internal class Enemy
    {
        private static readonly Random rng = new Random();

        public string Name { get; private set; }
        public int MaxHP { get; private set; }
        public int CurrentHP { get; private set; }
        public int Damage { get; private set; }
        public string Sprite { get; private set; }
        public List<Item> LootTable { get; private set; }
        public bool IsAlive => CurrentHP > 0;

        public Enemy(string name, int hp, int damage, string sprite, List<Item> loot)
        {
            Name = name;
            MaxHP = hp;
            CurrentHP = hp;
            Damage = damage;
            Sprite = sprite;
            if (loot != null) LootTable = loot;
            else LootTable = new List<Item>();
        }

        public int TakeDamage(int amount)
        {
            int current = Math.Min(amount, CurrentHP);
            CurrentHP -= current;
            return current;
        }

        public int AttackPlayer()
        {
            int variation = (int)(Damage * 0.2);
            return Damage + rng.Next(-variation, variation + 1);
        }
    }
}