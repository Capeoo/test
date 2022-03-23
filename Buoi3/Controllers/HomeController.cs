using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buoi3.Models;
using PagedList;

namespace Buoi3.Controllers
{
    public class HomeController : Controller
    {
        Model1 context = new Model1();

        public ActionResult Index(int ? page)
        {
            if (page == null) page = 1;
            var all_sach = (from s in context.Saches select s).OrderBy(m => m.masach);
            int pageSize = 6;
            int pageNum = page ?? 1;

            return View(all_sach.ToPagedList(pageNum, pageSize));
        }
    }
}