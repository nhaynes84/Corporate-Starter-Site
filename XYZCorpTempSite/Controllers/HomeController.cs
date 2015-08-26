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
                var featuredArticle = (NewsArticle)Repository.GetFeaturedArticle(db);
                var articles = (List<NewsArticle>)Repository.GetArticles(db);
                articles.Remove(featuredArticle);

                //SeedData(db);
                return View(new HomePage
                {
                    Articles = articles,
                    FeaturedArticle = featuredArticle,
                    XyzCorpLogo = Repository.GetCurrentLogo(db)
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
                    Articles = Repository.GetArticles(db),
                    FeaturedArticle = Repository.GetFeaturedArticle(db),
                    XyzCorpLogo = Repository.GetCurrentLogo(db)
                };
                return View(homePage);
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}