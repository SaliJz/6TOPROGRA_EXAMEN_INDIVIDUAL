using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6toProgra_Examen_Invididual
{
    public static class ConsoleHelper
    {
        public static int ReadOption(int min, int max)
        {
            while (true)
            {
                Console.Write("Selecciona una opción: ");
                string input = Console.ReadLine();
                int value;

                if (int.TryParse(input, out value) && value >= min && value <= max)
                {
                    return value;
                }

                Console.WriteLine("Entrada inválida. Intenta nuevamente.");
            }
        }

        public static void WriteSectionTitle(string title)
        {
            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine(title);
            Console.WriteLine("========================================");
        }
    }
}