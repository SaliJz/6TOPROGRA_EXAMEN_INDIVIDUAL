using _6toProgra_Examen_Invididual.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6toProgra_Examen_Invididual.Items
{
    public class RelicItem : Item
    {
        public int RelicDamage { get; private set; }

        public RelicItem(int relicDamage) : base("ancient_relic", "Reliquia Antigua", "Un artefacto que canaliza un poder ancestral.")
        {
            RelicDamage = relicDamage;
        }

        public override void Use(Player player, Enemy enemy = null)
        {
            if (enemy != null)
            {
                enemy.TakeDamage(RelicDamage);
                Console.WriteLine("La reliquia libera su energía: {0} de daño al enemigo.", RelicDamage);
            }
            else
            {
                Console.WriteLine("La reliquia brilla, pero no hay enemigo aquí.");
            }

            player.RemoveItem(this);
        }
    }
}