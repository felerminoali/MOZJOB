using System;
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
        public ActionResult Index()
        {
            ViewBag.Lang = new SelectList(db.languages, "Id", "description");
            ViewBag.Location = new SelectList(db.Locals.Where(x => x.Provincia.HasValue), "Id", "Name");
            ViewBag.created_by = new SelectList(db.Recrutadors, "Id", "Name");
            ViewBag.Modified_by = new SelectList(db.Recrutadors, "Id", "Name");
            ViewBag.Status = new SelectList(db.StatusVagas, "Id", "Status");

            ViewBag.parentCategory = new SelectList(db.Categories.Where(x => !x.CatParent.HasValue), "Id", "Name");
            ViewBag.category = new SelectList(db.Categories, "Id", "Name");

            ViewBag.tipoAnuncio = new SelectList(db.TipoAnuncios, "Id", "Name");

            var anuncios = db.Anuncios.Include(a => a.language).Include(a => a.Local).Include(a => a.Recrutador).Include(a => a.Recrutador1).Include(a => a.StatusVaga);
            return View(anuncios.ToList());
        }


        public ActionResult Index1(string search, int? tipoAnuncio, int? Status, int? Lang, int? Location, int? category)
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

        // GET: /Anuncio/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Lang = new SelectList(db.languages, "Id", "description");
            ViewBag.Location = new SelectList(db.Locals.Where(x => x.Provincia.HasValue), "Id", "Name");
            ViewBag.created_by = new SelectList(db.Recrutadors, "Id", "Name");
            ViewBag.Modified_by = new SelectList(db.Recrutadors, "Id", "Name");
            ViewBag.Status = new SelectList(db.StatusVagas, "Id", "Status");

            ViewBag.parentCategory = new SelectList(db.Categories.Where(x => !x.CatParent.HasValue), "Id", "Name");
            ViewBag.category = new SelectList(db.Categories, "Id", "Name");


            ViewBag.tipoAnuncio = new SelectList(db.TipoAnuncios, "Id", "Name");

            return View();
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


        // POST: /Anuncio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="Id,Codigo,title,startPub,finishPub,created,Modified,publish_up,publish_down,UrlImg,Conteudo,created_by,Modified_by,Location,Status,Lang,isFullTime")] Anuncio anuncio)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Anuncios.Add(anuncio);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.Lang = new SelectList(db.languages, "Id", "description", anuncio.Lang);
        //    ViewBag.Location = new SelectList(db.Locals, "Id", "Name", anuncio.Location);
        //    ViewBag.created_by = new SelectList(db.Recrutadors, "Id", "Name", anuncio.created_by);
        //    ViewBag.Modified_by = new SelectList(db.Recrutadors, "Id", "Name", anuncio.Modified_by);
        //    ViewBag.Status = new SelectList(db.StatusVagas, "Id", "Status", anuncio.Status);
        //    return View(anuncio);
        //}

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,title,startPub,finishPub,created,Modified,publish_up,publish_down,UrlImg,Conteudo,created_by,Modified_by,Location,Status,Lang,category,tipoAnuncio")] Anuncio anuncio, string comand)
        {


            if (comand == "Cancel") {
                return RedirectToAction("Index");
            }
            else
            {

                //anuncio.UrlImg = "~/Content/images/img.png";
                if (ModelState.IsValid)
                {
                    db.Anuncios.Add(anuncio);
                    db.SaveChanges();

                    if (comand == "SaveClose")
                    {
                        return RedirectToAction("Index");
                    }
                    else if (comand == "SaveNew")
                    {
                        return RedirectToAction("Create");
                    }

                }

                ViewBag.Lang = new SelectList(db.languages, "Id", "description", anuncio.Lang);
                ViewBag.Location = new SelectList(db.Locals.Where(x => x.Provincia.HasValue), "Id", "Name", anuncio.Location);
                ViewBag.created_by = new SelectList(db.Recrutadors, "Id", "Name", anuncio.created_by);
                ViewBag.Modified_by = new SelectList(db.Recrutadors, "Id", "Name", anuncio.Modified_by);
                ViewBag.Status = new SelectList(db.StatusVagas, "Id", "Status", anuncio.Status);

                ViewBag.parentCategory = new SelectList(db.Categories.Where(x => !x.CatParent.HasValue), "Id", "Name");
                ViewBag.category = new SelectList(db.Categories, "Id", "Name");


                ViewBag.tipoAnuncio = new SelectList(db.TipoAnuncios, "Id", "Name");

                return View(anuncio);

            }
        }


        [HttpGet]
        [Authorize]
        public ActionResult Cancel() {
            return RedirectToAction("Index");
        }


        // GET: /Anuncio/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
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
            ViewBag.Lang = new SelectList(db.languages, "Id", "description", anuncio.Lang);
            ViewBag.Location = new SelectList(db.Locals.Where(x => x.Provincia.HasValue), "Id", "Name");
            ViewBag.created_by = new SelectList(db.Recrutadors, "Id", "Name", anuncio.created_by);
            ViewBag.Modified_by = new SelectList(db.Recrutadors, "Id", "Name", anuncio.Modified_by);
            ViewBag.Status = new SelectList(db.StatusVagas, "Id", "Status", anuncio.Status);

            ViewBag.parentCategory = new SelectList(db.Categories.Where(x => !x.CatParent.HasValue), "Id", "Name");
            ViewBag.category = new SelectList(db.Categories, "Id", "Name");

            ViewBag.tipoAnuncio = new SelectList(db.TipoAnuncios, "Id", "Name");

            return View(anuncio);
        }

        // POST: /Anuncio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Codigo,title,startPub,finishPub,created,Modified,publish_up,publish_down,UrlImg,Conteudo,created_by,Modified_by,Location,Status,Lang,category,tipoAnuncio")] Anuncio anuncio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anuncio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Lang = new SelectList(db.languages, "Id", "description", anuncio.Lang);
            ViewBag.Location = new SelectList(db.Locals.Where(x => x.Provincia.HasValue), "Id", "Name");
            ViewBag.created_by = new SelectList(db.Recrutadors, "Id", "Name", anuncio.created_by);
            ViewBag.Modified_by = new SelectList(db.Recrutadors, "Id", "Name", anuncio.Modified_by);
            ViewBag.Status = new SelectList(db.StatusVagas, "Id", "Status", anuncio.Status);

            ViewBag.parentCategory = new SelectList(db.Categories.Where(x => !x.CatParent.HasValue), "Id", "Name");
            ViewBag.category = new SelectList(db.Categories, "Id", "Name");

            ViewBag.tipoAnuncio = new SelectList(db.TipoAnuncios, "Id", "Name");

            return View(anuncio);
        }

        // GET: /Anuncio/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
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

        // POST: /Anuncio/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anuncio anuncio = db.Anuncios.Find(id);
            db.Anuncios.Remove(anuncio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        public ActionResult mutipleDetete(IEnumerable<int> anuncioIdsSelected) 
        {

            if (anuncioIdsSelected != null)
            {

                foreach (int id in anuncioIdsSelected)
                {

                    Anuncio anuncio = db.Anuncios.Find(id);
                    db.Anuncios.Remove(anuncio);
                    db.SaveChanges();
                }

            }
 
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
