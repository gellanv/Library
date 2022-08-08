using Library.Data;
using Library.Mappings;
using Library.Services;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApiDBContext>
(o => o.UseInMemoryDatabase("MyDatabase"));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<ReviewService>();
builder.Services.AddScoped<RatingService>();

var app = builder.Build();

MockData.AddCustomerData(app);


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();