namespace Toc.Elv.IpweOne.Models
{
    /// <summary>
    /// Types of ipwe sensors.
    /// </summary>
    public enum SensorTypes
    {
        /// <summary>
        /// Sensor has only temperature data.
        /// </summary>
        Thermometer,

        /// <summary>
        /// Sensor has temperature and humidity data.
        /// </summary>
        ThermoHygrometer,

        /// <summary>
        /// Sensor has temperature, humidity, windspeed and rain data.
        /// </summary>
        KombiSensor
    }

    /// <summary>
    /// An ipwe sensor.
    /// </summary>
    public class IpweSensor
    {
        /// <summary>
        /// Gets or sets the ipwe sensor address. 
        /// </summary>
        public int Address { get; set; }

        /// <summary>
        /// Gets or sets the name of the sensor.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the sensor.
        /// </summary>
        public SensorTypes Type { get; set; }

        /// <summary>
        /// Gets or sets the current temperature.
        /// </summary>
        public double Temperature { get; set; }

        /// <summary>
        /// Gets or sets the current humidity.
        /// </summary>
        public double? Humidity { get; set; }

        /// <summary>
        /// Gets or sets the current windspeed.
        /// </summary>
        public double? Windspeed { get; set; }

        /// <summary>
        /// Gets or sets the percipitation amound over the last 24 hours.
        /// </summary>
        public double? Percipitation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it is currently raining or not.
        /// </summary>
        public bool? IsRaining { get; set; }
    }
}
