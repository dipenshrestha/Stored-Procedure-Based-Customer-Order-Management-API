using Customer_Order_Management_API.IRepository.Productions;
using Customer_Order_Management_API.IRepository.Sales;
using Customer_Order_Management_API.Repository.Productions;
using Customer_Order_Management_API.Repository.Sales;
using DapperAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<DapperContext>();

//for Sales schema
builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();
builder.Services.AddScoped<IOrderItemsRepository, OrderItemsRepository>();
builder.Services.AddScoped<IOrdersRepositroy, OrdersRepository>();
builder.Services.AddScoped<IStaffsRepository, StaffsRepository>();
builder.Services.AddScoped<IStoresRepository, StoresRepository>();

//for productions schema
builder.Services.AddScoped<IBrandsRepository, BrandsRepository>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IStocksRepository, StocksRepository>();

var app = builder.Build();

//middle wares , sequential execution
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //to create human readable and interactive api documentaion
    //to test apis

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
