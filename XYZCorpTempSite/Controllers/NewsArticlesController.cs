using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using RTE;
using XYZCorpTempSite.Contexts;
using XYZCorpTempSite.Models;

namespace XYZCorpTempSite.Controllers
{
    [Authorize]
    public class NewsArticlesController : Controller
    {
        
        private NewsContext db = new NewsContext();

        // GET: NewsArticles
        public ActionResult Index()
        {
            return View(db.NewsArticles.ToList());
        }

        // GET: NewsArticles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsArticle newsArticle = db.NewsArticles.Find(id);
            if (newsArticle == null)
            {
                return HttpNotFound();
            }
            return View(newsArticle);
        }

        // GET: NewsArticles/Create
        public ActionResult Create()
        {
            var newsEditorModel = new NewsEditorModel
            {
                Editor = new Editor(System.Web.HttpContext.Current, "NewsEditor"),
                SelectedArticle = new NewsArticle()
            };

            newsEditorModel.Editor.LoadFormData(string.Empty);
            newsEditorModel.Editor.MvcInit();

            return View(newsEditorModel);
        }

        // POST: NewsArticles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost][ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewsArticleId,Header,IsFeatured, NewsEditor")] NewsArticle newsArticle)
        {
            newsArticle.Content = newsArticle.NewsEditor;

            if (ModelState.IsValid)
            {
                db.NewsArticles.Add(newsArticle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var newsEditorModel = new NewsEditorModel
            {
                Editor = new Editor(System.Web.HttpContext.Current, "NewsEditor"),
                SelectedArticle = newsArticle
            };

            newsEditorModel.Editor.LoadFormData(newsArticle.Content);
            newsEditorModel.Editor.MvcInit();

            return View(newsEditorModel);
        }

        // GET: NewsArticles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsArticle newsArticle = db.NewsArticles.Find(id);
            if (newsArticle == null)
            {
                return HttpNotFound();
            }

            var newsEditorModel = new NewsEditorModel
            {
                Editor = new Editor(System.Web.HttpContext.Current, "NewsEditor"),
                SelectedArticle = newsArticle
            };

            newsEditorModel.Editor.LoadFormData(newsArticle.Content);
            newsEditorModel.Editor.MvcInit();

            return View(newsEditorModel);
        }

        // POST: NewsArticles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsArticleId,Header,NewsEditor,IsFeatured")] NewsArticle newsArticle)
        {
            newsArticle.Content = newsArticle.NewsEditor;

            if (ModelState.IsValid)
            {
                db.Entry(newsArticle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var newsEditorModel = new NewsEditorModel
            {
                Editor = new Editor(System.Web.HttpContext.Current, "NewsEditor"),
                SelectedArticle = newsArticle
            };

            newsEditorModel.Editor.LoadFormData(newsArticle.Content);
            newsEditorModel.Editor.MvcInit();

            return View(newsEditorModel);
        }

        // GET: NewsArticles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsArticle newsArticle = db.NewsArticles.Find(id);
            if (newsArticle == null)
            {
                return HttpNotFound();
            }
            return View(newsArticle);
        }

        // POST: NewsArticles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsArticle newsArticle = db.NewsArticles.Find(id);
            db.NewsArticles.Remove(newsArticle);
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
