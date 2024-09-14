using Authorization.Services.Data;
using Authentication.Services.Tokens;
using Authentication.Services.Data.SqlServer.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Guid userId = Guid.NewGuid();
string token = MainTokenServices.GenerateToken(userId);

var tokenRepository = new TokenRepository();

builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", o => {
        o.Cookie.Name = "Token";
        o.ExpireTimeSpan = TimeSpan.FromDays(90);
        o.Cookie.HttpOnly = true;
        o.SlidingExpiration = true;
        o.Cookie.SameSite = SameSiteMode.None;
        o.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        o.Events.OnRedirectToLogin = context => {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddControllers();

builder.Services.AddCors();

var sqlServerConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<GroupsTestDbContext>(o =>
    o.UseSqlServer(sqlServerConnection));

builder.Services.AddHttpContextAccessor();

builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokensDatabase"));

var app = builder.Build();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(x => 
    x.WithOrigins("http://localhost:5000/",
        "https://localhost:3000")    
    .AllowCredentials()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseCsp(o => o
    .DefaultSources(s => s.Self())
    .ConnectSources(s => s.Self())
);

app.Run();