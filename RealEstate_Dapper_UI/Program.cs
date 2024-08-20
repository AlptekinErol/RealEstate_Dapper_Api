using RealEstate_Dapper_UI.UIServices.CategoryStatisticServices;
using RealEstate_Dapper_UI.UIServices.CompositeDashboardService;
using RealEstate_Dapper_UI.UIServices.EmployeeStatisticServices;
using RealEstate_Dapper_UI.UIServices.ProductDetailsServices;
using RealEstate_Dapper_UI.UIServices.ProductStatisticService;

var builder = WebApplication.CreateBuilder(args);

// Servislerin üst sýnýfý olan composite servis
builder.Services.AddTransient<IDashboardService, DashboardService>();


// istatiksel servislerin tanýmlamalarý
builder.Services.AddTransient<IEmployeeStatisticService, EmployeeStatisticService>();
builder.Services.AddTransient<IProductStatisticService, ProductStatisticService>();
builder.Services.AddTransient<IProductDetailService, ProductDetailService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
