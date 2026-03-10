using MVCWEB.Data;
using MVCWEB.Services;
using MVCWEB.Services.Abstract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/** |                           |
 *  |   DATABASE CONFIGURATION  |
 *  |                           |
 */
builder.Services.AddSingleton<DapperContext>();

builder.Services.AddScoped<IItemService, ItemService>();

builder.Services.AddSignalR();


var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.Run();
