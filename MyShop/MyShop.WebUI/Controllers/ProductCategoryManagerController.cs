using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.DataAccess.InMemory;
using MyShop.Core.Models;

namespace MyShop.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        InMemoryRepository<ProductCategory> context;

        public ProductCategoryManagerController()
        {
            context = new InMemoryRepository<ProductCategory>();
        }

        // GET: ProductCategory
        public ActionResult Index()
        {
            List<ProductCategory> categories = context.Collection().ToList<ProductCategory>();
            return View(categories);
        }

        public ActionResult Create()
        {
            ProductCategory category = new ProductCategory();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductCategory catergory)
        {
            if (!ModelState.IsValid)
            {
                return View(catergory);
            }
            else
            {
                context.Insert(catergory);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string ID)
        {
            ProductCategory catergoryToEdit = context.Find(ID);
            if (catergoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(catergoryToEdit);
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory category, string ID)
        {
            ProductCategory categoryToEdit = context.Find(ID);
            if (categoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(category);
                }
                    categoryToEdit.Category = category.Category;

                    context.Commit();
                    return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string ID)
        {
            ProductCategory categoryToDelete = context.Find(ID);
            if (categoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(categoryToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string ID)
        {
            ProductCategory categoryToDelete = context.Find(ID);
            if (categoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(ID);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}