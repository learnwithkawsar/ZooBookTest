using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEmployeeService
    {

        Task<Employee> GetEmployee(int id);
        Task<IEnumerable<Employee>> GetAllEmployee();
        Task UpdateEmployee(int id, Employee employee);
        Task SaveEmployee(Employee employee);
        Task DeleteEmployee(int id);
        bool IsExists(int id);
    }
}
