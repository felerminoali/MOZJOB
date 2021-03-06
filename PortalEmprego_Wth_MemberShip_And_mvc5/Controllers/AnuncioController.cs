﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PortalEmprego_Wth_MemberShip_And_mvc5.Models;
using PortalEmprego_Wth_MemberShip_And_mvc5.CustomHtmlHelpers;
using System.Text;

namespace PortalEmprego_Wth_MemberShip_And_mvc5.Controllers
{
    public class AnuncioController : Controller
    {
        private PortalEmpregoContextDB db = new PortalEmpregoContextDB();

        // GET: /Anuncio/
        [Authorize]
        public ActionResult Index(string search, int? tipoAnuncio, int? Status, int? Lang, int? Location, int? category)
        {

            ViewBag.Lang = new SelectList(db.languages, "Id", "description");
            ViewBag.Location = new SelectList(db.Locals.Where(x => x.Provincia.HasValue), "Id", "Name");
            ViewBag.created_by = new SelectList(db.Recrutadors, "Id", "Name");
            ViewBag.Modified_by = new SelectList(db.Recrutadors, "Id", "Name");
            ViewBag.Status = new SelectList(db.StatusVagas, "Id", "Status");

            ViewBag.parentCategory = new SelectList(db.Categories.Where(x => !x.CatParent.HasValue), "Id", "Name");
            ViewBag.category = new SelectList(db.Categories.Where(x => x.CatParent.HasValue), "Id", "Name");

            ViewBag.tipoAnuncio = new SelectList(db.TipoAnuncios, "Id", "Name");

                var anuncios = db.Anuncios.Where(
                    x => (x.title.Contains(search) || search == null)
                    && (x.tipoAnuncio == tipoAnuncio || tipoAnuncio == null)
                    && (x.Status == Status || Status == null)
                    && (x.Lang == Lang || Lang == null)
                    && (x.Location == Location || Location == null)
                    && (x.category == category || category == null)
                    ).Include(a => a.language).Include(a => a.Local).Include(a => a.Recrutador).Include(a => a.Recrutador1).Include(a => a.StatusVaga);
                
            return View(anuncios.ToList());
        }

        public JsonResult GetAnuncios(string term)
        { 
            List<string> anuncios = db.Anuncios.Where(s => s.title.StartsWith(term)).Select(x=>x.title).ToList();
            return Json(anuncios, JsonRequestBehavior.AllowGet);
        }

        // GET: /Anuncio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anuncio anuncio = db.Anuncios.Find(id);
            if (anuncio == null)
            {
                return HttpNotFound();
            }
            return View(anuncio);
        }

        public JsonResult GetSubCategory(int CategoryId)
        {
            string code = string.Empty;
            StringBuilder sb = new StringBuilder();


            foreach (var data in db.Categories.Where(cat => cat.CatParent == CategoryId))
            {
                sb.Append("<option value='" + data.Id + "' >" + data.Name + " </option> ");
            }

            return Json(sb.ToString(), JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        [Authorize]
        public ActionResult Cancel() {
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
