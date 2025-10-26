using System.Collections.Generic;
using System.Linq;

public class DoublyLinkedList<T> where T : IComparable<T>
{
    // Propiedades de la lista
    public Node<T>? Head { get; private set; } // Inicio de la lista
    public Node<T>? Tail { get; private set; } // Fin de la lista

    public DoublyLinkedList()
    {
        Head = null;
        Tail = null;
    }

    // --- Opción 1: Adicionar (Inserción Ordenada Ascendente) ---
    public void Add(T newData)
    {
        Node<T> newNode = new Node<T>(newData);

        // Caso 1: Lista vacía
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
            return;
        }

        // Caso 2: Inserción al inicio (si el nuevo dato es menor o igual a la cabeza)
        if (newNode.Data.CompareTo(Head.Data) <= 0)
        {
            newNode.Next = Head;
            Head.Prev = newNode;
            Head = newNode;
            return;
        }

        // Caso 3: Búsqueda de la posición intermedia o final
        Node<T> current = Head;
        // Avanza mientras haya un siguiente nodo Y el siguiente sea menor que el nuevo
        while (current.Next != null && current.Next.Data.CompareTo(newNode.Data) < 0)
        {
            current = current.Next;
        }

        // Inserción después de 'current'
        if (current.Next == null)
        {
            // Inserción al final, actualiza la cola
            current.Next = newNode;
            newNode.Prev = current;
            Tail = newNode;
        }
        else
        {
            // Inserción en el medio
            newNode.Next = current.Next;
            newNode.Prev = current;
            current.Next.Prev = newNode;
            current.Next = newNode;
        }
    }

    // --- Opción 2: Mostrar hacia adelante ---
    public void DisplayForward()
    {
        if (Head == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Console.Write("LISTA (Adelante): ");
        Node<T>? current = Head;
        while (current != null)
        {
            Console.Write(current.Data);
            if (current.Next != null)
            {
                Console.Write(" -> ");
            }
            current = current.Next;
        }
        Console.WriteLine();
    }

    // --- Opción 3: Mostrar hacia atrás ---
    public void DisplayBackward()
    {
        if (Tail == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Console.Write("LISTA (Atrás): ");
        Node<T>? current = Tail; // Comienza desde la cola
        while (current != null)
        {
            Console.Write(current.Data);
            if (current.Prev != null)
            {
                Console.Write(" <- ");
            }
            current = current.Prev; // Retrocede usando 'Prev'
        }
        Console.WriteLine();
    }

    // --- Opción 4: Ordenar descendentemente (invertir la lista) ---
    public void ReverseOrder()
    {
        if (Head == null)
        {
            Console.WriteLine("La lista está vacía, no se puede invertir.");
            return;
        }

        Node<T>? current = Head;
        Node<T>? temp = null;

        // 1. Recorrer la lista e intercambiar Next por Prev
        while (current != null)
        {
            temp = current.Prev;       // Guarda el puntero anterior
            current.Prev = current.Next; // El puntero anterior ahora es el siguiente
            current.Next = temp;       // El puntero siguiente ahora es el anterior

            // Avanza al siguiente nodo (que ahora está en current.Prev, ¡es el truco!)
            current = current.Prev;
        }

        // 2. Intercambiar Head y Tail para reflejar el nuevo inicio/fin de la lista
        temp = Head;
        Head = Tail;
        Tail = temp;

        Console.WriteLine("La lista ha sido reordenada descendentemente.");
    }

    // --- Lógica auxiliar para desconectar un nodo ---
    private void DisconnectNode(Node<T> target)
    {
        // Reconección del nodo anterior con el sucesor
        if (target.Prev != null)
        {
            target.Prev.Next = target.Next;
        }
        // Reconección del nodo sucesor con el anterior
        if (target.Next != null)
        {
            target.Next.Prev = target.Prev;
        }
    }

    // --- Opción 7: Existe ---
    public bool Exists(T dataToFind)
    {
        Node<T>? current = Head;
        while (current != null)
        {
            if (current.Data.CompareTo(dataToFind) == 0)
            {
                return true; // Encontrado
            }
            current = current.Next;
        }
        return false; // No encontrado
    }

    // --- Opción 8: Eliminar una ocurrencia ---
    public bool RemoveOneOccurrence(T dataToRemove)
    {
        Node<T>? current = Head;
        while (current != null)
        {
            if (current.Data.CompareTo(dataToRemove) == 0)
            {
                // Manejar la eliminación de la cabeza
                if (current == Head)
                {
                    Head = Head.Next;
                    if (Head != null) Head.Prev = null;
                    else Tail = null; // Lista vacía
                }
                // Manejar la eliminación de la cola
                else if (current == Tail)
                {
                    Tail = Tail.Prev;
                    Tail!.Next = null;
                }
                // Manejar caso intermedio
                else
                {
                    DisconnectNode(current);
                }
                return true; // Éxito: solo eliminamos el primero
            }
            current = current.Next;
        }
        return false; // No se encontró el elemento
    }

    // --- Opción 9: Eliminar todas las ocurrencias ---
    public int RemoveAllOccurrences(T dataToRemove)
    {
        int count = 0;
        Node<T>? current = Head;

        while (current != null)
        {
            // Guarda el siguiente nodo ANTES de una posible eliminación
            Node<T>? nextNode = current.Next;

            if (current.Data.CompareTo(dataToRemove) == 0)
            {
                // Lógica de eliminación, similar a RemoveOne, pero sin salir
                if (current == Head)
                {
                    Head = current.Next;
                    if (Head != null) Head.Prev = null;
                    if (Head == null) Tail = null;
                }
                else if (current == Tail)
                {
                    Tail = current.Prev;
                    if (Tail != null) Tail.Next = null;
                }
                else
                {
                    DisconnectNode(current);
                }
                count++;
            }
            current = nextNode; // Continuar el recorrido
        }
        return count;
    }

    // --- Opción 5: Mostrar la(s) moda(s) ---
    public void DisplayModes()
    {
        if (Head == null)
        {
            Console.WriteLine("La lista está vacía, no hay moda.");
            return;
        }

        // Usa un diccionario para contar las frecuencias
        Dictionary<T, int> frequencies = new Dictionary<T, int>();
        Node<T>? current = Head;

        // 1. Contar frecuencias
        while (current != null)
        {
            if (frequencies.ContainsKey(current.Data))
                frequencies[current.Data]++;
            else
                frequencies.Add(current.Data, 1);
            current = current.Next;
        }

        // 2. Encontrar la frecuencia máxima
        int maxFrequency = frequencies.Values.Max();

        // 3. Imprimir las modas (elementos con la frecuencia máxima)
        Console.Write("La(s) moda(s) son: ");
        bool isFirst = true;
        foreach (var pair in frequencies)
        {
            if (pair.Value == maxFrequency)
            {
                if (!isFirst) Console.Write(", ");
                Console.Write(pair.Key);
                isFirst = false;
            }
        }
        Console.WriteLine($" (con {maxFrequency} ocurrencia(s)).");
    }

    // --- Opción 6: Mostrar gráfico ---
    public void DisplayChart()
    {
        if (Head == null)
        {
            Console.WriteLine("La lista está vacía, no hay gráfico que mostrar.");
            return;
        }

        // Recalcula frecuencias (o usa la misma lógica que DisplayModes)
        Dictionary<T, int> frequencies = new Dictionary<T, int>();
        Node<T>? current = Head;

        while (current != null)
        {
            if (frequencies.ContainsKey(current.Data))
                frequencies[current.Data]++;
            else
                frequencies.Add(current.Data, 1);
            current = current.Next;
        }

        Console.WriteLine("\n--- Gráfico de Ocurrencias ---");
        // Imprime cada elemento seguido de su cantidad de asteriscos
        foreach (var pair in frequencies)
        {
            string stars = new string('*', pair.Value); // Crea la cadena de asteriscos
            Console.WriteLine($"{pair.Key} {stars}");
        }
        Console.WriteLine("------------------------------");
    }
}