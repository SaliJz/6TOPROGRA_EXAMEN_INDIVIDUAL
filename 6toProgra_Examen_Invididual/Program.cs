using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6toProgra_Examen_Invididual
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool playAgain = true;

            while (playAgain)
            {
                Game game = new Game();
                game.Run();

                Console.WriteLine();
                Console.Write("¿Deseas volver a intentarlo? (y/n): ");
                string input = Console.ReadLine();

                playAgain = !string.IsNullOrWhiteSpace(input) &&
                            input.Trim().Equals("y", StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}