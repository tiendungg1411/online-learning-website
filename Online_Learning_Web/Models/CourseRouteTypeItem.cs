using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Learning_Web.Models
{
    public class CourseRouteTypeItem
    {
        public int CId { get; set; }
        
        public Course Course { get; set; }
        public int RIId { get; set; }
        
        public RouteTypeItem RouteTypeItem { get; set; }
    }
}
