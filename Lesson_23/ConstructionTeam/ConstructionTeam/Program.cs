using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConstructionTeam
{
    class StoolMaker
    {
        public void CollectStool(object state, bool timedOut)
        {
            Console.WriteLine("Stool assembled");
        }
    }
    class Hammerer
    {
        public void HammerNail(object state, bool timedOut)
        {
            Console.WriteLine("\t\tNail beaten");
        }
    }
    class StoneMason
    {
        public void LayBrick(object state, bool timedOut)
        {
            Console.WriteLine("\tBrick laid");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StoneMason stoneMason = new StoneMason();
            StoolMaker stoolMaker = new StoolMaker();
            Hammerer hammerer = new Hammerer();

            //AutoResetEvent autoResetEvent1 = new AutoResetEvent(false);
            //AutoResetEvent autoResetEvent2 = new AutoResetEvent(false);
            //AutoResetEvent autoResetEvent3 = new AutoResetEvent(false);
            AutoResetEvent[] autoResetEvent = new AutoResetEvent[]
            {
                new AutoResetEvent(false),
                new AutoResetEvent(false),
                new AutoResetEvent(false)
            };

            WaitOrTimerCallback callbackStoolMaker = new WaitOrTimerCallback(stoolMaker.CollectStool);
            WaitOrTimerCallback callbackHammerer = new WaitOrTimerCallback(hammerer.HammerNail);
            WaitOrTimerCallback callbackStoneMason = new WaitOrTimerCallback(stoneMason.LayBrick);

            RegisteredWaitHandle handleStoolMaker = ThreadPool.RegisterWaitForSingleObject(autoResetEvent[0], callbackStoolMaker, null, 5000, false);
            RegisteredWaitHandle handleHammerer = ThreadPool.RegisterWaitForSingleObject(autoResetEvent[1], callbackHammerer, null, 1500, false);
            RegisteredWaitHandle handleStoneMason = ThreadPool.RegisterWaitForSingleObject(autoResetEvent[2], callbackStoneMason, null, 3000, false);
            while (true)
            {
                string operation = Console.ReadKey(true).KeyChar.ToString().ToUpper();

                if (operation == "S")
                {
                    autoResetEvent[0].Set();
                }
                if (operation == "K")
                {
                    autoResetEvent[1].Set();
                }
                if (operation == "G")
                {
                    autoResetEvent[2].Set();
                }
                if (operation == "Q")
                {
                    handleStoolMaker.Unregister(autoResetEvent[0]);
                    handleHammerer.Unregister(autoResetEvent[1]);
                    handleStoneMason.Unregister(autoResetEvent[2]);
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
