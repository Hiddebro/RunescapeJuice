using Data_Access_Layer.Context;
using Business_logic_Layer.Container;
using Business_logic_Layer.Converters;
using Data_Access_Layer.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddScoped<Item_Container>();
builder.Services.AddScoped<User_Container>();
builder.Services.AddScoped<IItem_Context, Item_Context>();
builder.Services.AddScoped<IUser_Context, User_Context>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(1);
});
var app = builder.Build();

//private void ConfigureServices(IServiceCollection services)
//{
//    services.AddControllersWithViews();
//    services.AddSession(options => { options.IdleTimeout = TimeSpan.FromMinutes(1); });
//}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
