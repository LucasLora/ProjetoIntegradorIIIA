using ProjetoIntegradorIIIA.CustomLinkedList;

namespace ProjetoIntegradorIIIA
{
    public class CustomLinkedList<T> : ICustomLinkedList<T>
    {
        internal CustomLinkedListNode<T> head;
        internal int count;

        public int Count => count;

        public CustomLinkedListNode<T> First => head;

        public CustomLinkedListNode<T> Last => head?.prev;

        public void AddFirst(T item)
        {
            CustomLinkedListNode<T> node = new CustomLinkedListNode<T>(this, item);

            if (head == null)
            {
                InternalInsertNodeToEmptyList(node);
            }
            else
            {
                InternalInsertNodeBefore(head, node);
                head = node;
            }
        }

        public void AddLast(T item)
        {
            CustomLinkedListNode<T> node = new CustomLinkedListNode<T>(this, item);

            if (head == null)
            {
                InternalInsertNodeToEmptyList(node);
            }
            else
            {
                InternalInsertNodeBefore(head, node);
            }
        }

        private void InternalInsertNodeToEmptyList(CustomLinkedListNode<T> newNode)
        {
            newNode.next = newNode;
            newNode.prev = newNode;
            head = newNode;
            count++;
        }

        private void InternalInsertNodeBefore(CustomLinkedListNode<T> node, CustomLinkedListNode<T> newNode)
        {
            newNode.next = node;
            newNode.prev = node.prev;
            node.prev.next = newNode;
            node.prev = newNode;
            count++;
        }

        public void RemoveFirst()
        {
            if (head == null) { throw new InvalidOperationException("The CustomLinkedList is empty"); }
            InternalRemoveNode(head);
        }

        public void RemoveLast()
        {
            if (head == null) { throw new InvalidOperationException("The CustomLinkedList is empty"); }
            InternalRemoveNode(head.prev);
        }

        private void InternalRemoveNode(CustomLinkedListNode<T> node)
        {
            if (node.next == node)
            {
                head = null;
            }
            else
            {
                node.next.prev = node.prev;
                node.prev.next = node.next;
                if (head == node)
                {
                    head = node.next;
                }
            }

            node.Invalidate();
            count--;
        }

        public void Sort(Comparison<T> comparison)
        {
            if (Count <= 1) return;

            bool swapped = true;

            while (swapped)
            {
                swapped = false;

                for (CustomLinkedListNode<T> node = First; node != null && node.Next != null; node = node.Next)
                {
                    if (comparison(node.Value, node.Next.Value) > 0)
                    {
                        T temp = node.Value;
                        node.Value = node.Next.Value;
                        node.Next.Value = temp;

                        swapped = true;
                    }
                }
            }
        }
    }
}
