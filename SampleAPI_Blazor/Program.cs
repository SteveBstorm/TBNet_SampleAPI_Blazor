using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SampleAPI_Blazor.Hubs;
using SampleAPI_Blazor.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

builder.Services.AddSingleton<MovieService>();
builder.Services.AddSingleton<AuthService>();
builder.Services.AddScoped<TokenManager>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(
            options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenManager.secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false
                };
            }
    );

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("user", policy => policy.RequireAuthenticatedUser());
});


builder.Services.AddCors(option => option.AddDefaultPolicy(
    o => o.AllowCredentials()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .WithOrigins("https://localhost:7123")
    ));


builder.Services.AddSingleton<ChatHub>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();
//app.UseCors(o => o.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapHub<ChatHub>("chathub");

app.Run();
