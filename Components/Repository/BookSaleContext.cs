using System;
using Microsoft.EntityFrameworkCore;
using BlazorApp.Components.Model;

namespace BlazorApp.Components.Repository
{
    public class BookSaleContext : DbContext
    {
       
        public BookSaleContext(DbContextOptions<BookSaleContext> options) : base(options)
        {
        }

        
        public DbSet<BookSale> BookSale { get; set; }
    }
}
