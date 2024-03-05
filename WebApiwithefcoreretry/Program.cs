using Microsoft.EntityFrameworkCore;
using WebApiwithefcoreretry.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BlogDBContext>(option => 
option.UseSqlServer("Data Source=.;Initial Catalog=Blogging;" +
"Integrated Security=True;TrustServerCertificate=True;" +
"Trusted_Connection=True;Connection Timeout=30;"

//providerOption => providerOption.EnableRetryOnFailure(5,
//TimeSpan.FromSeconds(5),null)
,
providerOption => providerOption.ExecutionStrategy
(x => new CustomExecutionStrategy(x,5,TimeSpan.FromSeconds(10)))

));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
