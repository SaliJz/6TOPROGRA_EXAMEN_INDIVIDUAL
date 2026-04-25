using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6toProgra_Examen_Invididual.Characters;

namespace _6toProgra_Examen_Invididual.Items
{
    public interface IUsable
    {
        void Use(Player player, Enemy enemy = null);
    }

    public interface ILootable
    {
        IEnumerable<Item> GetLoot();
    }

    public abstract class Item : IUsable
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        protected Item(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public abstract void Use(Player player, Enemy enemy = null);

        public override string ToString()
        {
            return Name;
        }
    }
}