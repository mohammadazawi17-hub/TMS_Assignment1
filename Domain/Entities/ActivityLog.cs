using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class ActivityLog
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int? OldStatusId { get; set; }
        [ForeignKey("OldStatusId")]
        public TaskStatus OldStatus { get; set; }
        public int NewStatusId { get; set; }
        [ForeignKey("NewStatusId")]
        public TaskStatus NewStatus { get; set; }
        public int TaskId { get; set; }
        [ForeignKey("TaskId")]
        public TaskApp Task { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
