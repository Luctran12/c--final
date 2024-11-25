using BlazorApp.dto;
using BlazorApp.services;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components
{
    public class StaffDetailBase : ComponentBase
    {
        [Inject]
        public IStaffService StaffService { get; set; }

        public Employee Staff = new Employee();
        [Parameter]
        public int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("---" + Id);
            Staff = await StaffService.GetStaff(Id);
            Console.WriteLine(Staff);
        }

        
    }

    
}
