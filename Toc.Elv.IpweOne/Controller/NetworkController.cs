using System;
using System.Net;
using System.Xml;

namespace Toc.Elv.IpweOne.Controller
{
    public class NetworkController
    {
        private readonly WebClient client;
        private readonly string fullAddress;

        public NetworkController(string fullAddress)
        {
            client = new WebClient();
            this.fullAddress = fullAddress;
        }

        public XmlDocument GetHtmlDataTable()
        {
            string html = client.DownloadString(fullAddress);

            html = ExtractDataTable(html);
            var xml = ConvertToXml(html);

            return xml;
        }

        private string ExtractDataTable(string rawHtml)
        {
            int start =
                rawHtml.IndexOf("form", StringComparison.Ordinal);
            start = start - 1;

            int end = rawHtml.IndexOf("/form", StringComparison.Ordinal);
            end = end + 6;

            string form = rawHtml.Substring(start, end - start);

            start = form.IndexOf("table", StringComparison.Ordinal);
            start = start - 1;

            end = form.IndexOf("/table", StringComparison.Ordinal);
            end = end + 7;

            string table = form.Substring(start, end - start);

            return table.Replace("<br>", string.Empty);
        }

        private XmlDocument ConvertToXml(string dataTable)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(dataTable);

            return xml;
        }
    }
}
