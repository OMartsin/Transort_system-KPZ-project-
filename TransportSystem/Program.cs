using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TransportSystem;
using TransportSystem.Models;
using TransportSystem.Services;
using TransportSystem.Services.DriverService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<TransportSystemContext>();
builder.Services.AddSingleton<IUserTokenGenerator, UserTokenGenerator>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();  
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new() { Title = "TransportSystem", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter JWT Token with Bearer into field"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference() {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("AdminOnly", policy => policy.RequireRole("administrator"));
        options.AddPolicy("AgentOnly", policy => policy.RequireRole("agent"));
        options.AddPolicy("DriverOnly", policy => policy.RequireRole("driver"));
    });
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
