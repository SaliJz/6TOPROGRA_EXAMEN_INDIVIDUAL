using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6toProgra_Examen_Invididual.Characters;
using _6toProgra_Examen_Invididual.Items;

namespace _6toProgra_Examen_Invididual.Combat
{
    public class CombatEngine
    {
        public bool StartBattle(Player player, Enemy enemy)
        {
            Console.WriteLine("¡Comienza el combate contra {0}!", enemy.Name);

            while (player.IsAlive && enemy.IsAlive)
            {
                Console.WriteLine();
                Console.WriteLine("{0} - HP: {1}/{2} | DMG: {3}", player.Name, player.Health, player.MaxHealth, player.Damage);
                Console.WriteLine("{0} - HP: {1}/{2} | DMG: {3}", enemy.Name, enemy.Health, enemy.MaxHealth, enemy.Damage);
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Use item");

                if (enemy.IsAlive)
                {
                    player.TakeDamage(enemy.Damage);
                    Console.WriteLine("{0} te ataca y causa {1} de daño.", enemy.Name, enemy.Damage);
                }
            }

            return player.IsAlive;
        }
    }
}