using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace XYZCorpTempSite.Interfaces
{
    public interface IRepository
    {
        IArticle GetFeaturedArticle(DbContext context);
        IArticle GetArticleById(DbContext context, int? newsArticleId);
        IEnumerable<IArticle> GetArticles(DbContext context);
        ILogo GetCurrentLogo(DbContext context);
    }
}