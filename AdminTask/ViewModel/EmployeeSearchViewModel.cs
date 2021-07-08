using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminTask.ViewModel
{
    public enum SearchTypee { Company,Name, EMAIL}
    public class EmployeeSearchViewModel
    {
        public string SearchString { get; set; }
        public SearchTypee Type  { get; set; }
    }
}
