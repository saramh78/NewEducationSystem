using Domain.Models.Entities;

namespace Domain.Models.Entities
{
    public class CategoryParsed
    {
        public Category Categ { get; set; }
        public int level { get; set; }
        public bool Parsed { get; set; }

    }
}
