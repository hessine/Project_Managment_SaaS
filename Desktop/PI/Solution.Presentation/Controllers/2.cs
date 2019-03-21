using Solution.Domain.Entities;
using Solution.Presentation.Models;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{

    public class FilmController : Controller
    {
        IFilmService MyFilmService;


        public FilmController()
        {
            MyFilmService = new FilmService();
        }
        // GET: Film affichage sanscherche 
        public ActionResult Index1()
        {
            {
                var Films = new List<FilmVm>();


                foreach (Film f in MyFilmService.GetMany())
                {
                    Films.Add(new FilmVm()
                    {
                        Titre = f.Titre,
                        Description = f.Description,
                       /// GenreVm = f.Genre,
                        ImageUrl = f.ImageUrl,
                        OutDate = f.OutDate,
                       // ProducerId = f.ProducerId

                    });
                }
                return View(Films);
            }
        }
        //get affichage avec recherche avancer 
        public ActionResult Index(string ch)
        {
            {
                var Films = new List<FilmVm>();


                foreach (Film f in MyFilmService.Searchfilm(ch))
                {
                    Films.Add(new FilmVm()
                    {
                        Titre = f.Titre,
                        Description = f.Description,
                        GenreVm =(GenreVm)f.Genre,
                        ImageUrl = f.ImageUrl,
                        OutDate = f.OutDate,
                        // ProducerId = f.ProducerId

                    });
                }
                return View(Films);
            }
        }



        // GET: Film/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Film/Create
        public ActionResult Create()
        {
            return View();
        }





        // POST: Film/Create
        [HttpPost]
        public ActionResult Create(FilmVm FilmVM, HttpPostedFileBase image)
        {
           
            Film FilmDomain = new Film()
            {
                Description = FilmVM.Description,
                Genre = (Genre)FilmVM.GenreVm,
                OutDate = FilmVM.OutDate,
                Titre = FilmVM.Titre,
                ImageUrl = image.FileName,

                //ProducerId = FilmVM.ProducerId
            };
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), image.FileName);
            image.SaveAs(path);
            MyFilmService.Add(FilmDomain);
            MyFilmService.Commit();
            //ajout de l'image dans un dossier Upload
            

            //redirection to nom de la fonction
            return RedirectToAction("Index");
        }




        // GET: Film/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Film/Edit/5
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

        // GET: Film/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Film/Delete/5
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
