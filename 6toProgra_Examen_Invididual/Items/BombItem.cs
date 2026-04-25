using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6toProgra_Examen_Invididual.Characters;

namespace _6toProgra_Examen_Invididual.Items
{
    public class BombItem : Item
    {
        public int BombDamage { get; private set; }

        public BombItem(int bombDamage) : base("bomb", "Bomb", "Inflige daño directo al enemigo.")
        {
            BombDamage = bombDamage;
        }

        public override void Use(Player player, Enemy enemy = null)
        {
            if (enemy != null)
            {
                enemy.TakeDamage(BombDamage);
                player.RemoveItem(this);
            }
        }
    }
}