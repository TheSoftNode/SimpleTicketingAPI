using Microsoft.EntityFrameworkCore;
using SimpleTicketingAPI.Core.AutoMapperConfig;
using SimpleTicketingAPI.Core.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Config Database
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
	var connectionString = builder.Configuration.GetConnectionString("local");
	options.UseSqlServer(connectionString);
});

// Config AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfigProfile));

builder.Services.AddCors(p => p.AddDefaultPolicy(build =>
{
	build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

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

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
