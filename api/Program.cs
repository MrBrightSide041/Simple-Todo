var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = "server=127.0.0.1;user=root;password='';database=PrimeTodoDB";

// Replace with your server version and type.
// Use 'MariaDbServerVersion' for MariaDB.
// Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
// For common usages, see pull request #1233.
var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));

// Replace 'YourDbContext' with the name of your own DbContext derived class.
builder.Services.AddDbContext<DataContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(connectionString, serverVersion)
        // The following three options help with debugging, but should
        // be changed or removed for production.
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);

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
