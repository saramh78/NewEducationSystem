using System.Collections.Generic;

namespace Domain.Service.Dtos
{
    public class ArticleInsertApiModel
    {
        public string Text { get; set; }
        public int Order { get; set; }
        public List<string> ReferenceLinks { get; set; }
        public List<string> MediaLinks { get; set; }
    }
}
