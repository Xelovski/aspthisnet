using WebApplication2.Datalayer;
using WebApplication2.Datalayer.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


while (true)
{
    /*
    using (var db = new AppDbContext())
    {
        db.Database.EnsureCreated();
        var user = new UserEntity { Name = "Speller", Email = "sp@gogle.crw" };
        db.Users.Add(user);
        db.SaveChanges();
        Console.WriteLine("\nUsers:");
        var users = db.Users.ToList();
        foreach (var u in users)
        {
            Console.WriteLine($"ID:{u.Id},Jmeno:{u.Name},Emil:{u.Email}");
        }
        Console.WriteLine("");
    }*/
    break;
}
app.Run();