using backend.src.Database;
using backend.src.Repositories.CategoryRepo;
using backend.src.Repositories.ProductRepo;
using backend.src.Repositories.UserRepo;
using backend.src.Services.CategoryService;
using backend.src.Services.ProductService;
using backend.src.Services.UserService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add configure to redirect http to https

builder.WebHost.UseKestrel(options =>
{
    options.ListenLocalhost(5000);
    options.ListenLocalhost(5001, options => options.UseHttps());
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>();

builder.Services.Configure<RouteOptions>(options => 
{
    options.LowercaseUrls = true;
});

// adding automapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services
    .AddScoped<IUserRepo, UserRepo>()
    .AddScoped<IUserService, UserService>()
    .AddScoped<IProductRepo, ProductRepo>()
    .AddScoped<IProductService, ProductService>()
    .AddScoped<ICategoryRepo, CategoryRepo>()
    .AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "NhuStore");    
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
