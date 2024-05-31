using BLL.LogicServices.Contract;
using BLL.Services;
using DAL.DataContext;
using DAL.DataContext.Contract;
using DAL.DataServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IStudentLogic, StudentLogic>();
builder.Services.AddSingleton<IStudentDataDAL, StudentDataDAL>();
builder.Services.AddSingleton<IDapperHelper, DapperHelper>();


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

app.Run();
