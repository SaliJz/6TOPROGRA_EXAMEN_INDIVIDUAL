using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6toProgra_Examen_Invididual.Situations
{
    public abstract class Situation
    {
        public string Id { get; protected set; }
        public string Title { get; protected set; }
        public string Narrative { get; protected set; }
        public List<SituationOption> Options { get; protected set; }

        protected Situation(string id, string title, string narrative)
        {
            Id = id;
            Title = title;
            Narrative = narrative;
            Options = new List<SituationOption>();
        }

        public virtual void Play(GameContext context)
        {
            Console.WriteLine(Narrative);
            Console.WriteLine();

            List<SituationOption> availableOptions = Options.FindAll(o => o.CanBeUsed(context));

            for (int i = 0; i < availableOptions.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, availableOptions[i].Description);
            }
        }
    }
}