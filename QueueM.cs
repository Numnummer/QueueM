namespace ModifiedQueue
{
    public class QueueM<T>
        where T : IComparable
    {
        private readonly StackM<T> stackForAdding;
        private readonly StackM<T> stackForTaking;
        public QueueM()
        {
            stackForTaking = new StackM<T>();
            stackForAdding = new StackM<T>();
        }

        /// <summary>
        /// Здесь мы переносим данные из 1 стека во 2 стек, потому что 
        /// все наши данные для чтения лежат во 2 стеке
        /// 1 стек это типо буфер
        /// </summary>
        /// <returns>Минимальный элемент в очереди</returns>
        public T Min()
        {
            MigrateDataForTaking();
            return stackForTaking.Min;
        }

        public T Peek()
        {
            MigrateDataForTaking();
            return stackForTaking.Peek();
        }

        public T Dequeue()
        {
            MigrateDataForTaking();
            return stackForTaking.Pop();
        }

        public void Enqueue(T item)
        {
            stackForAdding.Push(item);
        }

        /// <summary>
        /// мы здесь переносим по очереди элементы с 1 стека
        /// во 2, таким образом первый добавленный элемент 1 стека
        /// станет последним добавленным во 2 стеке
        /// таким образом мы моделируем очередь
        /// </summary>
        private void MigrateDataForTaking()
        {
            if (stackForTaking.Count == 0)
            {
                while (stackForAdding.Count > 0)
                {
                    stackForTaking.Push(stackForAdding.Pop());
                }
            }
        }
    }
}