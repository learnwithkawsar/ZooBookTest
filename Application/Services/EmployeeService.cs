using Application.Interfaces;
using Domain.Models;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task DeleteEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id);           

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
           
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return await _context.Employee.ToListAsync();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _context.Employee.FindAsync(id);

        }

        public bool IsExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }

        public async Task SaveEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployee(int id, Employee employee)
        {
          

            _context.Entry(employee).State = EntityState.Modified;            
             await _context.SaveChangesAsync();
             
         
        }
    }
}
