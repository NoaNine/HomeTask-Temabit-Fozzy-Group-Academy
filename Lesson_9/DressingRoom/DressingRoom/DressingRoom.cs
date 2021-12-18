using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressingRoom
{
    class Clothing
    {
        public string Name { get; set; }
    }
    class DressingRoom
    {
        private const byte _timeClose = 19;
        private const byte _timeOpen = 10;
        private Random rnd = new Random();
        public Clothing[] clothings;
        public DressingRoom(int quantity)
        {
            clothings = new Clothing[quantity];
        }
        public Clothing this[int index]
        {
            get
            {
                int i = rnd.Next(24);
                if (i<_timeClose && i>_timeOpen)
                    return clothings[index];
                else return null;
            }
            set
            {
                int i = rnd.Next(24);
                if (i < _timeClose && i > _timeOpen)
                    clothings[index] = value;
                else clothings[index] = null;
            }
        }
    }
}
