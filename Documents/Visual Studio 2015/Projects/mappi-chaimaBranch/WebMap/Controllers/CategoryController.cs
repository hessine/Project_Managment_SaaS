using DomainMap.Entities;
using ServiceMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMap.Models;

namespace WebMap.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService ICS;
        public CategoryController()
        {
            ICS = new CategoryService();
        }
        // GET: Category
        public ActionResult Index()
        {
            List<CategoryVM> listC = new List<CategoryVM>();
            foreach (var item in ICS.GetMany())
            {
                CategoryVM Cvm = new CategoryVM();

                Cvm.CatId = item.CatId;
                Cvm.CatName = item.CatName;
                

                listC.Add(Cvm);

            }

            return View(listC);

        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var C = ICS.GetById(id);
            CategoryVM vm = new CategoryVM();

            vm.CatId = C.CatId;
            vm.CatName = C.CatName;


            return View(vm);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            List<CategoryVM> lists = new List<CategoryVM>();
            foreach (var item in ICS.GetAll())
            {
                CategoryVM cvm = new CategoryVM();
                cvm.CatId = item.CatId;
                cvm.CatName = item.CatName;
                



                lists.Add(cvm);

            }
            return View(lists);

        }
        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryVM cvm)
        {
            Category c = new Category();
            c.CatId = cvm.CatId;
            
            c.CatName = cvm.CatName;

            
            ICS.Add(c);
            ICS.Commit();
            return RedirectToAction("Index");
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var c = ICS.GetById(id);
            CategoryVM cvm = new CategoryVM();
            cvm.CatId = c.CatId;
            cvm.CatName = c.CatName;
            
            return View(cvm);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategoryVM cvm)
        {
            Category c = ICS.GetById(id);
            c.CatName = cvm.CatName;
           

            ICS.Update(c);
            ICS.Commit();

            return RedirectToAction("Index");
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var c = ICS.GetById(id);
            CategoryVM cvm = new CategoryVM();
            cvm.CatId = c.CatId;
            cvm.CatName = c.CatName;
            
            return View(cvm);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CategoryVM cvm)
        {
            Category c = ICS.GetById(id);
            c.CatName = cvm.CatName;
            
            ICS.Delete(c);
            ICS.Commit();

            return RedirectToAction("Index");
        }
    }
}
