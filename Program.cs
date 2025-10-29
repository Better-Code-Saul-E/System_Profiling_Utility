using System_Profiling_Utility.Services;
using System_Profiling_Utility.Services.Interfaces;
using Hardware.Info;

var builder = WebApplication.CreateBuilder(args);

// Register the Hardware.Info libarary
builder.Services.AddSingleton<IHardwareInfo, HardwareInfo>();

// Register the IProcessorService
builder.Services.AddScoped<IProcessorService, HardwareService>();


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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
