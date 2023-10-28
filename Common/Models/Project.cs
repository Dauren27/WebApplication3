using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CustomerCompany { get; set; }
        public string ExecutorCompany { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public int ProjectManager { get; set; }
    }
}
