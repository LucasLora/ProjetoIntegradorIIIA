namespace ProjetoIntegradorIIIA.CustomLinkedList
{
    public interface ICustomLinkedList<T>
    {
        int Count { get; }
        void AddFirst(T item);
        void AddLast(T item);
        void RemoveFirst();
        void RemoveLast();
        void Sort(Comparison<T> comparison);
    }
}
