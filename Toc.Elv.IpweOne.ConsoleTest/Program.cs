using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toc.Elv.IpweOne.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IpweDevice ipwe = new IpweDevice("http://192.168.1.20");

            var data = ipwe.GetSensors();
        }
    }
}
