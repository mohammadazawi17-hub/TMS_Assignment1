using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Department
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public string Desc { get; set; }
        public int LimitedEmployees { get; set; }
        public ICollection<UserProfile> UserProfiles { get; set; }
    }
}
