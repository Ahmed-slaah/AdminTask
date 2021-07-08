using AdminTask.Models;
using AdminTask.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminTask.Services
{
    public interface IEmployeeOperations
    {
        public IEnumerable<Employee> GetEmployees();
        public IEnumerable<Employee> filterbypage(IEnumerable<Employee> employees, int currentpage);
        public void AddEmployee(Employee emp);
        public IEnumerable<Employee> SearchEmployee(EmployeeSearchViewModel model);
    }
    public class EmployeeOperations:IEmployeeOperations
    {
        MyContext db = new MyContext();
        public IEnumerable<Employee> GetEmployees()
        {
            return db.employees.Include(c=>c.company);
        }
        public IEnumerable<Employee> filterbypage(IEnumerable<Employee> employees, int currentpage)
        {
            return employees.Skip((currentpage - 1) * 10)
                            .Take(10);
        }
        public void AddCompany(Company company)
        {
            db.companies.Add(company);
            db.SaveChanges();
        }
        public void AddEmployee(Employee emp)
        {
            db.employees.Add(emp);
            db.SaveChanges();
        }
        public IEnumerable<Employee> SearchEmployee(EmployeeSearchViewModel model)
        {
            if (model != null)
            {
                if (model.Type == SearchTypee.Name)
                {
                    var employees = db.employees.Where(e => e.Name.Contains(model.SearchString)).Include(c=>c.company);
                    return employees;
                }
                else if (model.Type == SearchTypee.EMAIL)
                {
                    var employees = db.employees.Where(e => e.Email.Contains(model.SearchString)).Include(c => c.company);
                    return employees;
                }
                else
                {
                    var employees = db.employees.Where(e => e.company.Name.Contains(model.SearchString)).Include(c => c.company);
                    return employees;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
