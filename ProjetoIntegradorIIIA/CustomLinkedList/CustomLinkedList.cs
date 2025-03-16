using ProjetoIntegradorIIIA.CustomLinkedList;

namespace ProjetoIntegradorIIIA
{
    public class CustomLinkedList<T> : ICustomLinkedList<T>
    {
        internal CustomLinkedListNode<T> head;
        internal int count;

        public int Count
        {
            get { return count; }
        }

        public CustomLinkedListNode<T> First
        {
            get { return head; }
        }

        public CustomLinkedListNode<T> Last
        {
            get { return head == null ? null : head.prev; }
        }

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

        internal void InternalRemoveNode(CustomLinkedListNode<T> node)
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
    }
}
