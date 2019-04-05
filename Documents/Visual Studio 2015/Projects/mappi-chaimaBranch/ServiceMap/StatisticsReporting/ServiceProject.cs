using DataMap.Infrastructure;
using DomainMap.Entities;

using HtmlAgilityPack;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace ServiceMap.StatisticsReporting
{
   public  class ServiceProject : ServicePattern<Project>, IServiceProject
    {

        private static IDatabaseFactory dbFac = new DatabaseFactory();
        private static IUnitOfWork wow = new UnitOfWork(dbFac);

        public ServiceProject() : base(wow)
        {
        }

        public IEnumerable<Project> mapTaux()
        {
            IEnumerable<Project> listprojects = new List<Project>();
            listprojects = GetAll().ToList();

            List<Project> r = new List<Project>();


            foreach (var item in listprojects)
            {
                DateTime date = DateTime.Now;
                TimeSpan diff = date - item.DateBegin;
                double totaldaypasse = diff.TotalDays;

                TimeSpan diff2 = item.DateEnd - item.DateBegin;
                double periodOfproject = diff2.TotalDays;


                double cout = (totaldaypasse / periodOfproject) * 100;

                var address = item.Address;

                //var locationService = new GoogleGeocoder();
                //var point = locationService.GetLatLongFromAddress(address);

                //var latitude = point.Latitude;
                //var longitude = point.Longitude;


                //string requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(address));

                //WebRequest request = WebRequest.Create(requestUri);
                //WebResponse response = request.GetResponse();
                //XDocument xdoc = XDocument.Load(response.GetResponseStream());

                //XElement result = xdoc.Element("GeocodeResponse").Element("result");
                //XElement locationElement = result.Element("geometry").Element("location");
                //XElement lat = locationElement.Element("lat");
                //XElement lng = locationElement.Element("lng");

                //var latitude = (double)lat;
                //var longitude = (double)lng;


                //string results = "";
                //string key = "ArUsb0vVe1s6cgpfxhnfsQHr8U9d7IDOrMikQMtLT7LUTVDPeQ0gvfXWLr8TKRC0";
                //GeocodeRequest geocodeRequest = new GeocodeRequest();

                //// Set the credentials using a valid Bing Maps key
                //geocodeRequest.Credentials = new GeocodeService.Credentials();
                //geocodeRequest.Credentials.ApplicationId = key;

                //// Set the full address query
                //geocodeRequest.Query = address;

                //// Set the options to only return high confidence results 
                //ConfidenceFilter[] filters = new ConfidenceFilter[1];
                //filters[0] = new ConfidenceFilter();
                //filters[0].MinimumConfidence = GeocodeService.Confidence.High;

                //// Add the filters to the options
                //GeocodeOptions geocodeOptions = new GeocodeOptions();
                //geocodeOptions.Filters = filters;
                //geocodeRequest.Options = geocodeOptions;

                //// Make the geocode request
                //GeocodeServiceClient geocodeService = new GeocodeServiceClient();
                //GeocodeResponse geocodeResponse = geocodeService.Geocode(geocodeRequest);

                //if (geocodeResponse.Results.Length > 0)
                //{
                //    results = String.Format("Latitude: {0}\nLongitude: {1}",
                //      geocodeResponse.Results[0].Locations[0].Latitude,
                //      geocodeResponse.Results[0].Locations[0].Longitude);
                //    var latitude = geocodeResponse.Results[0].Locations[0].Latitude;
                //    var longitude = geocodeResponse.Results[0].Locations[0].Longitude;
                //}

                //else
                //    results = "No Results Found";


                //var xml = XDocument.Load(@"D:\geo.xml"); // or from stream or wherever

                //XNamespace ns = "http://schemas.microsoft.com/search/local/ws/rest/v1";
                //var points = (from p in xml.Descendants(ns + address)
                //              select new
                //              {
                //                  Lat = (double)p.Element(ns + "Latitude"),
                //                  Long = (double)p.Element(ns + "Longitude")


                //              })
                //               .ToList();

                // string lat = "";
                // string lng = "";



                // try
                // {
                //     System.Net.WebClient client = new System.Net.WebClient();
                //     string page = client.DownloadString("http://maps.google.com/maps?q=" + address);
                //     int begin = page.IndexOf("markers: [");
                //     string str = page.Substring(begin);
                //     int end = str.IndexOf(",image:");
                //     str = str.Substring(0, end);

                //     //Parse out Latitude
                //     lat = str.Substring(str.IndexOf(",lat: ") + 6);
                //     lat = lat.Substring(0, lat.IndexOf(",lng: "));
                //     //Parse out Longitude
                //     lng = str.Substring(str.IndexOf(",lng: ") + 6);




                // }
                //catch { Console.WriteLine("ok"); }


                List<String> str = new List<string>();
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load("https://www.google.com/maps/search/" + address);
                var Path = doc.DocumentNode.SelectNodes("//meta").ToList();

                for (var i = 0; i < Path.LongCount(); i++)
                {
                    HtmlAttribute pathatt = Path[i].Attributes["property"];
                    if (pathatt != null)
                    {
                        if (pathatt.Value == "og:image")
                        {
                            HtmlAttribute secondpath = Path[i].Attributes["content"];

                            String loong = secondpath.Value.Substring(50, 8).ToString();
                            String lat = secondpath.Value.Substring(64, 8).ToString();

                            str.Add(loong);
                            str.Add(lat);


                        }

                    }
                }

                String looooo = "";
                String laaaaat = "";

                Debug.WriteLine(str);

                looooo = str[0];
                laaaaat = str[1];
                Debug.WriteLine(looooo);
                Debug.WriteLine(laaaaat);



                    r.Add(new Project
                    {

                        ProjectId = item.ProjectId,
                        Name = item.Name,
                        Address = item.Address,
                        //latitude = looooo ,
                        //longitude = laaaaat,
                        //TauxDavancement = cout


                    });

                }
                return r;

            
        }


        //Service permet de retourner le nombre des projets
        public int NombreOfProjects()
        {
            return GetAll().Count();
        }
    }
}
