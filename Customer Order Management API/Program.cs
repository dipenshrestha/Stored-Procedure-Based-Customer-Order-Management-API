using Customer_Order_Management_API.IRepository;
using Customer_Order_Management_API.IRepository.Productions;
using Customer_Order_Management_API.IRepository.Sales;
using Customer_Order_Management_API.Middleware;
using Customer_Order_Management_API.Repository;
using Customer_Order_Management_API.Repository.Productions;
using Customer_Order_Management_API.Repository.Sales;
using DapperAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateLifetime = true,
                ValidateActor = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],

                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value!)),
                ValidateIssuer = true,
                ValidateAudience = true
            };
        });

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 123xyzx2sff\"",
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

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

//for jwt
builder.Services.AddScoped<IJWTManagerRepository, JWTManagerRepository>();

// Add global authorization filter
builder.Services.AddMvc(options =>
{
    options.Filters.Add(new AuthorizeFilter());
});

var app = builder.Build();

//middleware 
app.UseMiddleware<BearerTokenMiddleware>();


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

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
