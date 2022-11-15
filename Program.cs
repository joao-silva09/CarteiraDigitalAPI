global using CarteiraDigitalAPI.Models;
using CarteiraDigitalAPI.Data;
using CarteiraDigitalAPI.Services.CategoriaService;
using CarteiraDigitalAPI.Services.ContaService;
using CarteiraDigitalAPI.Services.DividaService;
using CarteiraDigitalAPI.Services.ObjetivoService;
using CarteiraDigitalAPI.Services.OperacaoService;
using CarteiraDigitalAPI.Services.PlanejamentoService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer Scheme, e.g. \"bearer {token} \"",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    ;

    c.OperationFilter<SecurityRequirementsOperationFilter>();

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IContaService, ContaService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
//builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IDividaService, DividaService>();
builder.Services.AddScoped<IObjetivoService, ObjetivoService>();
builder.Services.AddScoped<IOperacaoService, OperacaoService>();
builder.Services.AddScoped<IPlanejamentoService, PlanejamentoService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.ASCIIEncoding.UTF8
            .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
        ValidateIssuer = false,
        ValidateAudience = false,
    });
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseAuthorization();


app.MapControllers();

app.Run();
