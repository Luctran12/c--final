using System.Text.Json.Serialization;
using BlazorApp.Components;
using BlazorApp.Components.Repository;
using BlazorApp.services;
using Microsoft.EntityFrameworkCore;
using Repositoy.BookSaleRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IStaffService,StaffService>();

builder.Services.AddScoped(sp => new HttpClient{BaseAddress = new Uri("http://localhost:5259")});

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None);
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
//builder.Services.AddDbContext<BookSaleContext>(options =>
//    options.UseMySql(builder.Configuration.GetConnectionString("DBConnection"),
//    new MySqlServerVersion(new Version(8, 0, 21)))); // Thay đổi phiên bản theo DB của bạn

builder.Services.AddDbContext<BookSaleContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DBConnection"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DBConnection"))));


builder.Services.AddScoped<IBookSaleRepository, BookSaleRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
