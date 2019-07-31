using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataCollectionsTest
{
    [TestClass]
    public class MyQueueTest_Int
    {
        [TestMethod]
        public void MyQueue_Enqueue_Dequeue_ZeroItems()
        {
            IQueue<int> myQueue = new MyQueue<int>();

            myQueue.Enqueue(5);
            myQueue.Dequeue();

            Assert.AreEqual(myQueue.Count, 0);

        }

        [TestMethod]
        public void MyQueue_Enqueue_OneItem()
        {
            IQueue<int> myQueue = new MyQueue<int>();

            myQueue.Enqueue(1);

            Assert.AreEqual(myQueue.Count, 1);
        }

        [TestMethod]
        public void MyQueue_Peep_OneItems()
        {
            IQueue<int> myQueue = new MyQueue<int>();

            myQueue.Enqueue(5);

            Assert.AreEqual(myQueue.Peep(), 5);
            Assert.AreEqual(myQueue.Count, 1);
        }

        [TestMethod]
        public void MyQueue_Peep_TwoItems()
        {
            IQueue<int> myQueue = new MyQueue<int>();

            myQueue.Enqueue(5);
            myQueue.Enqueue(7);

            Assert.AreEqual(myQueue.Peep(), 5);
            Assert.AreEqual(myQueue.Count, 2);
        }

        [TestMethod]
        public void MyQueue_Dequeue_OneItem()
        {
            IQueue<int> myQueue = new MyQueue<int>();

            myQueue.Enqueue(5);

            Assert.AreEqual(myQueue.Dequeue(), 5);
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyQueueException))]
        public void MyQueue_DequeueOnEmptyQueue_Excpetion()
        {
            IQueue<int> myQueue = new MyQueue<int>();

            myQueue.Dequeue();
        }

        [TestMethod]
        public void MyQueue_Clear()
        {
            IQueue<int> myQueue = new MyQueue<int>();

            myQueue.Enqueue(5);
            myQueue.Enqueue(7);
            myQueue.Clear();

            Assert.AreEqual(myQueue.Count, 0);
        }

        [TestMethod]
        public void MyQueue_MultiThreaded_Support()
        {
            IQueue<int> myQueue = new MyQueue<int>();

            List<Task> tasks = new List<Task>();

            for (int i = 0; i < 10000; i++)
            {
                
                //Thread t = new Thread(() =>
                //{
                    ////////////
                //});
                //t.IsBackground = true;
                //t.Start();
                // thread pool

                tasks.Add(Task.Run(() =>
                {
                    myQueue.Enqueue(5);
                    myQueue.Dequeue();
                    myQueue.Enqueue(7);
                    myQueue.Clear();
                }));
            }

            Task.WaitAll(tasks.ToArray());

        }
    }
}
