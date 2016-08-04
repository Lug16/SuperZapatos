using SuperZapatos.Models.Primitives;
using SuperZapatos.WebApiReposityHandler;
using SuperZapatos.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SuperZapatos.WebApp.Controllers
{
    public class ArticlesController : Controller
    {
        WebApiRepositoryHandler repository = new WebApiRepositoryHandler(ConfigurationManager.AppSettings["WebRespositoryUrl"]);

        // GET: Articles
        public ActionResult Index()
        {
            var articles = repository.Articles.List();
            var stores = repository.Stores.List();

            var model = articles.Select(r => new ArticleStore(r, stores.Where(s => s.Id == r.StoreId).Single())).ToArray();

            return View(model);
        }

        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = repository.Articles.GetById(id.Value);

            if (article == null)
            {
                return HttpNotFound();
            }

            Store store = repository.Stores.GetById(article.StoreId);

            var model = new ArticleStore(article, store);

            return View(model);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            ViewBag.StoreId = new SelectList(repository.Stores.List(), "Id", "Name");
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,Total_In_Shelf,Total_In_Vault,StoreId")] Article article)
        {
            if (ModelState.IsValid)
            {
                repository.Articles.Insert(article);
                return RedirectToAction("Index");
            }

            ViewBag.StoreId = new SelectList(repository.Stores.List(), "Id", "Name", article.StoreId);
            return View(article);
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = repository.Articles.GetById(id.Value);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.StoreId = new SelectList(repository.Stores.List(), "Id", "Name", article.StoreId);
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,Total_In_Shelf,Total_In_Vault,StoreId")] Article article)
        {
            if (ModelState.IsValid)
            {
                repository.Articles.Update(article);

                return RedirectToAction("Index");
            }
            ViewBag.StoreId = new SelectList(repository.Stores.List(), "Id", "Name", article.StoreId);
            return View(article);
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = repository.Articles.GetById(id.Value);
            if (article == null)
            {
                return HttpNotFound();
            }
            Store store = repository.Stores.GetById(article.StoreId);

            var model = new ArticleStore(article, store);

            return View(model);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.Articles.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
