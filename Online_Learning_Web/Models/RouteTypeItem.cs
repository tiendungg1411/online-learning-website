using Online_Learning_Web.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Learning_Web.Models
{
    public class RouteTypeItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("RouteType")]
        public int RouteTypeID { get; set; }
        public RouteType RouteType { get; set; }
        public ICollection<Course> Courses { get; set; }
        //public ICollection<CourseRouteTypeItem> CourseRouteTypeItems { get; set; }
    }
}

