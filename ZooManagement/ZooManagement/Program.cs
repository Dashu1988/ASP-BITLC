using System.Data.SQLite;
using ZooManagement.Models;
using sql = ZooManagement.Models.SQLiteConn;
using gen = ZooManagement.Models.SQLDataGen;

var builder = WebApplication.CreateBuilder(args);


// List<Zoo> z = sql.ReadAllZoo();
// foreach (var zoo in z)
// {
//     Console.WriteLine(zoo.Name);
// }

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=ShowAllZoos}/{id?}")
    .WithStaticAssets();


app.Run();