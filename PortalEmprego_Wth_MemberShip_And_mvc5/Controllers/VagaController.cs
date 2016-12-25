using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PortalEmprego_Wth_MemberShip_And_mvc5.Models;

namespace PortalEmprego_Wth_MemberShip_And_mvc5.Controllers
{
   
    public class VagaController : Controller
    {
        private PortalEmpregoContextDB db = new PortalEmpregoContextDB();

        //// GET: /Vaga/
        // [Authorize]
        //public ActionResult Index()
        //{
            
        //    var vagas = db.Vagas.Include(v => v.Categoria).Include(v => v.Locai).Include(v => v.Recrutador).Include(v => v.VagaStatu);
        //    return View(vagas.ToList());
        //}

        //// GET: /Vaga/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Vaga vaga = db.Vagas.Find(id);
        //    if (vaga == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(vaga);
        //}

        //// GET: /Vaga/Create
        // [Authorize]
        //public ActionResult Create()
        //{
        //    PortalEmpregoContextDB dbTemp = new PortalEmpregoContextDB();

        //    List<SelectListItem> selectListItemsCat = new List<SelectListItem>();

        //    foreach (Categoria categoria in dbTemp.Categorias)
        //    {
        //        SelectListItem selectListItem = new SelectListItem
        //        {
        //            Text = categoria.Nome,
        //            Value = categoria.IdCategoria.ToString(),
        //            Selected = categoria.isSelected
        //        };
        //        selectListItemsCat.Add(selectListItem);
        //    }

        //    ViewBag.IdCategoria = selectListItemsCat;

        //    List<SelectListItem> selectListItemsLocal = new List<SelectListItem>();

        //    foreach (Local locai in dbTemp.Locals)
        //    {
        //        SelectListItem selectListItem = new SelectListItem
        //        {
        //            Text = locai.Nome,
        //            Value = locai.IdLocal.ToString(),
        //            Selected = locai.isSelected
        //        };
        //        selectListItemsLocal.Add(selectListItem);
        //    }

        //    ViewBag.IdLocal = selectListItemsLocal;

        //    List<SelectListItem> selectListItemsRecr = new List<SelectListItem>();

        //    foreach (Recrutador recrutador in dbTemp.Recrutadors)
        //    {
        //        SelectListItem selectListItem = new SelectListItem
        //        {
        //            Text = recrutador.Nome,
        //            Value = recrutador.IdRecrutador.ToString(),
        //            Selected = recrutador.isSelected
        //        };
        //        selectListItemsRecr.Add(selectListItem);
        //    }

        //    ViewBag.IdRecrutador = selectListItemsRecr;
        //    //ViewBag.IdCategoria = new SelectList(db.Categorias, "IdCategoria", "Nome");
        //    //ViewBag.IdLocal = new SelectList(db.Locals, "IdLocal", "Nome");
        //    //ViewBag.IdRecrutador = new SelectList(db.Recrutadors, "IdRecrutador", "Nome");
        //    //ViewBag.idStatus = new SelectList(db.StatusVagas, "idStatus", "Status");
        //    return View();
        //}

        //// POST: /Vaga/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize]
        //public ActionResult Create([Bind(Include="IdVaga,Codigo,descricao,DataInicio,DataFim,UrlImg,DetailsVaga,IdRecrutador,IdLocal,IdCategoria,idStatus")] Vaga vaga)
        //{
        //    vaga.DataInicio = DateTime.Now;
        //    vaga.UrlImg = "~/Content/images/img.png";
            
        //    PortalEmpregoContextDB dbTemp = new PortalEmpregoContextDB();
        //    StatusVaga vg = dbTemp.StatusVagas.Where(v => v.Status.Trim().Equals("Edited")).First();
        //    vaga.idStatus = vg.idStatus;
           

        //    if (ModelState.IsValid)
        //    {
  
        //        db.Vagas.Add(vaga);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.IdCategoria = new SelectList(db.Categorias, "IdCategoria", "Nome", vaga.IdCategoria);
        //    ViewBag.IdLocal = new SelectList(db.Locals, "IdLocal", "Nome", vaga.IdLocal);
        //    ViewBag.IdRecrutador = new SelectList(db.Recrutadors, "IdRecrutador", "Nome", vaga.IdRecrutador);
        //    ViewBag.idStatus = new SelectList(db.StatusVagas, "idStatus", "Status", vaga.idStatus);
        //    return View(vaga);
        //}

        //// GET: /Vaga/Edit/5
        // [Authorize]
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Vaga vaga = db.Vagas.Find(id);
        //    if (vaga == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.IdCategoria = new SelectList(db.Categorias, "IdCategoria", "Nome", vaga.IdCategoria);
        //    ViewBag.IdLocal = new SelectList(db.Locals, "IdLocal", "Nome", vaga.IdLocal);
        //    ViewBag.IdRecrutador = new SelectList(db.Recrutadors, "IdRecrutador", "Nome", vaga.IdRecrutador);
        //    ViewBag.idStatus = new SelectList(db.StatusVagas, "idStatus", "Status", vaga.idStatus);
        //    return View(vaga);
        //}

        //// POST: /Vaga/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize]
        //public ActionResult Edit([Bind(Include="IdVaga,Codigo,descricao,DataInicio,DataFim,UrlImg,DetailsVaga,IdRecrutador,IdLocal,IdCategoria,idStatus")] Vaga vaga)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(vaga).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.IdCategoria = new SelectList(db.Categorias, "IdCategoria", "Nome", vaga.IdCategoria);
        //    ViewBag.IdLocal = new SelectList(db.Locals, "IdLocal", "Nome", vaga.IdLocal);
        //    ViewBag.IdRecrutador = new SelectList(db.Recrutadors, "IdRecrutador", "Nome", vaga.IdRecrutador);
        //    ViewBag.idStatus = new SelectList(db.StatusVagas, "idStatus", "Status", vaga.idStatus);
        //    return View(vaga);
        //}

        //// GET: /Vaga/Delete/5
        // [Authorize]
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Vaga vaga = db.Vagas.Find(id);
        //    if (vaga == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(vaga);
        //}

        //// POST: /Vaga/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //[Authorize]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Vaga vaga = db.Vagas.Find(id);
        //    db.Vagas.Remove(vaga);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult PublishVaga(int id)
        //{
        //    Vaga vagaPub = db.Vagas.Find(id);

        //    if (vagaPub == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    //problema aqui no futuro
        //    // atribuido o estado published a vaga
        //    StatusVaga vg = db.StatusVagas.Where(v => v.Status.Trim().Equals("Published")).First();
        //    vagaPub.VagaStatu = vg;

        //    db.Entry(vagaPub).State = EntityState.Modified;
        //    db.SaveChanges();

        //    return View("Details", vagaPub);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }


    
}
