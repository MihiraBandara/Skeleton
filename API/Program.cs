using Skeleton.Api.Extensions;
using Skeleton.Application;
using Skeleton.Utility;
using Skeleton.Persistance;
using Skeleton.Persistance.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigurePersistenceService(configuration);
builder.Services.ConfigureApplicationService();
builder.Services.ConfigureUtilityService(builder);

var app = builder.Build();

app.MapEndpoint();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MigrateDatabase();
}

app.UseHttpsRedirection();

app.Run();