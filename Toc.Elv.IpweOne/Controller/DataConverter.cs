using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Toc.Elv.IpweOne.Controller
{
    using Models;
    using System.Globalization;

    /// <summary>
    /// Converts the xml data of the network controller to an object model.
    /// </summary>
    public class DataConverter
    {
        public List<IpweSensor> ConvertXmlToObject(XmlDocument xmlData)
        {
            XmlNodeList node = xmlData.GetElementsByTagName("tr");

            List<IpweSensor> sensors = new List<IpweSensor>();
            for (int i = 1; i < node.Count; i++)
            {
                IpweSensor sensor = new IpweSensor();

                CultureInfo culture = new CultureInfo("en-US");
                string tempString;
                double tempDouble;
                int tempInt = 0;

                tempString = node[i].ChildNodes[1].InnerText;
                if (string.IsNullOrEmpty(tempString) == false && int.TryParse(tempString, out tempInt))
                {
                    sensor.Address = tempInt;
                }
                else
                {
                    if (node[i].ChildNodes[0].InnerText != "Kombi")
                    {
                        continue;
                    }

                    sensor.Address = 8;
                }

                // Name
                sensor.Name = node[i].ChildNodes[2].InnerText;

                // Temperature
                tempString = node[i].ChildNodes[3].InnerText;
                tempString = tempString.Replace(" °C", string.Empty);
                if (double.TryParse(tempString, NumberStyles.Float, culture, out tempDouble))
                {
                    sensor.Temperature = tempDouble;
                    sensor.Type = SensorTypes.Thermometer;
                }

                // Humidity
                tempString = node[i].ChildNodes[4].InnerText;
                tempString = tempString.Replace(" %", string.Empty);
                if (double.TryParse(tempString, NumberStyles.Float, culture, out tempDouble))
                {
                    sensor.Humidity = tempDouble;
                    sensor.Type = SensorTypes.ThermoHygrometer;
                }

                // Windspeed
                tempString = node[i].ChildNodes[5].InnerText;
                tempString = tempString.Replace(" km/h", string.Empty);
                if (double.TryParse(tempString, NumberStyles.Float, culture, out tempDouble))
                {
                    // Convert to si unit m/s
                    tempDouble = tempDouble / 3.6;
                    sensor.Windspeed = tempDouble;
                    sensor.Type = SensorTypes.KombiSensor;
                }

                // Percipitation
                tempString = node[i].ChildNodes[6].InnerText;
                tempString = tempString.Replace(" mm", string.Empty);
                if (string.IsNullOrEmpty(tempString) == false)
                {
                    if (tempString.Contains('#'))
                    {
                        sensor.IsRaining = true;
                    }
                    else
                    {
                        sensor.IsRaining = false;
                    }

                    tempString = tempString.Replace("#", string.Empty);

                    if (double.TryParse(tempString, NumberStyles.Float, culture, out tempDouble))
                    {
                        sensor.Percipitation = tempDouble;
                    }
                }

                sensors.Add(sensor);
            }

            return sensors;
        }
    }
}
