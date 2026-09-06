using System.Diagnostics;

using LUFTBORN.Api;
using LUFTBORN.Application;
using LUFTBORN.Infrastructure;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

using System.Security.Claims;
using System.Text.Json;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            var kc = builder.Configuration.GetSection("Keycloak");
            options.Authority = kc["Authority"];
            options.MetadataAddress = kc["MetadataAddress"] ?? string.Empty;
            options.RequireHttpsMetadata = false;

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = kc["Authority"],
                ValidateAudience = true,
                ValidAudience = kc["ClientId"], 

                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(30)
            };

            options.Events = new JwtBearerEvents
            {
                OnTokenValidated = context =>
                {
                    var identity = context.Principal!.Identity as ClaimsIdentity;
                    if (identity is null) return Task.CompletedTask;
                    
                    var realmAccess = identity.FindFirst("realm_access")?.Value;
                    if (realmAccess is not null)
                    {
                        using var doc = JsonDocument.Parse(realmAccess);
                        if (doc.RootElement.TryGetProperty("roles", out var roles))
                            foreach (var role in roles.EnumerateArray())
                                identity.AddClaim(new Claim(ClaimTypes.Role, role.GetString()!));
                    }

                    var resourceAccess = identity.FindFirst("resource_access")?.Value;
                    if (resourceAccess is not null)
                    {
                        using var doc = JsonDocument.Parse(resourceAccess);
                        if (doc.RootElement.TryGetProperty("luftborn-api", out var client) &&
                            client.TryGetProperty("roles", out var clientRoles))
                            foreach (var role in clientRoles.EnumerateArray())
                                identity.AddClaim(new Claim(ClaimTypes.Role, role.GetString()!));
                    }

                    return Task.CompletedTask;
                },
                OnAuthenticationFailed = context =>
                {
                    Console.WriteLine($"[JWT] Auth failed: {context.Exception.Message}");
                    return Task.CompletedTask;
                }
            };
        });
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AngularApp", policy =>
            policy.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod());
    });
    builder.Services.AddAuthorization();

    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    app.UseExceptionHandler();
    app.UseInfrastructure();
    app.UseCors("AngularApp");
    app.UseAuthentication();
    app.UseAuthorization();

    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "LUFTBORN API V1");
            options.RoutePrefix = "swagger";
        });
    }

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}