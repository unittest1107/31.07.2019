using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollections
{
    public class MyQueue<T> : IQueue<T>
    {

        private List<T> data;

        public int Count
        {
            get
            {
                // Critical section
                lock(this)
                {
                    return data.Count;
                }
            }
        }

        public void Clear()
        {
            lock (this)
            {
                throw new NotImplementedException();
            }
        }

        public T Dequeue()
        {
            lock (this)
            {
                throw new NotImplementedException();
            }
        }

        public void Enqueue(T data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks who is next in line?
        /// </summary>
        /// <returns></returns>
        public T Peep()
        {
            throw new NotImplementedException();
        }
    }
}
