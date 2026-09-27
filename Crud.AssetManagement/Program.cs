using Microsoft.AspNetCore.Builder;
using Wolverine;

var builder = WebApplication.CreateBuilder(args);

var startup = new Crud.AssetManagement.Startup(builder.Environment, builder.Configuration);
startup.ConfigureServices(builder.Services);
builder.Host.UseWolverine(startup.ConfigureWolverine);

var app = builder.Build();

startup.Configure(app, app.Environment);

app.Run();
