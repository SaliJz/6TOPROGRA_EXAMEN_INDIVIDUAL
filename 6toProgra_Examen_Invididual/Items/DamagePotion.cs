using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6toProgra_Examen_Invididual.Characters;

namespace _6toProgra_Examen_Invididual.Items
{
    public class DamagePotion : Item
    {
        public int BonusDamage { get; private set; }

        public DamagePotion(int bonusDamage) : base("damage_potion", "Damage Potion", "Incrementa el daño del jugador.")
        {
            BonusDamage = bonusDamage;
        }

        public override void Use(Player player, Enemy enemy = null)
        {
            player.IncreaseDamage(BonusDamage);
            player.RemoveItem(this);
        }
    }
}