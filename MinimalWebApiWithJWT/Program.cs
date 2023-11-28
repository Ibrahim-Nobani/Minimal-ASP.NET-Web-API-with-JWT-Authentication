using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MinimalWebApi.Database;
using MinimalWebApi.Authorization;
using MinimalWebApi.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MinimalWebApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UsersDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnectionString"));
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ITokenService, JwtTokenGenerator>();
builder.Services.Configure<JwtTokenConfig>(builder.Configuration.GetSection("JWTToken"));

var jwtConfig = builder.Configuration.GetSection("JWTToken").Get<JwtTokenConfig>() ?? throw new ArgumentNullException("JWTToken:Wrong Configuration");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var key = new SymmetricSecurityKey(Convert.FromBase64String(jwtConfig.SecretKey));

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtConfig.Issuer,
            ValidAudience = jwtConfig.Audience,
            IssuerSigningKey = key
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

app.Run();
