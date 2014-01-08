using System;
using System.Diagnostics;
using System.Threading;

namespace DiningPhilosophersProblem.Base
{
    abstract class BasePhilosopher
    {
        protected readonly int position;
        protected Fork left;
        protected Fork right;
        protected int eatCount = 0;
        protected readonly Stopwatch waitTime = new Stopwatch();
        protected readonly Random random = new Random();
        protected bool stopFlag;
        
        protected BasePhilosopher(int position, Fork left, Fork right)
        {
            this.position = position;
            this.left = left;
            this.right = right;
        }

        public void Stop()
        {
            stopFlag = true;
        }
        
        public void Eat()
        {
            waitTime.Stop();
            Console.WriteLine("[Philosopher {0} ] is eating", position);
            Thread.Sleep(random.Next(100));
            eatCount++;
            Console.WriteLine("[Philosopher {0} ] finished eating", position);
        }

        public void Think()
        {
            Console.WriteLine("[Philosopher {0} ] is thinking", position);
            Thread.Sleep(random.Next(100));
            Console.WriteLine("[Philosopher {0} ] is hungry", position);
            waitTime.Start();
        }

        public void Status()
        {
            Console.WriteLine("[Philosopher {0} ] ate {1} times, waited {2} ms", position, eatCount, waitTime.Elapsed.TotalMilliseconds);
        }

        public abstract void Run();

    }
}
