using Common.Models;

namespace WebApplication3.Views.ViewModels
{
    public class ProjectViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
        public DateTime? StartDateMin { get; set; }
        public DateTime? StartDateMax { get; set; }
        public string SortOrder { get; set; }
    }
}
