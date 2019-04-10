
using MVCConsumeWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCConsumeWebApi.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:63238/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("api/RecWebApi").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<ProjectViewModel>>().Result;
            }

            else
            {
                ViewBag.result = "error";

            }
            return View();
        }

        // GET: Reclamation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reclamation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reclamation/Create
        [HttpPost]
        public ActionResult Create(ProjectViewModel pvm)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2212/");
            client.PostAsJsonAsync<ProjectViewModel>("api/RecWebApi", pvm).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");

        }

        // GET: Reclamation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reclamation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reclamation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reclamation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
