using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TH05.Models;

namespace TH05.Controllers
{
    public class NV_BTController : Controller
    {
        public IActionResult Fixed()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Fixed(string solansua)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(DataContext)) as DataContext;
            ViewData["list"] = context.lietke(solansua);
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LietKe(string manhanvien)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(DataContext)) as DataContext;
            ViewBag.dsNVBT = context.layNVBT(manhanvien);
            return View();
        }


        // POST: HomeController1/Delete/5

        public ActionResult Delete(string MaThietBi, string MaCanHo, string MaNhanVien, int LanThu)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(DataContext)) as DataContext;
            if (context.xoaNVBT(MaThietBi,MaCanHo,MaNhanVien,LanThu) != 0)
            {
                return RedirectToAction("LietKe");
            }
            return RedirectToAction("LietKe");
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(string MaThietBi, string MaCanHo, string MaNhanVien, int LanThu, DateTime NgayBaoTri)
        {
            NV_BT nvbt = new NV_BT(MaNhanVien, MaCanHo, MaThietBi, LanThu, NgayBaoTri);
            return View(nvbt);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Edit(NV_BT nv)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(DataContext)) as DataContext;
            if (context.capNhatNVBT(nv) != 0)
            {
                return "cập nhật thành công";
            }
            return "thất bại";
        }
    }
}
