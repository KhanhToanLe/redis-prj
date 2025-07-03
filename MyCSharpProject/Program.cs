using MyCSharpProject.Helper;

var builder = WebApplication.CreateBuilder(args);

var configString = $"{builder.Configuration["Redis:Host"]}:{builder.Configuration["Redis:Port"]},password={builder.Configuration["Redis:Password"]}";
Console.WriteLine(configString);

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = configString;
    options.InstanceName = "MyCSharpProject_";
});


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddServiceFromDJHelper();

var app = builder.Build();
app.MapGet("", () =>
{
    return "Hello world minimal";
});

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
