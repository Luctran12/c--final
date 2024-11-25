using BlazorApp.dto;
using BlazorApp.dto;
namespace BlazorApp.services;

public class StaffService : IStaffService 
{
    private readonly HttpClient httpClient;

    public StaffService(HttpClient httpClient){
        this.httpClient = httpClient;
    }

    public async Task<IEnumerable<Employee>> GetAllStaff(){
        return await httpClient.GetFromJsonAsync<Employee[]>("api/employees");
    }

    // public async Task<Employee> GetStaff(int id){
    //     return await httpClient.GetFromJsonAsync<Employee>($"api/employees?id = {id}");
    // }

    public async Task<Employee> GetStaff(int id)
{
    var options = new System.Text.Json.JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true
};
return await httpClient.GetFromJsonAsync<Employee>($"api/employees?id={id}", options);

}


 public async Task DeleteStaff(int id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"api/employees/{id}");

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Staff with ID {id} deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"Error deleting staff with ID {id}: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle potential errors during the delete operation
                Console.WriteLine($"Error deleting staff with ID {id}: {ex.Message}");
            }
        }

        public async Task<Employee> AddEmployee(Employee employee)
    {
        var rs = await httpClient.PostAsJsonAsync<Employee>("api/employees", employee);
        rs.EnsureSuccessStatusCode();
        return await rs.Content.ReadFromJsonAsync<Employee>();
    }

    public async Task<Employee> Update(Employee employee, int id){
     var rs = await httpClient.PutAsJsonAsync<Employee>("api/employees/{id}", employee);
     rs.EnsureSuccessStatusCode();
     return await rs.Content.ReadFromJsonAsync<Employee>();
    }


}