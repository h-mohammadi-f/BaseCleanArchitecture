using System.Diagnostics;
using System.Reflection;
using API.Extensions;
using API.Middleware;
using Application;
using Application.Abstractions;
using Application.Companies;
using Application.Core;
using Domain;
using FluentValidation.AspNetCore;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(typeof(ForDependecyInjection).Assembly));
builder.Services.AddAutoMapper(typeof(ForDependecyInjection).Assembly);
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddHttpContextAccessor();
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();

try
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppUserRole>>();
    //Applies any pending migrations for the context to the database. 
    //Will create the database if it does not already exist.
    await context.Database.MigrateAsync();
    await Seed.SeedDataAsync(userManager, roleManager);
}
catch (Exception ex)
{
    Debug.WriteLine(ex, "An error occured during migration");
}


// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
