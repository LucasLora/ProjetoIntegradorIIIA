namespace ProjetoIntegradorIIIA.CustomLinkedList
{
    public class CustomLinkedListNode<T>
    {
        internal CustomLinkedList<T> list;
        internal CustomLinkedListNode<T> next;
        internal CustomLinkedListNode<T> prev;
        internal T value;

        internal CustomLinkedListNode(CustomLinkedList<T> list, T value)
        {
            this.list = list;
            this.value = value;
        }

        public CustomLinkedList<T> List => list;

        public CustomLinkedListNode<T> Next => next == null || next == list.head ? null : next;

        public CustomLinkedListNode<T> Previous => prev == null || this == list.head ? null : prev;

        public T Value
        {
            get => value;
            set => this.value = value;
        }

        internal void Invalidate()
        {
            list = null;
            next = null;
            prev = null;
        }
    }
}
