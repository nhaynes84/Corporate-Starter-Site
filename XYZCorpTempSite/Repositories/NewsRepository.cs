using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using XYZCorpTempSite.Contexts;
using XYZCorpTempSite.Interfaces;

namespace XYZCorpTempSite.Repositories
{
    public class NewsRepository : IRepository
    {
        public IArticle GetFeaturedArticle(NewsContext context)
        {
            return context.NewsArticles
                .ToList().FirstOrDefault(x => x.IsFeatured);
        }

        public IArticle GetArticleById(NewsContext context, int newsArticleId)
        {
            return context.NewsArticles.Find(newsArticleId);
        }
        public IEnumerable<IArticle> GetArticles(NewsContext context)
        {
            return context.NewsArticles.ToList();
        }

        public ILogo GetCurrentLogo(NewsContext context)
        {
            return context.Logos
                .ToList().FirstOrDefault(x => x.IsCurrent);
        }

        public IEnumerable<ILogo> GetLogos(NewsContext context)
        {
            return context.Logos.ToList();
        }
    }
}