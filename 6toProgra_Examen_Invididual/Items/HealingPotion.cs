using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6toProgra_Examen_Invididual.Characters;


namespace _6toProgra_Examen_Invididual.Items
{
    public class HealingPotion : Item
    {
        public int HealAmount { get; private set; }

        public HealingPotion(int healAmount) : base("healing_potion", "Healing Potion", "Recupera vida.")
        {
            HealAmount = healAmount;
        }

        public override void Use(Player player, Enemy enemy = null)
        {
            player.Heal(HealAmount);
            player.RemoveItem(this);
        }
    }
}