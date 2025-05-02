using webApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.ConfigureControllers();
builder.ConfigureSwagger();
builder.ConfigureDbContext();
builder.ConfigureServices();

var app = builder.Build();
// Add services to the container.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMetricServer();
//app.UseHttpMetrics();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

