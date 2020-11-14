namespace Domain.Models.Entities
{
    public class BaseEntity<TId>
    {
        public TId Id { get; set; }
    }
}
