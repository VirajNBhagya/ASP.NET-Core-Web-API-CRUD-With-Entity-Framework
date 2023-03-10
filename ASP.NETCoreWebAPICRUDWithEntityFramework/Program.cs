using ASP.NETCoreWebAPICRUD.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Use InMemory DB 
//builder.Services.AddDbContext<AddAPIDbContext>(options=>options.UseInMemoryDatabase("ContactDB"));

builder.Services.AddDbContext<AddAPIDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("con")));

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
