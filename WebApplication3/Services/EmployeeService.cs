using Common.Models;
using WebApplication3.Repositories;
using WebApplication3.Data;
using WebApplication3.Repositories.Interfaces;
using WebApplication3.Services.Interfaces;

namespace WebApplication3.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _employeeRepository.GetEmployeesAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            // Можно добавить здесь дополнительную логику, например, валидацию данных
            await _employeeRepository.CreateEmployeeAsync(employee);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            // Можно добавить здесь дополнительную логику, например, валидацию данных
            await _employeeRepository.UpdateEmployeeAsync(employee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
        }
    }
}
