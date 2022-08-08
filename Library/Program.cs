using Library.Behaviors;
using Library.Data;
using Library.Mappings;
using Library.Middleware;
using Library.Services;
using Microsoft.AspNetCore.HttpLogging;
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
builder.Services.AddScoped<SaveBookRequestValidation>();
builder.Services.AddScoped<SaveReviewRequestValidation>();
builder.Services.AddScoped<VariableValidation>();

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.ResponseHeaders.Add("Server");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});

var app = builder.Build();

MockData.AddCustomerData(app);


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpLogging();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware(typeof(ExceptionHandlingMiddleware));

app.Run();