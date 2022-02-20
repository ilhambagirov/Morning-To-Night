namespace M2N.Domain.Models
{
    public class AppTask : BaseEntity
    {
        public string Content { get; set; }
        public int TaskCategoryId { get; set; }
        public TaskCategory TaskCategory { get; set; }
        public int StageId { get; set; }
        public Stage Stage { get; set; }
    }
}
