using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessChicken
{
    class Chicken
    {
        public void LayEgg(object state)
        {
            Console.WriteLine("Chicken number {0} lay egg", Thread.CurrentThread.ManagedThreadId);
        }
    }
    class Cock
    {
        public DateTime dateTimeNow = new DateTime(2021, 2, 16, 12, 30, 0);
        public DateTime dateTimeStartWork = new DateTime(2021, 2, 16, 5, 0, 0);
        public DateTime dateTimeStopWork = new DateTime(2021, 2, 16, 16, 0, 0);
        public bool State = false;
        public void Check(object state)
        {
            if ((dateTimeStartWork < dateTimeNow) && (dateTimeStopWork > dateTimeNow))
            {
                SignalWork();
                State = true;
            }
            else
            {
                ShutdownSignal();
                State = false;
            }
        }
        public void SignalWork()
        {
            Console.WriteLine("Time to wokr chicken, go to lay eggs");
        }
        public void ShutdownSignal()
        {
            Console.WriteLine("Stop lay eggs, time to sleep");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Cock cock = new Cock();

            TimerCallback timerCallback = new TimerCallback(cock.Check);
            AutoResetEvent autoResetEvent = new AutoResetEvent(false);

            Random random = new Random();
            var timer = new List<Timer>();
            Timer timerCheck = new Timer(timerCallback, autoResetEvent, 0, 1000);
            for (int i = 0; i < 3; i++)
            {
                timer.Add(new Timer(timerCallback, autoResetEvent, 0, random.Next(1000, 5000)));
            }
            Console.ReadKey();
        }
    }
}
