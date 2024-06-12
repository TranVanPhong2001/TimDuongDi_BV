using System;
using System.Collections.Generic;
using System.Data;
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
        public ActionResult ListKhu()
        {
            var list = db.DuongDis.ToList();
            return View("ListKhu", list);
        }
        public ActionResult Khu(int id)
        {
            var duongDi = db.DuongDis.FirstOrDefault(x => x.id == id);

            if (duongDi != null)
            {

                switch (duongDi.maTang)
                {
                    case 1:
                        ViewBag.Route = duongDi.loTrinh;
                        return RedirectToAction("Tang1", new { id = duongDi.id });
                    case 2:
                        return RedirectToAction("Tang2", new { id = duongDi.id });
                    case 3:
                        return RedirectToAction("Tang3", new { id = duongDi.id });
                    default:
                        // Xử lý trường hợp mã tầng không hợp lệ (nếu cần)
                        return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                // Xử lý trường hợp không tìm thấy DuongDi với id cung cấp (nếu cần)
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult TimLoTrinh(string diemDi, string diemDen, int tang, string diemDenTang2, string diemDenTang3, bool useElevator = false, bool useStairs = false)
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
                              .FirstOrDefault(d => d.diemDi == diemDi && d.diemDen == diemDen && d.maTang == tang);
                
                if (route != null)
                {
                    ViewBag.Route = route.loTrinh;
                }
                else
                {
                    ViewBag.Message = "Không tìm thấy lộ trình 1.";
                    ViewBag.Route = null;
                }
                if (!string.IsNullOrEmpty(diemDenTang2))
                {
                    var routePart1 = db.DuongDis.FirstOrDefault(d => d.diemDi == diemDi && ((useElevator && d.diemDen.Contains("Thang máy (1 đến 3)")) || (useStairs && d.diemDen.Contains("Thang bộ"))) && d.maTang == tang);
                    var routePart2 = db.DuongDis.FirstOrDefault(d => ((useElevator && d.diemDi.Contains("Thang máy (1 đến 3)")) || (useStairs && d.diemDi.Contains("Thang bộ"))) && d.diemDen == diemDenTang2 && d.maTang == 2);
                    if (routePart1 != null && routePart2 != null)
                    {
                        ViewBag.RoutePart1 = routePart1.loTrinh;
                        ViewBag.RoutePart2 = routePart2.loTrinh;
                    }
                    else
                    {
                        ViewBag.Message = "Không tìm thấy lộ trình 2.";
                        ViewBag.RoutePart1 = null;
                        ViewBag.RoutePart2 = null;
                    }
                }

                if (!string.IsNullOrEmpty(diemDenTang3))
                {
                    var routePart1 = db.DuongDis.FirstOrDefault(d => d.diemDi == diemDi && ((useElevator && d.diemDen.Contains("Thang máy (1 đến 3)")) || (useStairs && d.diemDen.Contains("Thang bộ"))) && d.maTang == tang);
                    var routePart2 = db.DuongDis.FirstOrDefault(d => ((useElevator && d.diemDi.Contains("Thang máy (1 đến 3)")) || (useStairs && d.diemDi.Contains("Thang bộ"))) && d.diemDen == diemDenTang3 && d.maTang == 3);
                    if (routePart1 != null && routePart2 != null)
                    {
                        ViewBag.RoutePart1 = routePart1.loTrinh;
                        ViewBag.RoutePart2 = routePart2.loTrinh;
                    }
                    else
                    {
                        ViewBag.Message = "Không tìm thấy lộ trình 3.";
                        ViewBag.RoutePart1 = null;
                        ViewBag.RoutePart2 = null;
                    }
                }
            }
            ViewBag.DiemDi = diemDi;
            ViewBag.DiemDen = diemDen;
            ViewBag.Tang = tang;
            ViewBag.DiemDenTang2 = diemDenTang2;
            ViewBag.DiemDenTang3 = diemDenTang3;
            ViewBag.UseElevator = useElevator;
            ViewBag.UseStairs = useStairs;
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




    

    
