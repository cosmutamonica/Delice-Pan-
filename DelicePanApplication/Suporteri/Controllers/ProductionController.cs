using Suporteri.DataAccessLayer;
using Suporteri.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Suporteri.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductionController : Controller
    {
        // GET: Category
        public ActionResult DailyProduction()
        {
            List<ProductionVModel> list = new ProductionDAL().GetDailyProduction();

            return View(list);
        }

        // GET: Category/Create
        public ActionResult AddProduction()
        {
            List<Product> list = new ProductDAL().GetProductList();
            foreach (var prod in list)
            {
                if (prod.ImagePath != null)
                {
                    //WebImage img = new WebImage(Server.MapPath(prod.ImagePath));
                    //if (img.Width > 300 || img.Height > 200)
                    //    img.Resize(300, 200);
                    //img.Save(HttpContext.Server.MapPath("~/Images/")+"2" +prod.ImagePath.Split('/').Last());
                    prod.ImagePath = "/Images/2" + prod.ImagePath.Split('/').Last();
                }
            }
            ViewBag.Products = list;
            ProductionVModel production = new ProductionVModel();
            return View(production);
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult AddProduction(int quantity, int productId)
        {
            try
            {
                if (quantity > 0)
                {
                    new ProductionDAL().Add(productId, quantity);
                }
                return Json(new { success = true });
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            ProductionVModel prod = new ProductionDAL().GetCustomProductionById(id);
            prod.ImagePath = "/Images/2" + prod.ImagePath.Split('/').Last();
            return View(prod);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductionVModel production)
        {
            try
            {
                new ProductionDAL().EditProduction(production);
                return RedirectToAction("DailyProduction");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            ProductionVModel prod = new ProductionDAL().GetCustomProductionById(id);
            prod.ImagePath = "/Images/2" + prod.ImagePath.Split('/').Last();
            return View(prod);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ProductionVModel production)
        {
            try
            {
                new ProductionDAL().DeleteProductionById(id);
                return RedirectToAction("DailyProduction");
            }
            catch
            {
                return View();
            }
        }
    }
}
