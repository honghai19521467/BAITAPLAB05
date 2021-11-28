using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TH05.Models;

namespace TH05.Controllers
{
    public class CanHoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: CanHoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Create(CanHo ch)
        {
            int count;
            DataContext context = HttpContext.RequestServices.GetService(typeof(DataContext)) as DataContext;
            count = context.taoCanHo(ch);
            if (count == 1)
            {
                return "them thanh cong";
            }
            return "thêm thất bại";
        }
    }
}
