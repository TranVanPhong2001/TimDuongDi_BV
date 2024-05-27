using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimDuongDi_BV.Models;

namespace TimDuongDi_BV.Controllers
{
    public class HomeController : Controller
    {
        private Map db = new Map();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Tang1()
        {      
            return View();
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

            return View("Tang1");
        }     

        public ActionResult Tang2()
        {          
            return View();
        }
        [HttpPost]
        public ActionResult Tang2(string diemDi, string diemDen)
        {
            if (diemDi == diemDen)
            {
                ViewBag.Message = "Bạn đang ở đây";
                ViewBag.Route = null; 
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
            }

            return View("Tang2");
        }
        public ActionResult Tang3()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Tang3(string diemDi, string diemDen)
        {
            if (diemDi == diemDen)
            {
                ViewBag.Message = "Bạn đang ở đây";
                ViewBag.Route = null; 
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
            }

            return View("Tang3");
        }
    }
}