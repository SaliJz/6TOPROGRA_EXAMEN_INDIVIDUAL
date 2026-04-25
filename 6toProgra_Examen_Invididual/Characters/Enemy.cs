using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6toProgra_Examen_Invididual.Items;

namespace _6toProgra_Examen_Invididual.Characters
{
    public class Enemy : Character, ILootable
    {
        public List<Item> LootTable { get; private set; }

        public Enemy(string name, int health, int damage) : base(name, health, damage)
        {
            LootTable = new List<Item>();
        }

        public IEnumerable<Item> GetLoot()
        {
            return LootTable;
        }
    }
}