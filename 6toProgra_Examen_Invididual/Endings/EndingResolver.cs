using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6toProgra_Examen_Invididual.Endings
{
    public class EndingResolver
    {
        public string Resolve(GameContext context)
        {
            var player = context.Player;

            if (!player.IsAlive)
            {
                return "Has caído en la oscuridad del bosque. Tu aventura termina aquí.";
            }

            bool helpedOldMan = player.GetFlagValue("helped_old_man") == 1;
            bool hasRelic = player.HasItem("ancient_relic");

            if (helpedOldMan && hasRelic && player.Morality >= 2)
            {
                return "Final bueno: restauraste el equilibrio y salvaste el reino.";
            }

            if (player.Morality >= 0)
            {
                return "Final neutral: sobreviviste, pero el misterio del portal quedó sin resolverse.";
            }

            return "Final malo: tus decisiones despertaron un mal antiguo y el reino cayó en sombras.";
        }
    }
}