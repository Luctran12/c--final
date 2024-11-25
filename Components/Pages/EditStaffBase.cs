using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorApp.dto;

namespace BlazorApp.Components.Base
{
    public class EditStaffBase : ComponentBase
    {
        [Inject] protected HttpClient HttpClient { get; set; }
        [Inject] protected NavigationManager NavigationManager { get; set; }

        [Parameter] public int Id { get; set; }
        protected Employee Employee { get; set; } = new Employee();
        protected string ErrorMessage { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await LoadEmployeeAsync();
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error loading employee: {ex.Message}";
            }
        }

        protected async Task LoadEmployeeAsync()
        {
            var response = await HttpClient.GetAsync($"api/employees/{Id}");
            if (response.IsSuccessStatusCode)
            {
                Employee = await response.Content.ReadFromJsonAsync<Employee>();
            }
            else
            {
                ErrorMessage = "Failed to load employee data.";
            }
        }

        protected async Task UpdateEmployeeAsync()
        {
            try
            {
                var response = await HttpClient.PutAsJsonAsync($"api/employees/{Id}", Employee);
                if (response.IsSuccessStatusCode)
                {
                    NavigationManager.NavigateTo("/stafflist");
                }
                else
                {
                    ErrorMessage = "Failed to update employee.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error updating employee: {ex.Message}";
            }
        }

        protected void NavigateBack()
        {
            NavigationManager.NavigateTo("/employees");
        }
    }
}
