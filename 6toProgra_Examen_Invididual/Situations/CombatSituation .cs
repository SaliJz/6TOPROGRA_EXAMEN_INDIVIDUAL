
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6toProgra_Examen_Invididual.Characters;

namespace _6toProgra_Examen_Invididual.Situations
{
    public class CombatSituation : Situation
    {
        private readonly Enemy enemy;

        public CombatSituation(string id, string title, string narrative, Enemy enemy)
            : base(id, title, narrative)
        {
            this.enemy = enemy;
        }

        public override void Play(GameContext context)
        {
            Console.WriteLine(Narrative);
            Console.WriteLine();

            foreach (var item in enemy.GetLoot())
            {
                context.Player.RewardQueue.Enqueue(item);
            }

            while (context.Player.RewardQueue.Count > 0)
            {
                var reward = context.Player.RewardQueue.Dequeue();
                context.Player.AddItem(reward);
                Console.WriteLine("Has obtenido: " + reward.Name);
            }

            base.Play(context);
        }
    }
}