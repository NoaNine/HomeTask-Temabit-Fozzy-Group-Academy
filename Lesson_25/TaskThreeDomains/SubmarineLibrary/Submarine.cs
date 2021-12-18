using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmarineLibrary
{
    public class Submarine : MarshalByRefObject
    {
        public void Attack()
        {
            Console.WriteLine("Let out a torpedo");
        }
    }
}
