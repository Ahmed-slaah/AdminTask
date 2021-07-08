using AdminTask.Models;
using AdminTask.Services;
using AdminTask.ViewModel;
using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminTask.Controllers
{

    public class AdminController : Controller
    {
        MyContext db = new MyContext();
        readonly IEmployeeOperations _employeeOperations;
        readonly ICompanyOperations _companyOperations;

        public AdminController(IEmployeeOperations employeeOperations, ICompanyOperations companyOperations)
        {
            _employeeOperations = employeeOperations;
            _companyOperations = companyOperations;
        }
        public IActionResult Dashboard()
        {
            ViewBag.Employees = _employeeOperations.GetEmployees().Count();
            ViewBag.Companies = _companyOperations.GetCompanies().Count();

            return View();
        }
        [HttpGet]
        public IActionResult AllCompanies(int page=1)
        {
            var data = _companyOperations.GetCompanies();
            var companies = _companyOperations.filterbypage(data, page);
            CompanyViewModel model = new CompanyViewModel()
            {
                Companies = companies.ToList(),
                CurrentPageIndex = page,
                PageCount = (data.Count() / 10) +1
            };
            return View(model);
        }
        
        [HttpGet]
        public IActionResult AddCompany()
        {
            return PartialView("Views/Shared/AddCompanyPartialView.cshtml");
        }
        [HttpPost]
        public IActionResult AddCompany(Company company)
        {
            if (ModelState.IsValid)
            {
                _companyOperations.AddCompany(company);
                var url = Url.Action("Dashboard", "Admin");
                return Content($"<script language='javascript' type='text/javascript'>location.href='{url}'</script>");
            }
            else
            {
                return PartialView("Views/Shared/AddCompanyPartialView.cshtml",company);
            }
        }

        [HttpPost]
        public IActionResult SearchCompany(CompanySearchViewModel ViewModel,int page=1)
        {

            var data = _companyOperations.SearchCompany(ViewModel);
            var companies = _companyOperations.filterbypage(data, page);
            CompanyViewModel model = new CompanyViewModel()
            {
                Companies = companies.ToList(),
                CurrentPageIndex = 1,
                PageCount = (data.Count() / 10) + 1

            };
           
            TempData["searchtxt"] =ViewModel.SearchString;
            TempData["type"] = ViewModel.Type;
            TempData["count"] = model.PageCount;

            return View(model);
        }

        [HttpGet]
        public IActionResult SearchCompany(int page)
        {
            CompanySearchViewModel companySearchViewModel = new CompanySearchViewModel()
            {
                SearchString = (string)TempData["searchtxt"],
                Type = (SearchType)TempData["type"]
            };
            var data = _companyOperations.SearchCompany(companySearchViewModel);
            var companies = _companyOperations.filterbypage(data, page);
            CompanyViewModel model = new CompanyViewModel()
            {
                Companies = companies.ToList(),
                CurrentPageIndex = page,
                PageCount = (int)TempData["count"] / 1
            };

            TempData["searchtxt"] = companySearchViewModel.SearchString;
            TempData["type"] = companySearchViewModel.Type;
            TempData["count"] = model.PageCount;
            return View(model);
        }
        ////////////////////////////////////////   
        
        [HttpGet]
        public IActionResult AllEmployees(int page = 1)
        {
            var data = _employeeOperations.GetEmployees();
            var employees = _employeeOperations.filterbypage(data, page);
            EmployeeViewModel model = new EmployeeViewModel()
            {
                employees = employees.ToList(),
                CurrentPageIndex = page,
                PageCount = (data.Count() / 10) + 1
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            ViewBag.Companies = _companyOperations.GetCompanies();
            return PartialView("Views/Shared/AddEmployeePartialView.cshtml");
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeOperations.AddEmployee(employee);
                var url = Url.Action("Dashboard", "Admin");
                return Content($"<script language='javascript' type='text/javascript'>location.href='{url}'</script>");
            }
            else
            {
                return PartialView("Views/Shared/AddEmployeePartialView.cshtml", employee);
            }
        }
        [HttpPost]
        public IActionResult SearchEmployee(EmployeeSearchViewModel ViewModel, int page = 1)
        {

            var data = _employeeOperations.SearchEmployee(ViewModel);
            var employees = _employeeOperations.filterbypage(data, page);
            EmployeeViewModel model = new EmployeeViewModel()
            {
                employees = employees.ToList(),
                CurrentPageIndex = 1,
                PageCount = (data.Count() / 10)+1
            };

            TempData["searchtxt"] = ViewModel.SearchString;
            TempData["type"] = ViewModel.Type;
            TempData["count"] = model.PageCount;

            return View(model);
        }

        [HttpGet]
        public IActionResult SearchEmployee(int page)
        {
            EmployeeSearchViewModel employeeSearchViewModel = new EmployeeSearchViewModel()
            {
                SearchString = (string)TempData["searchtxt"],
                Type = (SearchTypee)TempData["type"]
            };
            var data = _employeeOperations.SearchEmployee(employeeSearchViewModel);
            var employees = _employeeOperations.filterbypage(data, page);
            EmployeeViewModel model = new EmployeeViewModel()
            {
                employees = employees.ToList(),
                CurrentPageIndex = page,
                PageCount = (int)TempData["count"] / 1
            };

            TempData["searchtxt"] = employeeSearchViewModel.SearchString;
            TempData["type"] = employeeSearchViewModel.Type;
            TempData["count"] = model.PageCount;
            return View(model);
        }
    }
}

