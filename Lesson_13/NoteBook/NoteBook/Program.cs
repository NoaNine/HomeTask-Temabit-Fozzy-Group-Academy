using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook
{
    class Program
    {
        abstract class BaseFormat
        {

        }
        class OldFormat : BaseFormat
        {

        }
        class NewFormat : OldFormat
        {

        }
        abstract class CPU
        {

        }
        class ICore3
        {

        }
        class ICore5 : ICore3
        {

        }
        abstract class RAM
        {

        }
        class DDR3
        {

        }
        class DDR4 : DDR3
        {

        }
        interface ITransferDataWifi<out Type>
        {
            Type TransferDataWifi();
        }
        interface ITransferDataBlueTooth<out Type>
        {
            Type TransferDataBlueTooth();
        }
        interface IUpgradebleCPU<in CPU>
        {
            void UpgradeCPU(CPU cpu);
        }
        interface IUpgradebleRam<in RAM>
        {
            void UpgradeRam(RAM ram);
        }    
        public class NoteBook<Type, CPU, RAM> : ITransferDataWifi<Type>, ITransferDataBlueTooth<Type>, IUpgradebleCPU<CPU>, IUpgradebleRam<RAM>
        {
            public Type WifiData { get; private set; }
            public Type BlueToothData { get; private set; }
            public CPU Cpu { get; private set; }
            public RAM Ram { get; private set; }
            public NoteBook(Type data, CPU cpu, RAM ram)
            {
                WifiData = data;
                BlueToothData = data;
                Cpu = cpu;
                Ram = ram;
            }
            public Type TransferDataWifi()
            {
                Console.WriteLine(WifiData);
                return WifiData;
            }
            public Type TransferDataBlueTooth()
            {
                Console.WriteLine(BlueToothData);
                return BlueToothData;
            }
            public void UpgradeCPU(CPU cpu)
            {
                Cpu = cpu;
            }
            public void UpgradeRam(RAM ram)
            {
                Ram = ram;
            }
            public void PrintInfo()
            {
                Console.WriteLine(Cpu);
                Console.WriteLine(Ram);
            }
        }
        static void Main(string[] args)
        {
            NoteBook<OldFormat, ICore3, DDR3> noteBook = new NoteBook<OldFormat, ICore3, DDR3>(new OldFormat(), new ICore3(), new DDR3());
            noteBook.PrintInfo();
            IUpgradebleCPU<ICore5> newCPUNoteBook = noteBook;
            IUpgradebleRam<DDR4> newRamNoteBook = noteBook;
            newCPUNoteBook.UpgradeCPU(new ICore5());
            newRamNoteBook.UpgradeRam(new DDR4());
            noteBook.PrintInfo();


            noteBook.TransferDataWifi();
            ITransferDataWifi<BaseFormat> oldTransferDataWifi = noteBook;
            ITransferDataBlueTooth<BaseFormat> oldTransferDataBlueTooth = noteBook;
            oldTransferDataWifi.TransferDataWifi();
            oldTransferDataBlueTooth.TransferDataBlueTooth();
            Console.ReadKey();
        }
    }
}
