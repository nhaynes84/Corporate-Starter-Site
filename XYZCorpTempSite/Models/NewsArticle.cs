using XYZCorpTempSite.Interfaces;

namespace XYZCorpTempSite.Models
{
    public class NewsArticle : IArticle
    {
        public int NewsArticleId { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public bool IsFeatured { get; set; }
    }
}