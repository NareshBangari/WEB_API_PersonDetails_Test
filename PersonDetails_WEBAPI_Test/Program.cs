using PersonDetails_WEBAPI_Test.Services;
using PersonDetails_WEBAPI_Test.Middleware;
using PersonDetails_WEBAPI_Test.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddDbContext<DbContextClass>();

builder.Services.AddControllers();

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
//configure exception middleware

app.UseMiddleware(typeof(GlobalErrorHandlingMiddleware));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();