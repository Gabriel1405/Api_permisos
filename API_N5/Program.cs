using Application.Contracts;
using Application.Services;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ElasticService>();
builder.Services.AddScoped<IPermisosService, PermisosService>();
builder.Services.AddScoped<ITipoPermisosService, TipoPermisosService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add services to the container.
//string connectionString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SeguridadContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"))
);



builder.Services.AddScoped<IUnitOfWork>(sp =>
    new ApplicationUnitOfWork(
        builder.Configuration.GetConnectionString("DbConnection"))
);

var app = builder.Build();

//solo se ejecuta la primera ves para la migracion de la BD
/*
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SeguridadContext>();
    context.Database.Migrate();
}
*/



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();  
    }

app.UseCors("AllowLocalhost");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



public partial class Program { }