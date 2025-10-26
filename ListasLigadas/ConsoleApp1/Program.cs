public class Program
{
    public static void Main(string[] args)
    {
        DoublyLinkedList<string> list = new DoublyLinkedList<string>();
        string input;
        int option;

        do
        {
            Console.WriteLine("\n--- Taller #5 - Listas Ligadas ---");
            Console.WriteLine("1. Adicionar (Inserción ordenada)");
            Console.WriteLine("2. Mostar hacia adelante");
            Console.WriteLine("3. Mostar hacia atrás");
            Console.WriteLine("4. Ordenar descendentemente");
            Console.WriteLine("5. Mostrar la(s) moda(s)");
            Console.WriteLine("6. Mostrar gráfico");
            Console.WriteLine("7. Existe");
            Console.WriteLine("8. Eliminar una ocurrencia");
            Console.WriteLine("9. Eliminar todas las ocurrencias");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            input = Console.ReadLine()!;

            if (int.TryParse(input, out option))
            {
                switch (option)
                {
                    case 1:
                        Console.Write("Ingrese el dato a adicionar: ");
                        string dato = Console.ReadLine()!;
                        list.Add(dato);
                        Console.WriteLine($"'{dato}' ha sido añadido en orden.");
                        break;
                    case 2:
                        list.DisplayForward();
                        break;
                    case 3:
                        list.DisplayBackward();
                        break;
                    case 4:
                        list.ReverseOrder();
                        break;
                    case 5:
                        list.DisplayModes();
                        break;
                    case 6:
                        list.DisplayChart();
                        break;
                    case 7:
                        Console.Write("Ingrese el dato a buscar: ");
                        string searchData = Console.ReadLine()!;
                        if (list.Exists(searchData))
                        {
                            Console.WriteLine($"El dato '{searchData}' SÍ existe en la lista.");
                        }
                        else
                        {
                            Console.WriteLine($"El dato '{searchData}' NO existe en la lista.");
                        }
                        break;
                    case 8:
                        Console.Write("Ingrese el dato a eliminar (una ocurrencia): ");
                        string removeOne = Console.ReadLine()!;
                        if (list.RemoveOneOccurrence(removeOne))
                        {
                            Console.WriteLine($"La primera ocurrencia de '{removeOne}' ha sido eliminada.");
                        }
                        else
                        {
                            Console.WriteLine($"El dato '{removeOne}' no fue encontrado para eliminar.");
                        }
                        break;
                    case 9:
                        Console.Write("Ingrese el dato a eliminar (todas las ocurrencias): ");
                        string removeAll = Console.ReadLine()!;
                        int count = list.RemoveAllOccurrences(removeAll);
                        Console.WriteLine($"Se eliminaron {count} ocurrencia(s) de '{removeAll}'.");
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del programa. ¡Adiós!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
                option = -1; // Para que el bucle continúe
            }
        } while (option != 0);
    }
}
