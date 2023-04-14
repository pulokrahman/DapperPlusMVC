using Microsoft.AspNetCore.Mvc;
using Infrastructure.Repositories;
using Infrastructure.Entities;
using Infrastructure.Contracts.Repositories;
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Departments> _departmentRepository;
        private readonly IRepository<Employees> _employeeRepository;
        public HomeController(IRepository<Departments> _departmentRepository, IRepository<Employees> _employeeRepository)
        {
            this._departmentRepository = _departmentRepository;
            this._employeeRepository=_employeeRepository;
        }
        public IActionResult getDepartments()
        {
            ViewBag.Departments = _departmentRepository.GetAll();
            return View();
        }
        public IActionResult getEmployees()
        {
            ViewBag.Employees =_employeeRepository.GetAll();
            return View();

        }
        public IActionResult getSingleDepartment(int id)
        {

            ViewBag.Department = _departmentRepository.GetById(id);
           
            return View();
        }
        public IActionResult getSingleEmployee(int id)
        {

            ViewBag.Employee = _employeeRepository.GetById(id);

            return View();
        }
        public IActionResult addDepartment(Departments department)
        {
            _departmentRepository.Insert(department);
            return View();

        }
        public IActionResult addEmployee(Employees employee)
        {
            _employeeRepository.Insert(employee);
            return View();

        }
        public IActionResult updateDepartment(Departments department)
        {
            _departmentRepository.Update(department);
            return View();
        }
        public IActionResult updateEmployee(Employees employee)
        {
            _employeeRepository.Update(employee);
            return View();

        }
       public IActionResult deleteDepartment(int id)
        {
            _departmentRepository.DeleteById(id);
            return View();
        } 
        public IActionResult deleteEmployee(int id)
        {
            _employeeRepository.DeleteById(id);
            return View();
        }
    }
}
