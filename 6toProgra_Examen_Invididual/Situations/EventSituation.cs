using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6toProgra_Examen_Invididual.Situations
{
    public class EventSituation : Situation
    {
        public EventSituation(string id, string title, string narrative) : base(id, title, narrative)
        {

        }

        public override void Play(GameContext context)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[EVENTO]");
            Console.ResetColor();

            base.Play(context);
        }
    }
}