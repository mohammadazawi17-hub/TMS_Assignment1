using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class TaskApp
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public DateTime? DueDate { get; set; }
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public TaskStatus Status { get; set; }
        public int? AssigneeId { get; set; }
        [ForeignKey("AssigneeId")]
        public User Assignee { get; set; }
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
}
