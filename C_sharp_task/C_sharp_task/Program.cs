using System.Threading;
using System;

namespace threaddemo
{
    class Program
    {
        static void Main(string[] args)
        {
            (new Program()).Start();
        }

        void Start()
        {

            double[] array = { 1, 2, 3, 4, 5 };

            for (int i = 1; i <= array.Length; i++)
            {
                int threadId = i;
                (new Thread(() => Calcuator(threadId))).Start();
            }

            (new Thread(Stoper)).Start();
           

           /* (new Thread(() => Calcuator(1))).Start();
            (new Thread(() => Calcuator(2))).Start();
            (new Thread(() => Calcuator(3))).Start();
            (new Thread(() => Calcuator(4))).Start();
            (new Thread(() => Calcuator(5))).Start();

            //Thread thread1 = new Thread(() => Calcuator(4));
            //thread1.Start();

            (new Thread(Stoper)).Start(); */

        }

        void Calcuator(int thread_id)
        {
            int id = System.Environment.CurrentManagedThreadId;
            long sum = 0;
            int step = 2;
            int count = 0;

            while (!CanStop)
            {
                sum += count * step;
                count++;
            }

            Console.WriteLine(id + " or Thread: " + thread_id + ") " + sum + " - count: " + count);
        }

        private bool canStop = false;

        public bool CanStop { get => canStop; }

        public void Stoper()
        {
            Thread.Sleep(5 * 1000);
            canStop = true;
        }
    }
}