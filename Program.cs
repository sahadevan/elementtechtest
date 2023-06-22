using ElementMaterialsTechnology.DataAccessLayer.Models;
using ElementMaterialsTechnology.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Entity Framework  
builder.Services.AddDbContext<TechTestContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TechTest")));

builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IQuotationService, QuotationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Quotation/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Quotation}/{action=Index}/{id?}");

app.Run();
