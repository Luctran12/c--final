
using BlazorApp.dto;
using BlazorApp.services;
using Microsoft.AspNetCore.Components;
namespace BlazorApp.Components.Pages;
public class AddStaffBase : ComponentBase
{
    public Employee staff = new Employee();

    [Inject]
    public IStaffService staffService { get; set; }

    [Inject]
    public NavigationManager navigationManager { get; set; }

    public async Task submit()
    {
        var rs = await staffService.AddEmployee(staff);
        if (rs != null)
        {
            navigationManager.NavigateTo("/stafflist");
        }
        else
        {
            Console.WriteLine(rs);
        }
    }

}