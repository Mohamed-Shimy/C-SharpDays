using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day11
{
    class Program
    {
        bool isPrinted = false;

        static void Main(string[] args)
        {
            #region ThreadBasics
            //ThreadStart thStart = Print;
            //Thread th = new Thread(thStart);
            //th.Start();
            ////th.IsBackground = true;
            ////th.Join();
            //Print();
            //for (int i = 0; i < 1000; i++)
            //{
            //    Console.Write("Y");
            //    //if (i == 100)
            //    //    th.Abort();
            //} 
            #endregion

            #region Shared State
            //Program p = new Program();
            //Thread th = new Thread(p.SayHello);

            //th.Start();
            //p.SayHello(); 
            #endregion

            #region Passing parameters & Lambda Expressions
            //Thread th = new Thread(Print);
            //th.Start(1000);

            //Thread th = new Thread(() => Print(1000));
            //th.Start(); 
            #endregion

            #region Exceptions
            //try
            //{
            //    Thread th = new Thread(() => { throw null; });
            //    th.Start();
            //}
            //catch
            //{
            //    Console.WriteLine("Error");
            //} 
            #endregion

            #region Priority
            //Thread th = new Thread(() => { });
            //th.Priority = ThreadPriority.AboveNormal; 
            #endregion

            #region Thread Pool & Task
            //ThreadPool.QueueUserWorkItem(new WaitCallback(Print), null);
            //Task.Factory.StartNew(() => Print());
            //Task t = Task.Run(() => Print());
            //t.Wait(1000);



            //Task<int> t = Task.Run(() => { Print(); return 3; });
            ////t.Wait(1000);

            //t.GetAwaiter().OnCompleted(() => TaskFinished(t));

            //Console.WriteLine("Hello");
            //Console.ReadLine(); 
            #endregion

            
        }

        async static void DoWork()
        {
            //Task<int> t = Print();
            //int x = t.Result;

            int x = await Print();
            Console.WriteLine(x);
        }

        static void TaskFinished(Task<int> t)
        {
            Console.WriteLine("Finished");
            int x = t.Result;
            Console.WriteLine(x);
        }

        public void SayHello()
        {
            if (!isPrinted)
            {
                Console.WriteLine("Hello");
                isPrinted = true;
            }
        }

        static void Print(int count)
        {
            for (int i = 0; i < count; i++)
            {
                //Thread.Sleep(1000);
                Console.Write("X");
            }
        }

        static Task<int> Print()
        {
            return Task.Run<int>(() =>
            {
                int i;
                for (i = 0; i < 1000; i++)
                {
                    //Thread.Sleep(1000);
                    Console.Write("X");
                }
                return i;
            });

        }
    }
}
