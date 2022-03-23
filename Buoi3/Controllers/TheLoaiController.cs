using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buoi3.Models;

namespace Buoi3.Controllers
{
    public class TheLoaiController : Controller
    {
        // GET: TheLoai
        Model1 context = new Model1();
        public ActionResult Index()
        {
            var all_theloai = from tt in context.TheLoais select tt;
            return View(all_theloai.ToList());
        }

        public ActionResult Detail(int id)
        {
            var D_theloai = context.TheLoais.Where(m => m.maloai == id).First();
            return View(D_theloai);
        }
        //-------------Create-------------------
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, TheLoai tl)
        {
            var ten = collection["tenloai"];
            if (string.IsNullOrEmpty(ten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                tl.tenloai = ten;
                context.TheLoais.Add(tl);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        //-------------Edit-------------------
        public ActionResult Edit(int id)
        {
            var E_category = context.TheLoais.First(m => m.maloai == id);
            return View(E_category);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var theloai = context.TheLoais.First(m => m.maloai == id);
            var E_tenloai = collection["tenloai"];
            theloai.maloai = id;
            if (string.IsNullOrEmpty(E_tenloai))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                theloai.tenloai = E_tenloai;
                UpdateModel(theloai);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        //-------------Delete-------------------
        public ActionResult Delete(int id)
        {
            var D_theloai = context.TheLoais.First(m => m.maloai == id);
            return View(D_theloai);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_theloai = context.TheLoais.Where(m => m.maloai == id).First();
            context.TheLoais.Remove(D_theloai);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}