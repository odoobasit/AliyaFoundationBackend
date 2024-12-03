using Microsoft.EntityFrameworkCore;
using AF.Data;
using AF.Repositories;
using Microsoft.Extensions.DependencyInjection;
using AF.Data;
using AF.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register ApplicationDbContext with SQL Server (or another DB)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories with dependency injection (DI)
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IDonationsRepository, DonationsRepository>();
builder.Services.AddScoped<IFundRaisingRepository, FundRaisingRepository>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IArticleCategoriesRepository, ArticleCategoriesRepository>();


// Add other services like authentication, Swagger, etc., if needed
// builder.Services.AddAuthentication().AddJwtBearer(...);
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // Enable Swagger in development
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
