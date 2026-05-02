using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6toProgra_Examen_Invididual.Characters;
using _6toProgra_Examen_Invididual.Endings;
using _6toProgra_Examen_Invididual.Items;
using _6toProgra_Examen_Invididual.Situations;

namespace _6toProgra_Examen_Invididual
{
    public class Game
    {
        private GameContext context;

        public void Run()
        {
            Console.Clear();
            Console.WriteLine("====================");
            Console.WriteLine("  LA ÚLTIMA PUERTA  ");
            Console.WriteLine("====================");
            Console.Write("Ingresa tu nombre: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name)) name = "Aventurero";

            Player player = new Player(name.Trim());
            context = new GameContext(player);

            LoadSituations();

            context.CurrentSituationId = "intro_crossroads";

            while (context.CurrentSituationId != null && !context.GameOver)
            {
                if (!context.SituationsById.ContainsKey(context.CurrentSituationId)) break;

                Situation current = context.SituationsById[context.CurrentSituationId];
                current.Play(context);

                if (!player.IsAlive)
                {
                    context.GameOver = true;
                }
            }

            ShowEnding();
        }

        private void ShowEnding()
        {
            Console.WriteLine();
            ConsoleHelper.WriteSectionTitle("\nFIN DE LA AVENTURA");
            EndingResolver resolver = new EndingResolver();
            Console.WriteLine(resolver.Resolve(context));
            Console.WriteLine();
        }

        private void LoadSituations()
        {
            List<Situation> all = new List<Situation>
            {
                BuildIntroCrossroads(),
                BuildOldManRequest(),
                BuildRiverChest(),
                BuildWolfAmbush(),
                BuildRuinedShrine(),
                BuildTravelerTrade(),
                BuildBanditBridge(),
                BuildDarkCave(),
                BuildGuardianKnight(),
                BuildAncientGate()
            };

            foreach (Situation s in all)
            {
                context.SituationsById.Add(s.Id, s);
            }
        }

        private Situation BuildIntroCrossroads()
        {
            StorySituation s = new StorySituation(
                id: "intro_crossroads",
                title: "El Cruce del Bosque",
                narrative:
                    "Despiertas en el borde de un bosque oscuro. Ante ti hay dos caminos:\n" +
                    "uno lleva hacia unas ruinas iluminadas por antorchas,\n" +
                    "el otro desciende hacia un río que brilla bajo la luna."
            );

            s.Options.Add(new SituationOption
            {
                Description = "Ir hacia las ruinas",
                Consequence = ctx =>
                {
                    //ctx.Player.Courage++;
                    Console.WriteLine("Avanzas con determinación hacia las ruinas.");
                },
                NextSituationId = "old_man_request"
            });

            s.Options.Add(new SituationOption
            {
                Description = "Ir hacia el río con cautela",
                Consequence = ctx =>
                {
                    ctx.Player.Morality++;
                    Console.WriteLine("Eliges el camino más seguro. La prudencia también es valentía.");
                },
                NextSituationId = "river_chest"
            });

            return s;
        }

        private Situation BuildOldManRequest()
        {
            EventSituation s = new EventSituation(
                id: "old_man_request",
                title: "El Anciano del Camino",
                narrative:
                    "Un anciano sentado junto a la hoguera te pide un poco de agua y provisiones."
            );

            s.Options.Add(new SituationOption
            {
                Description = "Ayudarle y compartir lo poco que tienes",
                Consequence = ctx =>
                {
                    ctx.Player.Morality += 2;
                    ctx.Player.SetFlag("helped_old_man", 1);
                    ctx.Player.AddItem(new HealingPotion(25));
                    Console.WriteLine("El anciano sonríe y te entrega una poción de vida como agradecimiento.");
                },
                NextSituationId = "wolf_ambush"
            });

            s.Options.Add(new SituationOption
            {
                Description = "Ignorarle y seguir tu camino",
                Consequence = ctx =>
                {
                    ctx.Player.Morality--;
                    Console.WriteLine("Pasas de largo. Algo te dice que tomaste la decisión equivocada.");
                },
                NextSituationId = "wolf_ambush"
            });

            return s;
        }

        private Situation BuildRiverChest()
        {
            EventSituation s = new EventSituation(
                id: "river_chest",
                title: "El Cofre a Orillas del Río",
                narrative:
                    "Encuentras un cofre semisumergido junto al río. Podría contener algo valioso... o una trampa."
            );

            s.Options.Add(new SituationOption
            {
                Description = "Abrir el cofre",
                Consequence = ctx =>
                {
                    ctx.Player.AddItem(new DamagePotion(8));
                    Console.WriteLine("Dentro encuentras una poción que incrementa tu fuerza. ¡Buena suerte!");
                },
                NextSituationId = "wolf_ambush"
            });

            s.Options.Add(new SituationOption
            {
                Description = "Dejarlo y continuar (la prudencia te protege)",
                Consequence = ctx =>
                {
                    ctx.Player.Morality++;
                    Console.WriteLine("Decides no arriesgarte. Sabio consejo en tierras desconocidas.");
                },
                NextSituationId = "wolf_ambush"
            });

            return s;
        }

        private Situation BuildWolfAmbush()
        {
            Enemy wolf = new Enemy("Lobo Sombrío", 40, 8);
            wolf.LootTable.Add(new HealingPotion(15));

            CombatSituation s = new CombatSituation(
                id: "wolf_ambush",
                title: "Emboscada en el Claro",
                narrative:
                    "Un lobo de pelaje oscuro salta desde los arbustos. Sus ojos brillan con furia.",
                enemy: wolf
            );

            s.Options.Add(new SituationOption
            {
                Description = "Continuar hacia el santuario",
                Consequence = _ => { },
                NextSituationId = "ruined_shrine"
            });

            return s;
        }

        private Situation BuildRuinedShrine()
        {
            EventSituation s = new EventSituation(
                id: "ruined_shrine",
                title: "El Santuario en Ruinas",
                narrative:
                    "Encuentras un antiguo altar con una reliquia que emite una tenue luz dorada.\n" +
                    "Una inscripción advierte: «Solo el digno la tome»."
            );

            s.Options.Add(new SituationOption
            {
                Description = "Tomar la reliquia",
                Consequence = ctx =>
                {
                    ctx.Player.AddItem(new RelicItem(40));
                    Console.WriteLine("La reliquia resplandece en tu mano. Sientes un poder antiguo.");
                },
                NextSituationId = "traveler_trade"
            });

            s.Options.Add(new SituationOption
            {
                Description = "Respetar el altar y continuar",
                Consequence = ctx =>
                {
                    ctx.Player.Morality += 2;
                    ctx.Player.Heal(20);
                    Console.WriteLine("Al retirarte con respeto, el altar emite un brillo cálido y tu vida se restaura.");
                },
                NextSituationId = "traveler_trade"
            });

            return s;
        }

        private Situation BuildTravelerTrade()
        {
            EventSituation s = new EventSituation(
                id: "traveler_trade",
                title: "El Viajero Misterioso",
                narrative:
                    "Un viajero con capa oscura te ofrece un trato: cambiar un ítem de tu bolsa\n" +
                    "por una bomba de gran poder, o simplemente ignorarlo."
            );

            s.Options.Add(new SituationOption
            {
                Description = "Aceptar el trato (entregar una poción de vida a cambio)",
                IsAvailable = ctx => ctx.Player.HasItem("healing_potion"),
                Consequence = ctx =>
                {
                    Item potion = ctx.Player.Inventory.Find(i => i.Id == "healing_potion");
                    if (potion != null) ctx.Player.RemoveItem(potion);
                    ctx.Player.AddItem(new BombItem(50));
                    Console.WriteLine("El viajero sonríe y te entrega una poderosa bomba.");
                },
                NextSituationId = "bandit_bridge"
            });

            s.Options.Add(new SituationOption
            {
                Description = "Rechazar el trato",
                Consequence = ctx =>
                {
                    ctx.Player.Morality++;
                    Console.WriteLine("El viajero encoge hombros y desaparece entre las sombras.");
                },
                NextSituationId = "bandit_bridge"
            });

            return s;
        }

        private Situation BuildBanditBridge()
        {
            Enemy bandit = new Enemy("Bandido del Puente", 55, 10);
            bandit.LootTable.Add(new DamagePotion(5));

            CombatSituation s = new CombatSituation(
                id: "bandit_bridge",
                title: "El Puente Bloqueado",
                narrative:
                    "Un bandido bloquea el único puente. No parece tener intenciones de moverse.",
                enemy: bandit
            );

            s.Options.Add(new SituationOption
            {
                Description = "Cruzar el puente y continuar",
                Consequence = _ => { },
                NextSituationId = "dark_cave"
            });

            return s;
        }

        private Situation BuildDarkCave()
        {
            EventSituation s = new EventSituation(
                id: "dark_cave",
                title: "La Cueva Oscura",
                narrative:
                    "Frente a ti hay una cueva con dos entradas.\n" +
                    "De la izquierda sale un viento helado; de la derecha se escucha un murmullo suave."
            );

            s.Options.Add(new SituationOption
            {
                Description = "Entrar por la izquierda (viento helado)",
                Consequence = ctx =>
                {
                    ctx.Player.TakeDamage(15);
                    ctx.Player.AddItem(new HealingPotion(40));
                    Console.WriteLine("El frío te golpea fuerte (-15 HP), pero encuentras una gran poción de vida.");
                },
                NextSituationId = "guardian_knight"
            });

            s.Options.Add(new SituationOption
            {
                Description = "Entrar por la derecha (murmullo tranquilo)",
                Consequence = ctx =>
                {
                    ctx.Player.Heal(10);
                    //ctx.Player.Courage++;
                    Console.WriteLine("Un espíritu amistoso te guía y restaura parte de tu vida (+10 HP).");
                },
                NextSituationId = "guardian_knight"
            });

            return s;
        }

        private Situation BuildGuardianKnight()
        {
            Enemy guardian = new Enemy("Caballero Guardián", 80, 14);
            guardian.LootTable.Add(new HealingPotion(30));

            CombatSituation s = new CombatSituation(
                id: "guardian_knight",
                title: "El Guardián de la Puerta",
                narrative:
                    "Ante la gran puerta de piedra, un caballero espectral bloquea tu paso.\n" +
                    "«Solo el que demuestre su valía podrá cruzar», dice con voz de trueno.",
                enemy: guardian
            );

            s.Options.Add(new SituationOption
            {
                Description = "Avanzar hacia la puerta antigua",
                Consequence = _ => { },
                NextSituationId = "ancient_gate"
            });

            return s;
        }

        private Situation BuildAncientGate()
        {
            StorySituation s = new StorySituation(
                id: "ancient_gate",
                title: "La Puerta Antigua",
                narrative:
                    "Frente a ti se alza una enorme puerta de piedra cubierta de runas.\n" +
                    "Sientes que tus decisiones te han traído hasta aquí. ¿Cómo procedes?"
            );

            s.Options.Add(new SituationOption
            {
                Description = "Usar la reliquia para abrir la puerta con honor",
                IsAvailable = ctx => ctx.Player.GetFlagValue("has_relic") == 1,
                Consequence = ctx =>
                {
                    ctx.Player.SetFlag("used_relic_honorably", 1);
                    Console.WriteLine("La puerta se abre con una luz dorada. Sientes paz en tu corazón.");
                },
                NextSituationId = null
            });

            s.Options.Add(new SituationOption
            {
                Description = "Forzar la puerta a cualquier costo",
                Consequence = ctx =>
                {
                    ctx.Player.Morality -= 2;
                    Console.WriteLine("La puerta cede tras tu esfuerzo brutal, pero algo oscuro se despierta.");
                },
                NextSituationId = null
            });

            s.Options.Add(new SituationOption
            {
                Description = "Detenerte y reflexionar antes de decidir",
                Consequence = ctx =>
                {
                    ctx.Player.Morality++;
                    ctx.Player.Heal(10);
                    Console.WriteLine("La serenidad te otorga una última dosis de energía antes del umbral.");
                },
                NextSituationId = null
            });

            return s;
        }
    }
}