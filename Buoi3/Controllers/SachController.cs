using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buoi3.Models;

namespace Buoi3.Controllers
{
    public class SachController : Controller
    {
        // GET: Sach
        Model1 context = new Model1();
        public ActionResult ListSach()
        {
            var all_theloai = from tt in context.Saches select tt;
            return View(all_theloai.ToList());
        }

        //-------------Detail-------------------

        public ActionResult Detail(int id)
        {
            var D_sach = context.Saches.Where(m => m.masach == id).First();
            return View(D_sach);
        }
        //-------------Create-------------------
        public ActionResult Create()
        {
            ViewBag.Theloai = context.TheLoais.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, Sach sach)
        {
            var E_tensach = collection["tensach"];
            var E_hinh = collection["hinh"];
            var E_giaban = Convert.ToDecimal(collection["giaban"]);
            var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycapnhat"]);
            var E_soluongton = Convert.ToInt32(collection["soluongton"]);
            if (string.IsNullOrEmpty(E_tensach))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                sach.tensach = E_tensach.ToString();
                sach.hinh = E_hinh.ToString();
                sach.giaban = E_giaban;
                sach.ngaycapnhat = E_ngaycapnhat;
                sach.soluongton = E_soluongton;
                context.Saches.Add(sach);
                context.SaveChanges();
                return RedirectToAction("ListSach");
            }
            return this.Create();
        }
        //-------------Edit-------------------
        public ActionResult Edit(int id)
        {
            ViewBag.Theloai = context.TheLoais.ToList();
            var E_category = context.Saches.First(m => m.masach == id);
            return View(E_category);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_sach = context.Saches.First(m => m.masach == id);
            var E_tensach = collection["tensach"];
            var E_hinh = collection["hinh"];
            var E_giaban = Convert.ToDecimal(collection["giaban"]);
            var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycatnhat"]);
            var E_soluongton = Convert.ToInt32(collection["soluongton"]);
            E_sach.masach = id;
            if (string.IsNullOrEmpty(E_tensach))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_sach.tensach = E_tensach;
                E_sach.hinh = E_hinh;
                E_sach.giaban = E_giaban;
                E_sach.ngaycapnhat = E_ngaycapnhat;
                E_sach.soluongton = E_soluongton;
                UpdateModel(E_sach);
                context.SaveChanges();
                return RedirectToAction("ListSach");
            }
            return this.Edit(id);
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }
        //-------------Delete-------------------
        public ActionResult Delete(int id)
        {
            var D_sach = context.Saches.FirstOrDefault(m => m.masach == id);
            return View(D_sach);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_sach = context.Saches.Where(m => m.maloai == id).First();
            context.Saches.Remove(D_sach);
            context.SaveChanges();
            return RedirectToAction("ListSach");
        }
    }
}