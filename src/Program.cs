using System;
using System.Threading;
using DiningPhilosophersProblem.Base;

namespace DiningPhilosophersProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            const int count = 5;
            BasePhilosopher[] philosophers = new BasePhilosopher[count];
            Fork last = new Fork();
            Fork left = last;
            
            for (int i = 0; i < count; i++)
            {
                Fork rigth = (i == count - 1) ? last : new Fork();
                philosophers[i] = new Philosopher(i, left, rigth);
                left = rigth;
            }

            Thread[] threds = new Thread[count];
            for (int i = 0; i < count; i++)
            {
                threds[i] = new Thread(philosophers[i].Run);
                threds[i].Start();
            }

            Thread.Sleep(6000);

            foreach (var philosopher in philosophers)
            {
                philosopher.Stop();
            }

            foreach (var thread in threds)
            {
                thread.Join();
            }

            foreach (var philosopher in philosophers)
            {
                philosopher.Status();
            }

            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
