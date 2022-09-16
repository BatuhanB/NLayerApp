namespace NLayerApp.Core.Abstracts
{
    public abstract class BaseEntity
    {
        protected BaseEntity(int id, DateTime createdDate, DateTime? updatedDate)
        {
            Id = id;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
        }

        protected BaseEntity()
        {
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
