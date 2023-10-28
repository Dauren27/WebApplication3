using Common.Models;
using DAL.Repositories;
using DAL.Data;
using DAL.Repositories.Interfaces;
using BLL.Services.Interfaces;

namespace BLL.Services
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
