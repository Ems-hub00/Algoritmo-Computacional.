using System; // esto es una libreria

class Program
{
    // aqui puse lo de clasificacion de edad
    static string Categoria(int edad)
    {
        if (edad < 13)
        {
            return "Niño";
        }
        else if (edad < 18)
        {
            return "Adolescente";
        }
        else if (edad < 50)
        {
            return "Adulto";
        }
        else
        {
            return "Adulto mayor";
        }
    }


    static void Main() // aqui esta el punto de entrada
    {
        int opcion;

        do
        {
            Console.WriteLine("=== CINE CLUB ===");
            Console.WriteLine("1) Registrar 2) Tarifas 3) Salir");
            Console.Write("Opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();

                    Console.Write("Edad: ");
                    int edad = int.Parse(Console.ReadLine());

                    Console.Write("Género (F/M): ");
                    string genero = Console.ReadLine().ToUpper();

                    string categoria = Categoria(edad);

                    if (edad < 18)
                    {
                        Console.WriteLine(nombre.ToUpper() + " | " + categoria + " | No puede entrar");
                    }
                    else if (genero == "F")
                    {
                        Console.WriteLine(nombre.ToUpper() + " | " + categoria + " | Entrada GRATIS");
                    }
                    else
                    {
                        Console.WriteLine(nombre.ToLower() + " | " + categoria + " | Entrada RD$300");
                    }
                    break;

                case 2:
                    Console.WriteLine("Menores de 18: no entran");
                    Console.WriteLine("Mujeres: gratis");
                    Console.WriteLine("Hombres: RD$300");
                    break;

                case 3:
                    Console.WriteLine("Hasta luego");
                    break;

                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }

            Console.WriteLine();

        } while (opcion != 3); // esto es por si ponen una opcion diferente a la 1,2,3
    }
}