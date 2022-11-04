using ContainerLabs1.Api.Domain;
using ContainerLabs1.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ApiContextMySql");
var serverVersion = ServerVersion.AutoDetect(connectionString);
builder.Services.AddDbContext<ApiDbContext>(options =>
 options.UseMySql(connectionString, serverVersion)
);

builder.Services.AddTransient<ILogTasks, EfLogTasks>();

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

    using(var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<ApiDbContext>();
        context.Database.EnsureCreated();
        ApiDbInitializer.Initialize(context);
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
