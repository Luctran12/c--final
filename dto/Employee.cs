using System.Text.Json.Serialization;
using StaffServices.Model;

namespace BlazorApp.dto;

public class Employee
{
     [JsonPropertyName("employeeId")]
    public int EmployeeId { get; set; }
    
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }
    
    [JsonPropertyName("lastName")]
    public string LastName { get; set; }
    
    [JsonPropertyName("email")]
    public string Email { get; set; }
    
    [JsonPropertyName("startingDate")]
    public DateTime StartingDate { get; set; }
    
    [JsonPropertyName("genderId")]
    public int? GenderId { get; set; }
    
    [JsonPropertyName("departmentId")]
    public int? DepartmentId { get; set; }
}