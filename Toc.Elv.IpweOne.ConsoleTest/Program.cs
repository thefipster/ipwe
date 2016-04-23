using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toc.Elv.IpweOne.Models;

namespace Toc.Elv.IpweOne.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IpweDevice ipwe = new IpweDevice("192.168.1.20");
            List<IpweSensor> data = ipwe.GetSensors();
        }
    }
}
