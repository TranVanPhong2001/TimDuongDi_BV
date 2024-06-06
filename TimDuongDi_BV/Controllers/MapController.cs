using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimDuongDi_BV.Models;

namespace TimDuongDi_BV.Controllers
{
    [Authorize]
    public class MapController : Controller
    {
        private Map db = new Map();
        // GET: Map
        public ActionResult Index()
        {
            var list = db.DuongDis.ToList();
            return View("Index", list);
        }

        // GET: Map/Details/5
        public ActionResult Khu(int id)
        {
            var vitri = db.DuongDis.FirstOrDefault(x => x.id == id);
            return View("Khu", vitri);
        }
        [HttpPost]
        public ActionResult Tang1(string diemDi, string diemDen)
        {
            if (diemDi == diemDen)
            {
                ViewBag.Message = "Bạn đang ở đây";
                ViewBag.Route = null; // Đường dẫn tới ảnh mặc định của tầng 1
            }
            else
            {
                var route = db.DuongDis
                              .FirstOrDefault(d => d.diemDi == diemDi && d.diemDen == diemDen);

                if (route != null)
                {
                    ViewBag.Route = route.loTrinh;
                }
                else
                {
                    ViewBag.Message = "Không tìm thấy lộ trình.";
                    ViewBag.Route = null;
                }
                ViewBag.DiemDi = diemDi;
                ViewBag.DiemDen = diemDen;

            }

            return View("MapKhu");
        }

        // GET: Map/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Map/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Map/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Map/Edit/5
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

        // GET: Map/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Map/Delete/5
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
