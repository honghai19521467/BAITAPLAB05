using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TH05.Models;

namespace TH05.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVienController
        public ActionResult Index()
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(DataContext)) as DataContext;
            ViewBag.dsNV = context.layNhanVien();
            return View();
        }
        



    }
}
