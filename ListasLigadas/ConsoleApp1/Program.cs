public class Program
{
    public static void Main(string[] args)
    {
        // Usamos string para que el ejemplo de colores funcione
        DoublyLinkedList<string> list = new DoublyLinkedList<string>();
        string input;
        int option;

        do
        {
            Console.Write("Seleccione una opción: ");
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

            input = Console.ReadLine();

            if (int.TryParse(input, out option))
            {
                switch (option)
                {
                    case 1:
                        Console.Write("Ingrese el dato a adicionar: ");
                        string dato = Console.ReadLine();
                        list.Add(dato);
                        Console.WriteLine($"'{dato}' ha sido añadido en orden.");
                        break;
                    case 2:
                        list.DisplayForward();
                        break;
                    case 3:
                        list.DisplayBackward();
                        break;
                    // Los casos 4 a 9 se implementarán en el siguiente paso.
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
                option = -1;
            }
        } while (option != 0);
    }
}
