using System;
using System.Diagnostics;

namespace Perfomance
{
    class C : IComparable<C>
    {
        public int i;
        
        public int CompareTo(C item)
        {
            return this.i.CompareTo(item.i);
        }
    }

    struct S : IComparable<S>
    {
        public int i;

        public int CompareTo(S item)
        {
            return this.i.CompareTo(item.i);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            var process = Process.GetCurrentProcess();
            long memoryBeforeClassesInitialization;
            long memoryAfterClassesInitialization;
            long memoryBeforeStructsInitialization;
            long memoryAfterStructsInitialization;

            process.Refresh();
            memoryBeforeClassesInitialization = process.PrivateMemorySize64;
            var classes = new C[100000];
            for (int i = 0; i < 100000; i++)
            {
                classes[i] = new C();
                classes[i].i = rand.Next();
            }
            process.Refresh();
            memoryAfterClassesInitialization = process.PrivateMemorySize64;
            long delta1 = memoryAfterClassesInitialization 
                - memoryBeforeClassesInitialization;

            Console.WriteLine("Delta for PrivateMemorySize64 for classes is: " + delta1);
            process.Refresh();
            memoryBeforeStructsInitialization = process.PrivateMemorySize64;
            var structs = new S[100000];
            for (int i = 0; i < 100000; i++)
            {
                structs[i].i = rand.Next();
            }
            process.Refresh();
            memoryAfterStructsInitialization = process.PrivateMemorySize64;
            long delta2 = memoryAfterStructsInitialization
                - memoryBeforeStructsInitialization;

            Console.WriteLine("Delta for PrivateMemorySize64 for structs is: " + delta2);
            Console.WriteLine("Difference between deltas is: " + (delta1 - delta2));

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Array.Sort<C>(classes);
            stopWatch.Stop();
            Console.WriteLine("Execution time (classes): " + stopWatch.ElapsedMilliseconds + " ms");

            stopWatch.Restart();
            Array.Sort<S>(structs);
            stopWatch.Stop();
            Console.WriteLine("Execution time (structs): " + stopWatch.ElapsedMilliseconds + " ms");

        }
    }
}
