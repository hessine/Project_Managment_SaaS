using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebMap.Models;
using ServiceMap.StatisticsReporting;
using DomainMap.Entities;
using System.Web.Script.Serialization;
using System.Diagnostics;

namespace WebMap.Controllers
{
    public class StatisticsConsumeController : Controller
    {

        //Cette méthode permet de consommer les apis qu'on va utiliser dans notre vue statistics
        // GET: StatisticsConsume
      [HttpGet]
      public ActionResult Statistics()
        {
            StatisticsViewModels statistics = new StatisticsViewModels();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:21514/api/");

                //HTTP GET
                //Response Task permet de récupérer depuis l'url (http://localhost:21514/api/nbreProjects)
                var responseTask = client.GetAsync("nbreProjects");
                responseTask.Wait();

                //Response Task permet de récupérer depuis l'url (http://localhost:21514/api/nbreClients)
                var responseTask1 = client.GetAsync("nbreClients");
                responseTask1.Wait();

                //Response Task permet de récupérer depuis l'url (http://localhost:21514/api/nbreResources)
                var responseTask2 = client.GetAsync("nbreResources");
                responseTask2.Wait();

                //Response Task permet de récupérer depuis l'url (http://localhost:21514/api/nbreResources)
                var responseTask3 = client.GetAsync("tauxProgress");
                responseTask3.Wait();

                // Récupérer notre result
                var result = responseTask.Result;
                var result1 = responseTask1.Result;
                var result2 = responseTask2.Result;
                var result3 = responseTask3.Result;

                if (result.IsSuccessStatusCode && result1.IsSuccessStatusCode && result2.IsSuccessStatusCode && result3.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<int>();
                    readTask.Wait();

                    var readTask1 = result1.Content.ReadAsAsync<int>();
                    readTask.Wait();

                    var readTask2 = result2.Content.ReadAsAsync<int>();
                    readTask.Wait();

                   

                    var readTask3 = result3.Content.ReadAsAsync<IEnumerable<Project>>();
                    readTask.Wait();
                    // Stocker notre result
                    statistics.nbProjects = readTask.Result;
                    statistics.nbClients = readTask1.Result;
                    statistics.nbResources = readTask2.Result;
                    statistics.projects = readTask3.Result;
                    Debug.WriteLine(statistics.projects);



                    //var serializedResult = JavaScriptConvert.SerializeObject(readTask3.Result);
                    //statistics.projects = serializedResult;


                }
                else //web api sent error response 
                {
                    //log response status here..

                    

                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(statistics);
        }

 
      

    }
    }
