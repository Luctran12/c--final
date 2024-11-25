
using BlazorApp.dto;
using BlazorApp.services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;
namespace BlazorApp.Components.Pages;
public class DeleteStaffBase : ComponentBase
{
    [Parameter]
    public int Id  {get; set;}

    [Inject]
    public IStaffService staffService { get; set; }

    [Inject]
    public NavigationManager navigationManager { get; set; }

    public async Task submit()
    {
        await staffService.DeleteStaff(Id);
        
    }

}