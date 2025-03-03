using Microsoft.EntityFrameworkCore;
using Mission08_Team0106.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Add DbContext
builder.Services.AddDbContext<TaskContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("TaskConnection"));
});

builder.Services.AddScoped<ITaskRepository, EFTaskRepository>(); // each http request gets its own repo object

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Remove this line for now to test HTTP-only mode:
// app.UseHttpsRedirection(); 

app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Quadrants}/{action=Index}/{id?}");

app.Run();
