var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<QRCodeService.QRCodeService>();
builder.Services.AddTransient<QRCodeService.QRCodeService>();

builder.Services.AddScoped<BarCodeService.BarCodeService>();
builder.Services.AddTransient<BarCodeService.BarCodeService>();
builder.Services.AddLogging(); // Add this line to configure logging

builder.Services.AddLogging(builder =>
{
    builder.AddConsole(); // Use the appropriate logging provider
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
