using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6toProgra_Examen_Invididual.Situations
{
    public class SituationOption
    {
        public string Description { get; set; }
        public Action<GameContext> Consequence { get; set; }
        public Func<GameContext, bool> IsAvailable { get; set; }
        public string NextSituationId { get; set; }

        public bool CanBeUsed(GameContext context)
        {
            return IsAvailable == null || IsAvailable(context);
        }
    }
}