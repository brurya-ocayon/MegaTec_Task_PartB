using System.Reflection;
using MegaTec_Task.Data;
using MegaTec_Task.Services;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;

QuestPDF.Settings.License = LicenseType.Community;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseWebRoot("wwwroot");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPersonService, PersonService>();

var app = builder.Build();

if (string.IsNullOrWhiteSpace(app.Environment.WebRootPath))
{
    var manualWebRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
    Directory.CreateDirectory(manualWebRoot);
    var prop = app.Environment.GetType().GetProperty("WebRootPath", BindingFlags.Public | BindingFlags.Instance);
    if (prop is { CanWrite: true })
        prop.SetValue(app.Environment, manualWebRoot);
}

var webRootForImages = app.Environment.WebRootPath
    ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
Directory.CreateDirectory(webRootForImages);

var imagesPath = Path.Combine(webRootForImages, "images");
if (File.Exists(imagesPath))
    File.Delete(imagesPath);
if (!Directory.Exists(imagesPath))
    Directory.CreateDirectory(imagesPath);

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();

app.Run();
