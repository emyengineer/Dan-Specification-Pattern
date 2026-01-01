using CatalogAPI.Models;
using CatalogAPI.Repositories;
using CatalogAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductContext>(static options =>
    {
        options.UseSqlite("Data Source=globomantics.db");
    });

builder.Services.AddControllers();
builder.Services.AddScoped<ProductValidationService>();
builder.Services.AddScoped<ProductRepository>();

var app = builder.Build();
// Ensure database is created and seeded
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ProductContext>();
    context.Database.EnsureCreated();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.Urls.Add("http://localhost:5234");
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.MapControllers();

app.Run();
