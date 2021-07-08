using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminTask.ViewModel
{
    public enum SearchType { Address,Name, Website}
    public class CompanySearchViewModel
    {
        public string SearchString { get; set; }
        public SearchType Type  { get; set; }
    }
}
