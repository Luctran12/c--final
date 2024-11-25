using BlazorApp.dto;
using BlazorApp.services;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components
{
    public class StaffListBase : ComponentBase
    {
        [Inject]
        public IStaffService StaffService { get; set; }

        public IEnumerable<Employee> Staffs { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Staffs = await StaffService.GetAllStaff();
        }

        
    }

    
}
