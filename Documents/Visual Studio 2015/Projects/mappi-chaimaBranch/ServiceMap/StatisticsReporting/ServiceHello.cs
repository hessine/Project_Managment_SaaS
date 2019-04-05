using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMap.StatisticsReporting
{
    public class ServiceHello
    {
        public string mapsPage()
        {
            System.Net.WebClient client = new System.Net.WebClient();
            string page = client.DownloadString("http://maps.google.com/maps?q=" + "Tunis");
            return page;
        }
    }
}
