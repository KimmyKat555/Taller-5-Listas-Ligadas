public class DoublyLinkedList<T> where T : IComparable<T>
{
    public Node<T> Head { get; private set; } // Inicio de la lista
    public Node<T> Tail { get; private set; } // Fin de la lista

    public DoublyLinkedList()
    {
        Head = null;
        Tail = null;
    }

    // --- Opción 1: Adicionar (Inserción Ordenada Ascendente) ---
    public void Add(T newData)
    {
        Node<T> newNode = new Node<T>(newData);

        // Caso 1: Empty list
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
            return;
        }

        // Case 2: Insertion at the beginning (if newData <= Head.Data)
        if (newNode.Data.CompareTo(Head.Data) <= 0)
        {
            newNode.Next = Head;
            Head.Prev = newNode;
            Head = newNode;
            return;
        }

        // Case 3: Search for intermediate or final position
        Node<T> current = Head;
        while (current.Next != null && current.Next.Data.CompareTo(newNode.Data) < 0)
        {
            current = current.Next;
        }
        if (current.Next == null)
        {
            current.Next = newNode;
            newNode.Prev = current;
            Tail = newNode;
        }
        else
        {
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
        Node<T> current = Head;
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
        Node<T> current = Tail;
        while (current != null)
        {
            Console.Write(current.Data);
            if (current.Prev != null)
            {
                Console.Write(" <- ");
            }
            current = current.Prev;
        }
        Console.WriteLine();
    }
    // Opción 4: Ordenar descendentemente (invertir la lista)
    public void ReverseOrder()
    {
        if (Head == null)
        {
            Console.WriteLine("La lista está vacía, no se puede invertir.");
            return;
        }

        Node<T> current = Head;
        Node<T> temp = null;

        // 1. Recorrer la lista e intercambiar Next por Prev
        while (current != null)
        {
            temp = current.Prev;       
            current.Prev = current.Next; 
            current.Next = temp;       

            current = current.Prev;
        }
        temp = Head;
        Head = Tail;
        Tail = temp;

        Console.WriteLine("La lista ha sido reordenada descendentemente.");
    }
}