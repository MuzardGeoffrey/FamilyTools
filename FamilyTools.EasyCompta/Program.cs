using EasyCompta.Server.Business;
using EasyCompta.Server.Data;
using EasyCompta.Server.IBusiness;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddScoped<IUserBusiness, UserBusiness>();
builder.Services.AddScoped<ITemplateBusiness, TemplateBusiness>();
builder.Services.AddScoped<IAccountTagBusiness, AccountTagBusiness>();
builder.Services.AddScoped<IAccountPageBusiness, AccountPageBusiness>();
builder.Services.AddScoped<IAccountEnterBusiness, AccountEnterBusiness>();
builder.Services.AddScoped<IAccountLineBusiness, AccountLineBusiness>();

builder.AddSqlServerDbContext<AccountContext>("EasyCompta");

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
