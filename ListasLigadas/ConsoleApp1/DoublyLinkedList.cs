using System.Collections.Generic;
using System.Linq;

public class DoublyLinkedList<T> where T : IComparable<T>
{
    public Node<T>? Head { get; private set; } 
    public Node<T>? Tail { get; private set; } 

    public DoublyLinkedList()
    {
        Head = null;
        Tail = null;
    }
    // Option 1: Add
    public void Add(T newData)
    {
        T normalizedData = newData;
        if (newData is string stringData)
        {
            normalizedData = (T)(object)stringData.ToLower()!;
        }

        Node<T> newNode = new Node<T>(normalizedData); 

        // Case 1
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
            return;
        }

        // Case 2
        if (newNode.Data.CompareTo(Head.Data) <= 0)
        {
            newNode.Next = Head;
            Head.Prev = newNode;
            Head = newNode;
            return;
        }

        // Case 3
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
    // Option 2
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
    // Option 3
    public void DisplayBackward()
    {
        if (Tail == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Console.Write("LISTA (Atrás): ");
        Node<T>? current = Tail; 
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
    // Option 4
    public void ReverseOrder()
    {
        if (Head == null)
        {
            Console.WriteLine("La lista está vacía, no se puede invertir.");
            return;
        }

        Node<T>? current = Head;
        Node<T>? temp = null;

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
    // Option 5
    public void DisplayModes()
    {
        if (Head == null)
        {
            Console.WriteLine("La lista está vacía, no hay moda.");
            return;
        }

        // Use dictionary
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

        int maxFrequency = frequencies.Values.Max();

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
    // Option 6
    public void DisplayChart()
    {
        if (Head == null)
        {
            Console.WriteLine("La lista está vacía, no hay gráfico que mostrar.");
            return;
        }

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

        foreach (var pair in frequencies)
        {
            string stars = new string('*', pair.Value);
            Console.WriteLine($"{pair.Key} {stars}");
        }
        Console.WriteLine("------------------------------");
    }
    // Option 7
    public bool Exists(T dataToFind)
    {
        Node<T>? current = Head;
        while (current != null)
        {
            if (current.Data.CompareTo(dataToFind) == 0)
            {
                return true;
            }
            current = current.Next;
        }
        return false;

    }
    // Option 8
    public bool RemoveOneOccurrence(T dataToRemove)
    {
        Node<T>? current = Head;
        while (current != null)
        {
            if (current.Data.CompareTo(dataToRemove) == 0)
            {
                if (current == Head)
                {
                    Head = Head.Next;
                    if (Head != null) Head.Prev = null;
                    else Tail = null;
                }
                else if (current == Tail)
                {
                    Tail = Tail.Prev;
                    Tail!.Next = null;
                }

                else
                {
                    DisconnectNode(current);
                }
                return true;
            }
            current = current.Next;
        }
        return false;
    }
    // Option 9
    public int RemoveAllOccurrences(T dataToRemove)
    {
        int count = 0;
        Node<T>? current = Head;

        while (current != null)
        {
            Node<T>? nextNode = current.Next;

            if (current.Data.CompareTo(dataToRemove) == 0)
            {
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
            current = nextNode; 
        }
        return count;
    }
    // Aux
    private void DisconnectNode(Node<T> target)
    {
        if (target.Prev != null)
        {
            target.Prev.Next = target.Next;
        }
        if (target.Next != null)
        {
            target.Next.Prev = target.Prev;
        }
    }
}