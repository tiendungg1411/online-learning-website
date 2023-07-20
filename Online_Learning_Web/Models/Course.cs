using System.ComponentModel.DataAnnotations;

namespace Online_Learning_Web.Models
{
    public class Course
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [DataType("nvarchar(500)")]
        public string Title { get; set; }
        public int Price { get; set; }
        public bool IsPublished { get; set; }
        [DataType("nvarchar(500)")]
        public string Level { get; set; }
        [DataType("nvarchar(10000)")]
        public string Description { get; set; }
        [DataType("nvarchar(500)")]
        public string Image { get; set; }
        public ICollection<RouteTypeItem> RouteTypeItems { get; set; }
        //public ICollection<CourseRouteTypeItem> CourseRouteTypeItems { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
