using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RTE;
using XYZCorpTempSite.Contexts;
using XYZCorpTempSite.Interfaces;
using XYZCorpTempSite.Models;
using XYZCorpTempSite.Repositories;

namespace XYZCorpTempSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;
        private IRepository Repository { get { return _repository;} }

        public HomeController(IRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }
            _repository = repository;
        }
        public ActionResult Index()
        {
            using (var db = new NewsContext())
            {
                //SeedData(db);
                return View(new HomePage
                {
                    Articles = ((NewsRepository) Repository).GetArticles(db),
                    FeaturedArticle = ((NewsRepository) Repository).GetFeaturedArticle(db),
                    XyzCorpLogo = ((NewsRepository) Repository).GetCurrentLogo(db)
                });
            }
        }

        private void SeedData(NewsContext db)
        {
            //db.Logos.Add(new Logo
            //{
            //    IsCurrent = true,
            //    Alt = "current-xyzCorp-logo",
            //    Src = @"C:\Users\Architect\documents\visual studio 2013\Projects\XYZCorpTempSite\XYZCorpTempSite\Content\Resources\XYZ_Logo_Generic.jpg"
            //});

            db.NewsArticles.Add(new NewsArticle
            {
                Content = "<div class='col-md-12'><h6>This is a content byLine!</h6></div>"
                + "<div class='col-md-12'><p>This is a bunch of content relating to XYZ News!</p>",
                Header = "XYZ Breaking News Update 12/31/1600",
                IsFeatured = true
            });
            db.SaveChanges();
        }

        [Authorize]
        public ActionResult Edit()
        {
            using (var db = new NewsContext())
            {
                var homePage = new HomePage
                {
                    Articles = ((NewsRepository)Repository).GetArticles(db),
                    FeaturedArticle = ((NewsRepository)Repository).GetFeaturedArticle(db),
                    XyzCorpLogo = ((NewsRepository)Repository).GetCurrentLogo(db)
                };
                return View(homePage);
            }
        }

        [Authorize]
        public ActionResult ArticleEditor(int newsArticleId)
        {
            //Editor Editor1 = 
            //Editor1.LoadFormData("stuff");
            //Editor1.MvcInit();
            //ViewBag.Editor = Editor1.MvcGetString();

            var newsEditorModel = new NewsEditorModel
            {
                Editor = new Editor(System.Web.HttpContext.Current, "ArticleEditor")
            };

            using (var db = new NewsContext())
            {
                var selectedArticle = ((NewsRepository) Repository).GetArticleById(db, newsArticleId);
                newsEditorModel.SelectedArticle = new NewsArticle
                {
                    Content = selectedArticle.Content,
                    Header = selectedArticle.Header,
                    IsFeatured = ((NewsArticle)selectedArticle).IsFeatured
                };

                newsEditorModel.Editor.LoadFormData(newsEditorModel.SelectedArticle.Content);
                newsEditorModel.Editor.MvcInit();

                return View("~/Views/Home/ArticleEditor.cshtml", newsEditorModel);
            }
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}