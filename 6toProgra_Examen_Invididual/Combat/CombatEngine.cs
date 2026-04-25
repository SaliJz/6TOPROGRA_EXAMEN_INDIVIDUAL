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

                int choice = ConsoleHelper.ReadOption(1, 2);

                if (choice == 1)
                {
                    enemy.TakeDamage(player.Damage);
                    Console.WriteLine("Atacas a {0} y causas {1} de daño.", enemy.Name, player.Damage);
                }
                else
                {
                    UseInventoryItem(player, enemy);
                }

                if (enemy.IsAlive)
                {
                    player.TakeDamage(enemy.Damage);
                    Console.WriteLine("{0} te ataca y causa {1} de daño.", enemy.Name, enemy.Damage);
                }
            }

            return player.IsAlive;
        }

        private void UseInventoryItem(Player player, Enemy enemy)
        {
            if (!player.Inventory.Any())
            {
                Console.WriteLine("No tienes ítems. Pierdes el turno.");
                return;
            }

            for (int i = 0; i < player.Inventory.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, player.Inventory[i].Name);
            }

            int option = ConsoleHelper.ReadOption(1, player.Inventory.Count);
            Item item = player.Inventory[option - 1];
            item.Use(player, enemy);
            Console.WriteLine("Usaste: " + item.Name);
        }
    }
}