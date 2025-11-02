using System;
using System.Collections.Generic;
using System.Linq;

namespace EstruturasDados.Classes
{
    public class DoubleCircularLinkedList<T> : IDoubleCircularLinkedList<T>
    {
        private int Length = 0;
        private DoubleNode<T>? Head = null;
        private DoubleNode<T>? Tail = null;

        public void Clear()
        {
            this.Head = null;
            this.Tail = null;
            this.Length = 0;
        }

        public bool IsEmpty()
        {
            return this.Length == 0;
        }

        public int Size()
        {
            return this.Length;
        }

        public T? PeekFirst()
        {
            if (this.Head == null) return default;

            return this.Head.Value;
        }

        public T? PeekLast()
        {
            return this.Tail != null ? this.Tail.Value : default;
        }
        
        public bool Add(T value)
        {
            DoubleNode<T> node = new(value);
            if (this.Head == null)
            {
                // define a cabeça e a cauda por ser o primeiro nó
                this.Head = this.Tail = node;
                // para iniciar o comportamento circular, seta o next e o prev de ambos para o mesmo ponto
                // não tenho certeza quanto a isso
                this.Head.Next = this.Head.Prev = this.Tail.Next = this.Tail.Prev = this.Head;
                this.Length++;
                return true;
            }

            // define o prev do novo nó como a cauda atual
            node.Prev = this.Tail;
            // define o next da cauda atual para o novo nó
            this.Tail!.Next = node;
            // define a nova cauda
            this.Tail = node;

            // fecha o círculo atualizando o prev da cabeça e o next da cauda
            this.Tail.Next = this.Head;
            this.Head.Prev = this.Tail;

            this.Length++;
            return true;
        }

        public bool InsertAt(int index, T value)
        {
            return true;
        }

        public bool Remove(T value)
        {
            if (this.Head == null) return false;

            if (this.Head == this.Tail)
            {
                if (this.Head.Value!.GetHashCode() == value!.GetHashCode())
                {
                    this.Clear();
                    return true;
                }
                return false;
            }

            DoubleNode<T>? prev = this.Head;
            DoubleNode<T>? curr = this.Head.Next;
            // para evitar um loop infinito, devido à circularidade
            int size = this.Length - 1; // -1 para desconsiderar a Head
            while (curr != null && size > 0)
            {
                if (curr.Value!.GetHashCode() == value!.GetHashCode())
                {
                    prev!.Next = curr.Next;
                    curr.Next!.Prev = prev;
                    if (curr == this.Tail)
                    {
                        this.Tail = prev;
                    }
                    this.Length--;
                    return true;
                }
                size--;
                curr = curr.Next;
                prev = curr!.Prev;
            }
            
            return false;
        }
    }
}