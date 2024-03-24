namespace TaskManager.Domain.Entities
{
    public class DatesControlEntity: LogicDeleteEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;       
    }
}
