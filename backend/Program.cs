using backend.src.Authorization;
using backend.src.Database;
using backend.src.Middlewares;
using backend.src.Repositories.AuthRepo;
using backend.src.Repositories.CategoryRepo;
using backend.src.Repositories.ProductRepo;
using backend.src.Repositories.UserRepo;
using backend.src.Services.AuthService;
using backend.src.Services.CategoryService;
using backend.src.Services.ProductService;
using backend.src.Services.UserService;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options => 
{
    options.AddSecurityDefinition(
        "oauth2",
        new OpenApiSecurityScheme
        {
            Description = "Bearer token authentication",
            Name = "Authorization",
            In = ParameterLocation.Header
        }
    );
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddDbContext<DatabaseContext>();

builder.Services.Configure<RouteOptions>(options => 
{
    options.LowercaseUrls = true;
});

// adding automapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services
    .AddScoped<IAuthRepo, AuthRepo>()
    .AddScoped<IAuthService, AuthService>()
    .AddScoped<IUserRepo, UserRepo>()
    .AddScoped<IUserService, UserService>()
    .AddScoped<IProductRepo, ProductRepo>()
    .AddScoped<IProductService, ProductService>()
    .AddScoped<ICategoryRepo, CategoryRepo>()
    .AddScoped<ICategoryService, CategoryService>();

builder.Services.AddTransient<ErrorHandlerMiddleware>();

builder.Services.AddTransient<IAuthorizationHandler, UpdateUserHandler>();

//add configuration for authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => 
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("AppSettings:Token").Value!
            )),
            ValidateIssuer = false, 
            ValidateAudience = false
        };
    });

builder.Services.AddAuthorization(options => 
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("AdminOrOwner", policy => policy.AddRequirements(new UpdateUserRequirement{}));
});

//adding cors policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://localhost:5131")
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});

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

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithExposedHeaders("Content-Disposition")
    .SetPreflightMaxAge(TimeSpan.FromMinutes(10))
);

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
