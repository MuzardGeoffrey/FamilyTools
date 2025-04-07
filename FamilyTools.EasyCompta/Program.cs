using FamilyTools.EasyCompta.Business;
using FamilyTools.EasyCompta.DataBase.Context;
using FamilyTools.EasyCompta.IBusiness;

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

builder.AddSqlServerDbContext<AccountContext>("easycompta");

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

if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<AccountContext>();
        context.Database.EnsureCreated();
    }
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days.
    // You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Run();
