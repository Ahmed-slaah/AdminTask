using AdminTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminTask.ViewModel
{
    public class CompanyViewModel
    {
        public List<Company> Companies { get; set; }
        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }
    }
}
