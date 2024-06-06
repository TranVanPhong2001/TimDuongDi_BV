using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
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
            PopulateViewBag(1);
            return View();
        }


        public ActionResult Tang2()
        {
            PopulateViewBag(2);
            return View();
        }
        
        
        public ActionResult Tang3()
        {
            PopulateViewBag(3);
            return View();
        }
        [HttpPost]
        public ActionResult TimLoTrinh(string diemDi, string diemDen, int tang, string diemDenTang2, string diemDenTang3)
        {
            
            if (diemDi == diemDen)
            {
                var route = db.DuongDis
                              .FirstOrDefault(d => d.diemDi == diemDi && d.diemDen == diemDen);
                ViewBag.Message = "Bạn đang ở đây";
                ViewBag.Route = route?.loTrinh; // Đường dẫn tới ảnh mặc định của tầng 1
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
            ViewBag.DiemDi = diemDi;
            ViewBag.DiemDen = diemDen;
            ViewBag.Tang = tang;
            PopulateViewBag(tang);
            switch (tang)
            {
                case 2:
                    return View("Tang2");
                case 3:
                    return View("Tang3");
                default:
                    return View("Tang1");
            }

        }
        private void PopulateViewBag(int tang)
        {
            var diemDiList = db.DuongDis
                               .Where(d => d.maTang == tang)
                               .Select(d => d.diemDi)
                               .Distinct()
                               .ToList();

            var diemDenListTang1 = db.DuongDis
                                    .Where(d => d.maTang == 1)
                                    .Select(d => d.diemDen)
                                    .Distinct()
                                    .ToList();

            var diemDenListTang2 = db.DuongDis
                                    .Where(d => d.maTang == 2)
                                    .Select(d => d.diemDen)
                                    .Distinct()
                                    .ToList();

            var diemDenListTang3 = db.DuongDis
                                    .Where(d => d.maTang == 3)
                                    .Select(d => d.diemDen)
                                    .Distinct()
                                    .ToList();

            ViewBag.DiemDiList = diemDiList;
            ViewBag.DiemDenListTang1 = diemDenListTang1;
            ViewBag.DiemDenListTang2 = diemDenListTang2;
            ViewBag.DiemDenListTang3 = diemDenListTang3;
        }
    }
        
}