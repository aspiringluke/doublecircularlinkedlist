using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstruturasDados.Classes
{
    public class DoubleNode<T>(T value, DoubleNode<T>? prev = null, DoubleNode<T>? next = null)
    {
        public T Value { get; set; } = value;
        public DoubleNode<T>? Prev { get; set; } = prev;
        public DoubleNode<T>? Next { get; set; } = next;

        // public DoubleNode(T value, DoubleNode<T>? prev = null, DoubleNode<T>? next = null)
        // {
        //     this.Value = value;
        //     this.Prev = prev;
        //     this.Next = next;
        // }
    }
}