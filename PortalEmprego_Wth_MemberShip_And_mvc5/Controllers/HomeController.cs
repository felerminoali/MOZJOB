using PortalEmprego_Wth_MemberShip_And_mvc5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PagedList;
using PagedList.Mvc;


using System.Web.Script.Services;
using System.Web.Services;

namespace PortalEmprego_Wth_MemberShip_And_mvc5.Controllers
{
    public class HomeController : Controller
    {
        PortalEmpregoContextDB db = new PortalEmpregoContextDB();
        public ActionResult Index(string returnUrl, int? page, int? checkFilter)
        {
            //ViewBag.ReturnUrl = returnUrl;
            //List<Local> l = db.Locals.Where(x => x.Provincia.HasValue).ToList();

           
            // filtar apenas as navs cadastradas
            var localQuery =
                            (from an in db.Anuncios
                            join lc in db.Locals on an.Location equals lc.Id
                            group new { an,lc} by new {lc.Name, lc.Id} into newt
                            select new { Id = newt.Key.Id, Name = newt.Key.Name, Count = newt.Count() });
            ViewBag.Location = localQuery.ToList<object>();


            // filtrar apenas as categorias
            var categoryQuery = (
                                from an in db.Anuncios
                                join cat in db.Categories on an.category equals cat.Id
                                group new { an, cat } by new { cat.Id, cat.Name } into newt
                                select new { Id = newt.Key.Id, Name = newt.Key.Name, Count = newt.Count()}

                );
            ViewBag.category = categoryQuery.ToList<object>();

            ViewBag.totalAnuncios = db.Anuncios.Count();
            return View(db.Anuncios.ToList().ToPagedList(page ?? 1, 8));
        }

    }
}