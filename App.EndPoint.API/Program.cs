using App.Domain.AppServices.Brand;
using App.Domain.AppServices.Category;
using App.Domain.AppServices.Product;
using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.Brand.Contracts.AppServices;
using App.Domain.Core.Brand.Contracts.Repositories;
using App.Domain.Core.Brand.Contracts.Services;
using App.Domain.Core.Category.Contracts.AppServices;
using App.Domain.Core.Category.Contracts.Repositories;
using App.Domain.Core.Category.Contracts.Services;
using App.Domain.Core.Permision.Contracts.Repositories;
using App.Domain.Core.Permision.Contracts.Srervices;
using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.Services.BaseData;
using App.Domain.Services.Brand;
using App.Domain.Services.Category;
using App.Domain.Services.Permision;
using App.Domain.Services.Product;
using App.Infarstructure.DataBase.SqlServer.Data;
using App.Infarstructure.DataBase.SqlServer.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<AppDbContext>(options =>
       options.UseSqlServer(
           "Server=.;Database=ShopProjectDB;Trusted_Connection=True;TrustServerCertificate=True;"
       ));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region Brand
builder.Services.AddScoped<IBrandAppService, BrandAppService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IBrandCommandRepository, BrandCommandRepository>();
builder.Services.AddScoped<IBrandQueryRepository, BrandQueryRepository>();
builder.Services.AddScoped<IBrandSurenessService, BrandSurenessService>();
#endregion Brand

#region Product
builder.Services.AddScoped<IProductAppService, ProductAppService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
builder.Services.AddScoped<IProductQueryRepository, ProductQueryRepository>();
#endregion Product

#region Category
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
builder.Services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();
#endregion Category


#region Colour
builder.Services.AddScoped<IColourQueryRepository, ColourQueryRepository>();
builder.Services.AddScoped<IColourCommandRepository, ColourCommandRepository>();
builder.Services.AddScoped<IColourService, ColourService>();
#endregion Colour
#region Permision
builder.Services.AddScoped<IPermisionRepository, PermisionRepository>();
builder.Services.AddScoped<IPermisionService, PermisionService>();
#endregion Permision

#region SureNess
builder.Services.AddScoped<ICategorySurenessService, CategorySurenessService>();
#endregion SureNess

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();