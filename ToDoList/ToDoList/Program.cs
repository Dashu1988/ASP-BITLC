using ToDoList.Models;

var builder = WebApplication.CreateBuilder(args);
//Debug data
for (int i = 0; i < 10; i++)
{
    Random random = new Random();
    ToDoTask temp = new ToDoTask();
    temp.title = $"Test{i}";
    temp.description = $"description{i}";
    temp.dueDate = DateOnly.FromDateTime(DateTime.Now);
    temp.dueDate = temp.dueDate.AddDays(random.Next(1, 10));
    temp.done = random.Next(2) == 1;
    ToDoTask.AllTasks.Add(temp);
}


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
        pattern: "{controller=Home}/{action=ToDoShow}/{id?}")
    .WithStaticAssets();


app.Run();