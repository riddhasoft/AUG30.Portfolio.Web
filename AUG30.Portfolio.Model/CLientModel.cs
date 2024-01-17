using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUG30.Portfolio.Model
{
    public class CLientModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Designation { get; set; }
        public string CompanyName { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
