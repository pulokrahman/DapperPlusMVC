using Infrastructure.Entities;

namespace Infrastructure.Services
{
    public interface IEmployeesService
    {
        void AddEmployee();
        void DeleteEmployees();
        void GetAllEmployees();
        Employees GetEmployeebyID();
        void UpdateEmployee();
    }
}