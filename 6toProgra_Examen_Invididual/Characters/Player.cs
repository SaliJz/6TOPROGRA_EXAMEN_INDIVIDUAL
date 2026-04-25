using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6toProgra_Examen_Invididual.Items;

namespace _6toProgra_Examen_Invididual.Characters
{
    public class Player : Character
    {
        public List<Item> Inventory { get; private set; }
        public Dictionary<string, int> Flags { get; private set; }
        public Stack<string> ChoiceHistory { get; private set; }
        public Queue<Item> RewardQueue { get; private set; }

        public int Morality { get; set; }
        public int Courage { get; set; }

        public Player(string name) : base(name, 100, 12)
        {
            Inventory = new List<Item>();
            Flags = new Dictionary<string, int>();
            ChoiceHistory = new Stack<string>();
            RewardQueue = new Queue<Item>();
            Morality = 0;
            Courage = 0;
        }

        public void AddItem(Item item)
        {
            if (item != null)
            {
                Inventory.Add(item);
            }
        }

        public bool HasItem(string itemId)
        {
            return Inventory.Any(i => i.Id == itemId);
        }

        public void RemoveItem(Item item)
        {
            if (item != null)
            {
                Inventory.Remove(item);
            }
        }

        public void SetFlag(string key, int value)
        {
            if (Flags.ContainsKey(key))
            {
                Flags[key] = value;
            }
            else
            {
                Flags.Add(key, value);
            }
        }

        public int GetFlagValue(string key)
        {
            return Flags.ContainsKey(key) ? Flags[key] : 0;
        }
    }
}