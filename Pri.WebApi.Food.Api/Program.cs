using Pri.WebApi.Food.Api.Repositories.Interfaces;
using Pri.WebApi.Food.Api.Repositories;
using Pri.WebApi.Food.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabase")));

builder.Services.AddCors();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(builder => builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
