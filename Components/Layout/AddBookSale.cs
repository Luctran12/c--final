using BlazorApp.Components.Model;
using BlazorApp.Components.Repository;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components.Layout
{
    public partial class AddBookSaleBase : ComponentBase
    {
        public BookSale bookSale { get; set; } = new BookSale();

        [Inject]
        IBookSaleRepository booksaleRepository { get; set; }

        [Inject]
        NavigationManager navigationManager { get; set; }

        public AddBookSaleBase()
        {
           
        }

        public async Task HandleValidSubmit()
        {
            await booksaleRepository.AddNewSale(bookSale);
            navigationManager.NavigateTo("/");
        }

        public async Task Form_Calculate()
        {
            Console.WriteLine("=============");
            await HandleValidSubmit(); // Thêm 'await' ở đây
        }
    }
}
