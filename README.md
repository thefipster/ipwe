# Ipwe
.Net Class Library to read data from the ELV Ip Wetterstation IPWE 1

## How to use it

```c#
IpweDevice ipwe = new IpweDevice("192.168.1.20");
List<IpweSensor> data = ipwe.GetSensors();
