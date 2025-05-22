using System;
using System.Collections.Generic;

namespace Misc
{
    public class PriorityQueue<T>
    {
        private readonly List<Node<T>> _nodes = new List<Node<T>>();

        public int Count => _nodes.Count;

        public T Dequeue()
        {
            if (Count == 0)
                throw new IndexOutOfRangeException($"{nameof(PriorityQueue<T>)} size is 0. Cannot dequeue.");

            T result = _nodes[0].Data;
            _nodes.RemoveAt(0);

            return result;
        }

        public void Enqueue(T obj, int priority = 0)
        {
            Node<T> node = new Node<T>(obj, priority);

            for (int i = 0; i < Count; i++)
            {
                if (_nodes[i].Priority >= priority)
                    continue;

                _nodes.Insert(i, node);

                return;
            }

            _nodes.Add(node);
        }
    }

    internal struct Node<T>
    {
        public readonly T Data;
        public readonly int Priority;

        public Node(T data, int priority)
        {
            Data = data;
            Priority = priority;
        }
    }
}