using ApiMyArquivos.Core.Config;
using ApiMyArquivos.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigRepository.ConfigurarRepositorys(builder.Services);
var connectionString = builder.Configuration.GetConnectionString("ConexaoBanco");

builder.Services.AddDbContext<DatabaseAPI>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors((corsPoliceBuilder) =>
{
    corsPoliceBuilder.AllowAnyHeader();
    corsPoliceBuilder.AllowAnyMethod();
    corsPoliceBuilder.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
