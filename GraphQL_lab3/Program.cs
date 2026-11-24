using GraphQL.DataAccess.DAO;
using GraphQL.DataAccess.Data;
using GraphQL.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Query = GraphQL.DataAccess.Data.Query;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);

// Подключение PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Регистрация репозиториев DAO
builder.Services.AddScoped<AuthorRepository>();
builder.Services.AddScoped<RubricRepository>();
builder.Services.AddScoped<IssueRepository>();
builder.Services.AddScoped<ArticleRepository>();

// Настройка GraphQL сервера
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGraphQL();

app.Run();
