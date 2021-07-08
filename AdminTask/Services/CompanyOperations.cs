using AdminTask.Models;
using AdminTask.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminTask.Services
{
    public interface ICompanyOperations
    {
        public IEnumerable<Company> GetCompanies();
        public void AddCompany(Company company);
        public IEnumerable<Company> SearchCompany(CompanySearchViewModel model);
        public IEnumerable<Company> filterbypage(IEnumerable<Company> companies, int currentpage);
    }
    public class CompanyOperations: ICompanyOperations
    {
        MyContext db = new MyContext();
        public IEnumerable<Company> GetCompanies()
        {
            return db.companies.Include(a => a.Employees);
        }
        public IEnumerable<Company> filterbypage(IEnumerable<Company> companies , int currentpage)
        {
            return companies.Skip((currentpage - 1) * 10)
                            .Take(10);
        }
        public void AddCompany(Company company)
        {
            db.companies.Add(company);
            db.SaveChanges();
        }

        public IEnumerable<Company> SearchCompany(CompanySearchViewModel model)
        {
            if (model != null)
            {
                if (model.Type == SearchType.Name)
                {
                    var companies = db.companies.Where(c => c.Name.Contains(model.SearchString));
                    return companies;
                }
                else if (model.Type == SearchType.Address)
                {
                    var companies = db.companies.Where(c => c.Address.Contains(model.SearchString)).ToList();
                    return companies;
                }
                else
                {
                    var companies = db.companies.Where(c => c.Website.Contains(model.SearchString)).ToList();
                    return companies;
                }
            }
            else
            {
                return null;
            }
        }


    }
   
}
