using Infrastructure.Data;
using Infrastructure.Contracts.Repositories;
using Infrastructure.Repositories;
using Infrastructure.Entities;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//add Controllers
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<DapperDbContext, DapperDbContext>();
builder.Services.AddSingleton<IRepository<Departments>, DepartmentRepository>();
builder.Services.AddSingleton<IRepository<Employees>, EmployeeRepository>();


var app = builder.Build();

// Add services to the container.

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
