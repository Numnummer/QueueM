using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedQueue
{
    public interface IStackM<T> where T : IComparable
    {
        void Push(T item);
        T Pop();
        T Peek();
        T Min { get; }
        int Count { get; }
    }
}
