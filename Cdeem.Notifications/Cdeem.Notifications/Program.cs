using Cdeem.API.Infrastructure;
using Cdeem.Notifications.API.Subscribers;
using Microsoft.AspNetCore.Builder;
using SendGrid.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var configuration = builder.Configuration;

builder.Services.AddScoped<INotificationService, EmailService>();
builder.Services.AddSendGrid(options =>
{
    options.ApiKey = configuration.GetSection("SendGrid:ApiKey").Value;
});
builder.Services.AddHostedService<SkillNoteCreatedSubscriber>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
