using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6toProgra_Examen_Invididual.Characters;
using _6toProgra_Examen_Invididual.Situations;

namespace _6toProgra_Examen_Invididual
{
    public class GameContext
    {
        public Player Player { get; set; }
        public Dictionary<string, Situation> SituationsById { get; private set; }
        public string CurrentSituationId { get; set; }
        public bool GameOver { get; set; }
        public bool Victory { get; set; }

        public GameContext(Player player)
        {
            Player = player;
            SituationsById = new Dictionary<string, Situation>();
        }
    }
}