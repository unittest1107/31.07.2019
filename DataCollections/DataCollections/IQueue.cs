using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollections
{
    public interface IQueue<T>
    {
        void Enqueue(T data);

        T Dequeue();

        T Peep();

        void Clear();

        int Count { get; }
    }
}
