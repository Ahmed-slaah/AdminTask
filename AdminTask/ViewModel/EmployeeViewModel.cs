using AdminTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminTask.ViewModel
{
    public class EmployeeViewModel
    {
        public List<Employee> employees { get; set; }
        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }
    }
}
