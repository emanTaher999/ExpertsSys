using Microsoft.EntityFrameworkCore;
using SudaneseExpSYS.Data;
using SudaneseExpSYS.Repository;
using SudaneseExpSYS.Repository.Base;
using Microsoft.AspNetCore.Identity;
using NToastNotify;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNToastNotifyToastr(new NToastNotify.ToastrOptions()
{
    ProgressBar = true,
    CloseButton = true,
    PositionClass = ToastPositions.TopLeft,
    PreventDuplicates= true
}) ; 

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
 builder.Configuration.GetConnectionString("MyConnection")));



builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();



builder.Services.AddScoped(typeof(IRepositroy<>), typeof(MainRepository<>));

var app = builder.Build();

app.UseNToastNotify();

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

app.Use(async (context, next) =>
   {
    string cookie = string.Empty;
    if(context.Request.Cookies.TryGetValue("Language", out cookie))
       {
           System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookie);
           System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookie);
       }
       else
       {
           System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ar");
           System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ar");
       }
       await next.Invoke();
   });

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoint => endpoint.MapRazorPages());

app.Run();
