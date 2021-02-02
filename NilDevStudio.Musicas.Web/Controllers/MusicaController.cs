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
using NilDevStudio.Musicas.Repositorios.Entity;
using NilDevStudio.Musicas.Web.ViewModels.Album;
using NilDevStudio.Musicas.Web.ViewModels.Musica;
using NilDevStudio.Repositorios.Comum;

namespace NilDevStudio.Musicas.Web.Controllers
{
    public class MusicaController : Controller
    {
        private IRepositorioGenerico<Musica, long> repositorioMusica = new MusicaRepositorio(new MusicasDbContext());
        private IRepositorioGenerico<Album, int> repositorioAlbum = new AlbumRepositorio(new MusicasDbContext());

        // GET: Musica
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Musica>, List<MusicaExibicaoViewModel>>(repositorioMusica.Selecionar()));
        }

        // GET: Musica/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorioMusica.SelecionarPorId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Musica, MusicaExibicaoViewModel>(musica));
        }

        // GET: Musica/Create
        public ActionResult Create()
        {
            List<AlbumIndexViewModel> albuns = Mapper.Map<List<Album>, List<AlbumIndexViewModel>>(repositorioAlbum.Selecionar());
            SelectList dropDownAlbuns = new SelectList(albuns, "Id", "Nome");
            ViewBag.DropDownAlbuns = dropDownAlbuns;
            return View();
        }

        // POST: Musica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,IdAlbum")] MusicaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Musica musica = Mapper.Map<MusicaViewModel, Musica>(viewModel);
                repositorioMusica.Inserir(musica);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Musica/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorioMusica.SelecionarPorId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            List<AlbumIndexViewModel> albuns = Mapper.Map<List<Album>, List<AlbumIndexViewModel>>(repositorioAlbum.Selecionar());
            SelectList dropDownAlbuns = new SelectList(albuns, "Id", "Nome");
            ViewBag.DropDownAlbuns = dropDownAlbuns;
            return View(Mapper.Map<Musica, MusicaViewModel>(musica));
        }

        // POST: Musica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,IdAlbum")] MusicaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Musica musica = Mapper.Map<MusicaViewModel, Musica>(viewModel);
                repositorioMusica.Alterar(musica);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Musica/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorioMusica.SelecionarPorId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Musica, MusicaExibicaoViewModel>(musica));
        }

        // POST: Musica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            repositorioMusica.ExcluirPorId(id);
            return RedirectToAction("Index");
        }
    }
}
