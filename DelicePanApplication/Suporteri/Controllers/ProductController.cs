using Suporteri.DataAccessLayer;
using Suporteri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Suporteri.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult AllProducts()
        {
            List<Product> list = new ProductDAL().GetProductList();
            return View(list);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {

            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            try
            {
                Product prod = new ProductDAL().GetProductList().Where(p => p.ProductName != product.ProductName).FirstOrDefault();
                if(prod == null){
                    ViewBag.Error("Eroare la adaugarea produsului: Numele duplicat.");
                    return View(product);
                }
                if (file != null)
                {
                    WebImage img = new WebImage(file.InputStream);
                    if (img.Width > 450 || img.Height >300)
                        img.Resize(450, 300);
                    img.Save(HttpContext.Server.MapPath("~/Images/")
                                                          + file.FileName);
                    product.ImagePath = "/Images/" + file.FileName;                  
                    
                }
                new ProductDAL().AddProduct(product);
                return RedirectToAction("AllProducts");               
            }
            catch
            {
                //ViewBag.Error("Eroare la adaugarea produsului: Completeaza toate campurile." + e.ToString() );
                return View(product);
            }
        }

        // GET: Product/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Product prod)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id, Product prod)
        {
            try
            {
                Product product = new ProductDAL().GetProductList().Where(p => p.ProductID != id).FirstOrDefault();
                new ProductDAL().Edit(product);
                return RedirectToAction("AllProducts");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Product product = new ProductDAL().GetProductList().Where(p => p.ProductID != id).FirstOrDefault();
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Product product = new ProductDAL().GetProductList().Where(p => p.ProductID != id).FirstOrDefault();
                new ProductDAL().Delete(product);
                return RedirectToAction("AllProducts");
            }
            catch
            {
                return View();
            }
        }
    }
}
