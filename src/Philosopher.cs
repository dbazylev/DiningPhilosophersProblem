using System;
using DiningPhilosophersProblem.Base;

namespace DiningPhilosophersProblem
{
    class Philosopher : BasePhilosopher
    {
        public Philosopher(int position, Fork left, Fork right) : base(position, left, right)
        {
        }

        public override void Run()
        {
            while (!stopFlag)
            {
                Think();

                lock (left)
                {
                    Console.WriteLine("[Philosopher {0} ] took left fork", position);

                    lock (right)
                    {
                        Console.WriteLine("[Philosopher {0} ] took rigth fork", position);
                        Eat();
                    }
                }
            }
            Console.WriteLine("[Philosopher {0} ] stopped", position);
        }
    }
}
