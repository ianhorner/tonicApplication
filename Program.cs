using TonicApplication.EF;
using TonicApplication.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



/// TODO remove

//var db = new TodoContext();
//db.Add(new TodoItem
//{
//    Text = "My text 2",
//    IsComplete = false
//});
//db.SaveChanges();

//var items = db.TodoItems.ToList();

///

app.Run();
