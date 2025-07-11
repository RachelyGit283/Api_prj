using Services;
using Microsoft.EntityFrameworkCore;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUsersServices, UsersServices>();
builder.Services.AddScoped<IUsersData, UsersData>();
builder.Services.AddScoped<ICategoriesData, CategoriesData>();
builder.Services.AddScoped<IProductsData, ProductsData>();
builder.Services.AddScoped<IOrdersData, OrdersData>();
builder.Services.AddScoped<ICategoriesServices, CategoriesServices>();
builder.Services.AddScoped<IProductsServices, ProductsServices>();
builder.Services.AddScoped<IOrdersServices, OrdersServices>();


builder.Services.AddDbContext<StoreDB215085283Context>(options =>
    options.UseSqlServer("Data Source=SRV2\\PUPILS;Initial Catalog=StoreDB215085283;Integrated Security=True; TrustServerCertificate=True"));


builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "My api VI");
    });
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
