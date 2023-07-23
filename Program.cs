using SuperHeroAPI.Data;
using SuperHeroAPI.Services.SuperHeroServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// configure the db
builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
   );



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddControllers();

// register the Service and the Interface
builder.Services.AddScoped<ISuperHeros, SuperHeroServices>();








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
