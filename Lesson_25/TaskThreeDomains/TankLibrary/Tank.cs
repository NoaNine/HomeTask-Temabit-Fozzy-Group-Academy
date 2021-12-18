using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankLibrary
{
    public class Tank : MarshalByRefObject
    {
        public void Attack()
        {
            Console.WriteLine("Shot");
        }
    }
}
