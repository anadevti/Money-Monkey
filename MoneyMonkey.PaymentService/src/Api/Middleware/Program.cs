using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MoneyMonkey.PaymentService.Application.Services;
using MoneyMonkey.PaymentService.Application.Mappings;
using MoneyMonkey.PaymentService.Infrastructure.Gateways;
using MoneyMonkey.PaymentService.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Configurações
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrando serviços da camada Application
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddScoped<IPaymentService, PaymentService>();

// Registrando camada de infraestrutura
builder.Services.AddScoped<IPaymentGateway, MockPaymentGateway>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
// Aqui você adicionaria contexto DynamoDB, SQS, etc.

// Construção da aplicação
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

app.Run();