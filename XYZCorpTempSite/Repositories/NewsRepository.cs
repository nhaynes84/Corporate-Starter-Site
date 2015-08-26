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
        public virtual IArticle GetFeaturedArticle(DbContext context)
        {
            return ((NewsContext)context).NewsArticles
                .ToList().FirstOrDefault(x => x.IsFeatured);
        }

        public virtual IArticle GetArticleById(DbContext context, int? newsArticleId)
        {
            return ((NewsContext)context).NewsArticles.Find(newsArticleId);
        }
        public virtual IEnumerable<IArticle> GetArticles(DbContext context)
        {
            return ((NewsContext)context).NewsArticles.ToList();
        }

        public virtual ILogo GetCurrentLogo(DbContext context)
        {
            return ((NewsContext)context).Logos
                .ToList().FirstOrDefault(x => x.IsCurrent);
        }
    }
}