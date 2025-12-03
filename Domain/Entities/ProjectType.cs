namespace Domain.Entities
{
    public class ProjectType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
