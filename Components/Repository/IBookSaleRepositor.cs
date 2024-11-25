using System;
namespace BlazorApp.Components.Repository;

using BlazorApp.Components.Model;
using BlazorApp.Components.Repository;
public interface IBookSaleRepository
{
	
    Task AddNewSale(BookSale bookSale);
}
