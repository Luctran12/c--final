
namespace BlazorApp.dto;
public class EmployeeResponse
{
    public string? Id { get; set; }
    public List<Employee> Values { get; set; } = new();
}
