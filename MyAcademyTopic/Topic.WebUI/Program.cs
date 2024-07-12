var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient();  // controllerda httpclient kullancaksak mutlaka program.cs de dahil etmemiz gereklidir

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


app.UseEndpoints(endpoints =>  // area oluþtuðunda çýkan ScaffoldingReadMe.txt dosyasýndaki kod parçasýný areanýn çalýþmasý için mutlaka program.cs'e eklememiz gerek
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Category}/{action=Index}/{id?}"
    );
});

app.Run();
