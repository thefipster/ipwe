using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Toc.Elv.IpweOne.Controller;
using Toc.Elv.IpweOne.Models;

namespace Toc.Elv.IpweOne
{
    public class IpweDevice
    {
        private readonly string ipAddress;

        public IpweDevice(string ip)
        {
            if (!ip.Contains("ipwe.cgi"))
            {
                ip = string.Concat(ip, "/ipwe.cgi");
            }

            if (!ip.Contains("http"))
            {
                ip = string.Concat("http://", ip);
            }

            ipAddress = ip;
        }

        public string IpAddress => ipAddress;

        public IpweSensor GetSensor(int address)
        {
            if (address < 0 || address > 8)
            {
                throw new ArgumentException("Only addresses between 0 and 8 are allowed.", "address");
            }

            try
            {
                return GetSensors().FirstOrDefault(x => x.Address == address);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<IpweSensor> GetSensors()
        {
            NetworkController networkController = new NetworkController(ipAddress);
            DataConverter dataConverter = new DataConverter();

            XmlDocument xmlData = networkController.GetHtmlDataTable();
            List<IpweSensor> sensors = dataConverter.ConvertXmlToObject(xmlData);

            return sensors;
        }
    }
}
