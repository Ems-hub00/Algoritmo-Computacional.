using System;
using System.Text;

namespace AdivinaNumero
{
    class Program
    {
        const int MIN = 1;
        const int MAX = 50;

        static void Main(string[] args)
        {
            // Para que se vean bien las tildes y la ñ
            Console.OutputEncoding = Encoding.UTF8;

            // Pedir el nombre (no se acepta vacío)
            string nombre = "";
            while (nombre == "")
            {
                Console.Write("Jugador: ");
                nombre = (Console.ReadLine() ?? "").Trim();
            }

            string nombreMayus = nombre.ToUpper();
            string inicial = nombreMayus.Substring(0, 1);
            Console.WriteLine($"Hola, {nombreMayus} (inicial: {inicial})");

            string otraVez;

            do
            {
                Jugar();

                Console.Write("¿Jugar otra vez? (s/n): ");
                otraVez = (Console.ReadLine() ?? "").Trim().ToLower();

                // while: repite la pregunta hasta que respondan s o n
                while (otraVez != "s" && otraVez != "n")
                {
                    Console.Write("Responde s o n: ");
                    otraVez = (Console.ReadLine() ?? "").Trim().ToLower();
                }

                Console.WriteLine();
            } while (otraVez == "s");

            Console.WriteLine("¡Gracias por jugar!");
        }

        // Una partida completa
        static void Jugar()
        {
            int secreto = new Random().Next(1, 51); // número entre 1 y 50
            int intentos = 0;
            int numero;

            do
            {
                numero = PedirNumero();
                intentos++;

                if (numero < secreto)
                {
                    Console.WriteLine("Más alto");
                }
                else if (numero > secreto)
                {
                    Console.WriteLine("Más bajo");
                }
            } while (numero != secreto);

            string palabra = intentos == 1 ? "intento" : "intentos";
            Console.Write($"¡Acertaste en {intentos} {palabra}! ");

            // Un * por cada intento
            for (int i = 0; i < intentos; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }

        // Pide un número y valida que esté entre 1 y 50
        static int PedirNumero()
        {
            int numero = 0;
            bool valido;

            do
            {
                Console.Write($"Número ({MIN}-{MAX}): ");
                valido = int.TryParse(Console.ReadLine(), out numero) && numero >= MIN && numero <= MAX;

                if (!valido)
                {
                    Console.WriteLine($"Entrada no válida. Escribe un número entre {MIN} y {MAX}.");
                }
            } while (!valido);

            return numero;
        }
    }
}