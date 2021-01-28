using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using NilDevStudio.Musicas.AcessoDados.Entity.Context;
using NilDevStudio.Musicas.Dominio;
using NilDevStudio.Musicas.Web.ViewModels.Album;

namespace NilDevStudio.Musicas.Web.Controllers
{
    public class AlbumController : Controller
    {
        private MusicasDbContext db = new MusicasDbContext();

        // GET: Album
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Album>, List<AlbumIndexViewModel>>(db.Albuns.ToList()));
        }

        // GET: Album/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albuns.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Album, AlbumIndexViewModel>(album));
        }

        // GET: Album/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Album/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Ano,Observacoes")] AlbumViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Album album = Mapper.Map<AlbumViewModel, Album>(viewModel);
                db.Albuns.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Album/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albuns.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Album, AlbumViewModel>(album));
        }

        // POST: Album/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Ano,Observacoes")] AlbumViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Album album = Mapper.Map<AlbumViewModel, Album>(viewModel);
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Album/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albuns.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Album, AlbumIndexViewModel>(album));
        }

        // POST: Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albuns.Find(id);
            db.Albuns.Remove(album);
            db.SaveChanges();
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
