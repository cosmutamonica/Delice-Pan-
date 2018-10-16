using Microsoft.AspNet.Identity;
using Suporteri.DataAccessLayer;
using Suporteri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Suporteri.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        [Authorize(Roles = "Admin")]
        public ActionResult GetOrderByAdmin()
        {
            List<Order> list = new OrderDAL().GetNextOrders();

            return View(list);
        }

        // GET All Order
        [Authorize(Roles = "Admin")]
        public ActionResult GetAllOrders()
        {
            List<Order> list = new OrderDAL().GetAllOrders();

            return View("GetOrderByAdmin", list);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            List<Product> list = new ProductDAL().GetProductList();
            foreach (var prod in list)
            {
                if (prod.ImagePath != null)
                {
                    prod.ImagePath = "/Images/2" + prod.ImagePath.Split('/').Last();
                }
            }
            ViewBag.Products = list;
            ProductionVModel production = new ProductionVModel();
            return View(production);            
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(int quantity, int productId)
        {
            try
            {
                if (quantity > 0)
                {
                    var userId = User.Identity.GetUserId();
                    //new OrderDAL().Add(productId, quantity, userId);
                }
                return Json(new { success = true });
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
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

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
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
