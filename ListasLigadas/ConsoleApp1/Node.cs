public class Node<T>
{
    public T Data { get; set; }
    public Node<T>? Next { get; set; } // Referencia al siguiente nodo
    public Node<T>? Prev { get; set; } // Referencia al nodo anterior

    // Constructor
    public Node(T data)
    {
        Data = data;
        Next = null;
        Prev = null;
    }
}
