var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddScoped<QRCodeService.QRCodeService>();
builder.Services.AddTransient<QRCodeService.QRCodeService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// IronBarCode license configuration
IronBarCode.License.LicenseKey = "IRONSUITE.DAVID.ADEDOTUN.LMU.EDU.NG.17485-7D69CA260A-GFHOQ-M2YA3Q6P6A3C-SRTUWW6X6DMV-J4A7UZYFQHOQ-ISY6PFQDUUAS-PRQXS7YFMY2B-IAT7OYZPFKJS-PVUNGZ-TVAMQNVK35CLEA-DEPLOYMENT.TRIAL-ITDXEH.TRIAL.EXPIRES.06.JAN.2024";

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
