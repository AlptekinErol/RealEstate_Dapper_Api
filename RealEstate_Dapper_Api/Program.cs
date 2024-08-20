using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.BottomGridRepositories;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.EmployeeRepositories;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepositories;
using RealEstate_Dapper_Api.Repositories.ProductRepository;
using RealEstate_Dapper_Api.Repositories.ServiceRepository;
using RealEstate_Dapper_Api.Repositories.StatisticRepositories;
using RealEstate_Dapper_Api.Repositories.TestimonialRepositories;
using RealEstate_Dapper_Api.Repositories.WhoWeAreDetailRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ICategoryRepository,CategoryRepository>(); // param ( Interface , Class )
builder.Services.AddTransient<IProductRepository,ProductRepository>(); // param ( Interface , Class )
builder.Services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>(); // param ( Interface , Class )
builder.Services.AddTransient<IServiceRepository, ServiceRepository>(); // param ( Interface , Class )
builder.Services.AddTransient<IBottomGridRepository, BottomGridRepository>(); // param ( Interface , Class )
builder.Services.AddTransient<IPopularLocationRepository, PopularLocationRepository>(); // param ( Interface , Class )
builder.Services.AddTransient<ITestimonialRepository, TestimonialRepository>(); // param ( Interface , Class )
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>(); // param ( Interface , Class )
builder.Services.AddTransient<IStatisticsRepository, StatisticsRepository>(); // param ( Interface , Class )


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
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
