using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedQueue
{
    /// <summary>
    /// Стек минимумов это самый обычный стек, только мы кроме самих данных 
    /// храним такжк и минимальный элемент
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StackM<T> : IStackM<T> where T : IComparable
    {
        //Первый элемент кортежа это значение а второй элемент
        //это минимум всего стека
        private readonly List<(T, T)> elements;
        public StackM()
        {
            elements = new List<(T, T)>();
        }
        public T Min => elements[^1].Item2;

        public int Count => elements.Count;

        public T Peek()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return elements[^1].Item1;
        }

        public T Pop()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException();
            }
            var element = elements[^1];
            elements.RemoveAt(elements.Count - 1);
            return element.Item1;
        }

        public void Push(T item)
        {
            if (elements.Count == 0)
            {
                elements.Add((item, item));
                return;
            }
            if (item.CompareTo(elements[^1].Item2) == -1)
            {
                elements.Add((item, item));
                return;
            }
            elements.Add((item, elements[^1].Item2));
        }
    }
}
