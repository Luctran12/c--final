using System;
using BlazorApp.Components.Model;
using BlazorApp.Components.Repository;
namespace Repositoy.BookSaleRepository;

public class BookSaleRepository : IBookSaleRepository
{

	BookSaleContext bookSaleContext;
	public BookSaleRepository(BookSaleContext bookSaleContext)
	{
		this.bookSaleContext = bookSaleContext;
	}
    public async Task AddNewSale(BookSale bookSale)
    {
        // Thêm thực thể BookSale vào context không đồng bộ
        await this.bookSaleContext.BookSale.AddAsync(bookSale);

        // Lưu thay đổi không đồng bộ
        await this.bookSaleContext.SaveChangesAsync();
    }

}
