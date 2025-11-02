using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstruturasDados.Classes
{
    public interface IDoubleCircularLinkedList<T>
    {
        bool IsEmpty();
        int Size();
        void Clear();
        bool Add(T value);
        bool Remove(T value);
        bool InsertAt(int index, T value);
        T? PeekFirst();
        T? PeekLast();
    }
}