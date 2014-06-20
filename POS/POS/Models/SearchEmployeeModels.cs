using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class SearchEmployeeModels
    {
        public string SearchText { get; set; }
        public List<ClassLibrary1.Employee> Employee { get; set; } 
    }
}