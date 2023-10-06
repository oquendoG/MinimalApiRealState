using Microsoft.EntityFrameworkCore;
using MinimalApiRealState.Data;
using MinimalApiRealState.Extensions;
using MinimalApiRealState.Feats.Properties;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt => 
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("connection"));
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAppExtesions();

var app = builder.Build();
app.AddPropertyEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();