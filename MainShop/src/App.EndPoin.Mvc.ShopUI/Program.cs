using App.Domain.AppServices.Brand;
using App.Domain.AppServices.Category;
using App.Domain.AppServices.Product;
using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.Brand.Contracts.AppServices;
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
using App.EndPoint.Mvc.ShopUI.Areas.Admin.Data.Contract.Service;
using App.Infarstructure.DataBase.SqlServer.Data;
using App.Infarstructure.DataBase.SqlServer.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews();
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(
            "Server=.;Database=ShopProjectDB;Trusted_Connection=True;TrustServerCertificate=True;"
        ));
    builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
    #region BaseData


    #endregion BaseData

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

    #region File
    builder.Services.AddScoped<IFileStorageService, FileStorageService>();
    #endregion File
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






    // Configure the HTTP request pipeline.
    var app = builder.Build();
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    app.UseHttpsRedirection();
    app.UseRouting();

    app.UseAuthorization();

    app.MapStaticAssets();


    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
          name: "areas",
          pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
        );
        endpoints.MapControllerRoute(
         name: "default",
         pattern: "{controller=Home}/{action=Index}/{id?}"
       );
    });

    app.Run();
}