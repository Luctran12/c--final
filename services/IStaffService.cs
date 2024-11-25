using BlazorApp.dto;

namespace BlazorApp.services;

public interface IStaffService
{
    Task<IEnumerable<Employee>> GetAllStaff();

    Task<Employee> GetStaff(int id);

    Task DeleteStaff(int id);

    Task<Employee> AddEmployee(Employee employee);

}