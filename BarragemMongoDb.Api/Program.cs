using BarragemMongoDb.Application;
using BarragemMongoDb.Data;
using BarragemMongoDb.Domain;
using Carter;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddMongoDBClient(connectionName: Constants.MongoDB);

builder.Services.AddRepositories();
builder.Services.AddApplicationServices();

builder.Services.AddCarter();

var app = builder.Build();

app.MapDefaultEndpoints();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapCarter();

app.Run();

