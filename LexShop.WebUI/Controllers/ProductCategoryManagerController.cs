using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LexShop.DataAccess.InMemory;
using LexShop.Core.Models;

namespace LexShop.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        InMemoryRepository<ProductCategory> context;
        public ProductCategoryManagerController()
        {
            context = new InMemoryRepository<ProductCategory>();
        }

        public ActionResult Index()
        {
            List<ProductCategory> productCategories = context.Collection().ToList();
            return View(productCategories);
        }

        public ActionResult Create()
        {
            ProductCategory productCategory = new ProductCategory();
            return View(productCategory);
        }
        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);
            }
            else
            {
                context.Insert(productCategory);
                context.Commit();
                return RedirectToAction("Index");
            }

        }
        public ActionResult Edit(string Id)
        {
            ProductCategory productCategory = context.Find(Id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategory);
            }
        }
        [HttpPost]
        public ActionResult Edit(ProductCategory product, string Id, string Category)
        {
            ProductCategory productCategoryToEdit = context.Find(Id);
            // Below lines are for understanding purpose:
            System.Diagnostics.Debug.WriteLine("[For understanding purpose] Id = " + Id);
            System.Diagnostics.Debug.WriteLine("[For understanding purpose] product.Id = " + product.Id);
            System.Diagnostics.Debug.WriteLine("[For understanding purpose] Category = " + Category);
            //  End test
            if (productCategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                productCategoryToEdit.Category = product.Category;
                context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string Id)
        {
            ProductCategory productCategoryToDelete = context.Find(Id);
            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategoryToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        /*  Comment out the below line for testing purpose */
        //  public ActionResult ConfirmDelete(string Id) 
        /*  For understanindg ActionName, use an arbitrary function name, say Abc */
        public ActionResult Abc(string Id)
        {
            ProductCategory productCategoryToDelete = context.Find(Id);
            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                return RedirectToAction("Index");
            }
        }
    }
}