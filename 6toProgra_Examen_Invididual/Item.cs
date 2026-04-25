using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6toProgra_Examen_Invididual
{
    internal class Item
    {
        public enum ItemType
        {
            Potion,
            SuperPotion,
            MegaPotion
        }

        public string Name { get; private set; }
        public int HealAmount { get; private set; }
        public ItemType Type { get; private set; }
        public string Description { get; private set; }
        public string Icon { get; private set; }

        public Item(ItemType type)
        {
            Type = type;
            switch (type)
            {
                case ItemType.Potion:
                    Name = "Pocion Curativa";
                    HealAmount = 30;
                    Description = "Restaura 30 puntos de vida";
                    Icon = "[+30 HP]";
                    break;
                case ItemType.SuperPotion:
                    Name = "Pocion Super Curativa";
                    HealAmount = 60;
                    Description = "Restaura 60 puntos de vida";
                    Icon = "[+60 HP]";
                    break;
                case ItemType.MegaPotion:
                    Name = "Pocion Mega Curativa";
                    HealAmount = 100;
                    Description = "Restaura 100 puntos de vida";
                    Icon = "[+100 HP]";
                    break;
            }
        }
    }
}