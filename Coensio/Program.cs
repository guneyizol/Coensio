using Coensio.Contexts;
using Coensio.Models;
using Coensio.Repositories;
using Coensio.Repository;
using Coensio.Services;

using EntityFramework.Exceptions.PostgreSQL;

using MassTransit;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

using StackExchange.Redis;

using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var jwtOptionsSection = builder.Configuration.GetRequiredSection("Jwt");
builder.Services.Configure<JwtOptions>(jwtOptionsSection);

builder.Services.AddAuthentication().AddJwtBearer(opts =>
{
    var key = jwtOptionsSection["Secret"] ?? string.Empty;

    opts.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
        ValidIssuer = jwtOptionsSection["Issuer"],
        ValidAudience = jwtOptionsSection["Audience"],
    };
});
builder.Services.AddAuthorization();

builder.Services.AddSingleton<JsonWebTokenHandler>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<IJwtRepository, JwtRepository>();
builder.Services.AddScoped<ITestRepository, TestRepository>();
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<IAnswerService, AnswerService>();

var redisConnString = $"{builder.Configuration["REDIS_HOST"]}:{builder.Configuration["REDIS_PORT"]}";
builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnString));

builder.Services.AddDbContext<TestContext>(opts =>
    opts.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"))
    .UseSnakeCaseNamingConvention()
    .UseExceptionProcessor());

var rabbitHost = builder.Configuration["RABBITMQ_HOST"];
var rabbitUsername = builder.Configuration["RABBITMQ_USERNAME"];
var rabbitPassword = builder.Configuration["RABBITMQ_PASSWORD"];

builder.Services.AddMassTransit(x =>
{
    x.SetKebabCaseEndpointNameFormatter();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(rabbitHost, "/", h =>
        {
            h.Username(rabbitUsername ?? string.Empty);
            h.Password(rabbitPassword ?? string.Empty);
        });

        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers(opts =>
    opts.SuppressAsyncSuffixInActionNames = false);

builder.Services.Configure<JsonOptions>(opts =>
    opts.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts =>
{
    opts.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Coensio API",
        Version = "v1"
    });

    var security = new OpenApiSecurityScheme
    {
        Name = HeaderNames.Authorization,
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Description = "JWT Authorization header",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme,
        },
    };

    opts.AddSecurityDefinition(security.Reference.Id, security);
    opts.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {security, Array.Empty<string>()}
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
