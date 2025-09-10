using System.Text;
using InkFlow.Endpoint;
using InkFlow.Services.JWT;
using InkFlow.Services.Password;
using InkFlow.Services.TextValidation;
using InkFlow.UseCases.CreateProfile;
using InkFlow.UseCases.DeleteStory;
using InkFlow.UseCases.EditStory;
using InkFlow.UseCases.Login;
using InkFlow.UseCases.SearchReadList;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ThePixeler.Services.Profiles;

var builder = WebApplication.CreateBuilder(args);

// DBContext
builder.Services.AddDbContext<InkFlowDbContext>(options =>
{
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

//Services
builder.Services.AddSingleton<IJWTService, JWTService>();
builder.Services.AddTransient<IPasswordServices, PBKDF2PasswordService>();
builder.Services.AddTransient<IProfilesService, EFProfileService>();
builder.Services.AddTransient<ITextValidationService, TextValidationService>();

builder.Services.AddTransient<CreateProfileUseCase>();
builder.Services.AddTransient<CreateStoryUseCase>();
builder.Services.AddTransient<EditStoryUseCase>();
builder.Services.AddTransient<DeleteStoryUseCase>();
builder.Services.AddTransient<LoginUseCase>();
builder.Services.AddTransient<SearchReadListUseCase>();



// JWT Config
var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
var keyBytes = Encoding.UTF8.GetBytes(jwtSecret);
var key = new SymmetricSecurityKey(keyBytes);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = key
        };
    });

builder.Services.AddAuthorization();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
app.UseSwagger();      // Gera JSON da documentação
app.UseSwaggerUI();    // Interface web em /swagger

app.UseAuthentication();
app.UseAuthorization();

// Teste simples
app.MapGet("/", () => "Hello World!");
app.ConfigureReadListEndpoints();
app.ConfigureStoryEndpoints();
app.ConfigureUserEndpoints();

Console.WriteLine($"JWT Secret length: {jwtSecret?.Length}");



app.Run();
