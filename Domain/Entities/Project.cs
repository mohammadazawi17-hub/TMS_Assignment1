using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public ProjectType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? ProjectManagerId { get; set; }
        [ForeignKey("ProjectManagerId")]
        public User ProjectManager { get; set; }
        public ICollection<TaskApp> Tasks { get; set; }
    }
}
