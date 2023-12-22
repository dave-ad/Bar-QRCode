var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<QRCodeService.QRCodeService>();
builder.Services.AddTransient<QRCodeService.QRCodeService>();
builder.Services.AddLogging(); // Add this line to configure logging

builder.Services.AddLogging(builder =>
{
    builder.AddConsole(); // Use the appropriate logging provider
});

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
    pattern: "{controller=Home}/{action=CreateQRCode}/{id?}");

app.Run();
