using Microsoft.EntityFrameworkCore;
using SwaggerThemes;
using TcitBackend.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configura el servicio de DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura el servicio de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://frontend")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

var app = builder.Build();

// Nos aseguramos que la bbdd este creada
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerThemes(Theme.Gruvbox);
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

// Aplica la pol�tica de CORS
//app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.Run();
