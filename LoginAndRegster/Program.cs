
using LoginAndRegster.Servisec.Categorys;
using LoginAndRegster.Servisec.Contacts;
using LoginAndRegster.Servisec.Customers;
using LoginAndRegster.Servisec.Employees;
using LoginAndRegster.Servisec.Products;
using LoginAndRegster.Servisec.Roles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(
        builder.Configuration.GetConnectionString("MyConnection")
    ));



builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", option =>
{
    option.Cookie.Name = "MyCookieAuth";
    option.LoginPath = "/Customer/Account/Login";
    option.AccessDeniedPath = "/Customer/Account/Login";
});

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("Admin",
        Policy => Policy.RequireRole("Admin"));

    option.AddPolicy("SuperAdmin",
        Policy => Policy.RequireRole("SuperAdmin"));

    option.AddPolicy("User",
        Policy => Policy.RequireRole("User"));

});

builder.Services.AddScoped<IRoleServices, RoleServices>();
builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddScoped<IContactServices, ContactServices>();
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
           name: "areas",
           pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}"
         );



app.Run();
