using Spark.Library.Environment;
using Spark.Library.Config;
using InertiaSparkTest.Application.Startup;
using InertiaCore.Extensions;
using System.Globalization;
using InertiaSparkTest.Application.Middleware;

EnvManager.LoadConfig();

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.SetupSparkConfig();
builder.Services.AddAppServices(builder.Configuration);
builder.Services.AddInertia();

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
app.UseInertia();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseInertiaSharedProps();

app.Services.RegisterScheduledJobs();
app.Services.RegisterEvents();

app.Run();
