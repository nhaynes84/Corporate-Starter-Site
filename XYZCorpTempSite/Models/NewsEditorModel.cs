using RTE;
using XYZCorpTempSite.Interfaces;

namespace XYZCorpTempSite.Models
{
    public class NewsEditorModel : IEditorModel
    {
        public Editor Editor { get; set; }
        public IArticle SelectedArticle { get; set; }
    }
}