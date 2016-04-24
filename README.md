# Ipwe
.Net Class Library to read data from the ELV Ip Wetterstation IPWE 1
More information at http://reisch.it/2016/04/24/elv-ipwe-net-reader-library/

## How to use it

```c#
IpweDevice ipwe = new IpweDevice("192.168.1.20");
List<IpweSensor> data = ipwe.GetSensors();
