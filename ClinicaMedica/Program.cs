using ClinicaMedica.Data;
using ClinicaMedica.DTOs.Basic;
using ClinicaMedica.DTOs.Create;
using ClinicaMedica.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirBlazor",
        builder =>
        {
            builder.WithOrigins("https://localhost:7047") // Cambia por el origen de tu aplicación Blazor
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});


// Add services to the container.
string strCon = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(strCon));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        }
    
    );

builder.Services.AddAutoMapper(configuration =>
{
    configuration.CreateMap<Especialidades, EspecialidadesCreacionDTO>().ReverseMap();
    configuration.CreateMap<Especialidades, EspecialidadesDTO>().ReverseMap();
    configuration.CreateMap<Medicos, MedicosDTO>().ReverseMap();
    configuration.CreateMap<Personas, PersonasDTO>().ReverseMap();
    configuration.CreateMap<Medicos, MedicosCreacionDTO>().ReverseMap();
    configuration.CreateMap<Personas, PersonasCreacionDTO>().ReverseMap();
    configuration.CreateMap<Pacientes, PacientesCreacionDTO>().ReverseMap();
    configuration.CreateMap<Pacientes, PacientesDTO>().ReverseMap();
    configuration.CreateMap<CitasMedicas, CitasMedicasCreacionDTO>();
    configuration.CreateMap<Servicios, ServiciosCreacionDTO>().ReverseMap();
    configuration.CreateMap<Servicios, ServiciosDTO>().ReverseMap();
    configuration.CreateMap<CitasMedicas, CitasMedicasCreacionDTO>().ReverseMap();
    configuration.CreateMap<CitasMedicas, CitasMedicasDTO>().ReverseMap();
    configuration.CreateMap<DetalleCitas, DetalleCitasDTO>().ReverseMap();
    configuration.CreateMap<DetalleCitas, DetalleCitasCreacionDTO>().ReverseMap();
    configuration.CreateMap<Horarios, HorariosCreacionDTO>().ReverseMap();
    configuration.CreateMap<Horarios, HorariosDTO>().ReverseMap();
    configuration.CreateMap<Turnos, TurnosDTO>().ReverseMap();
    configuration.CreateMap<Turnos, TurnosCreacionDTO>().ReverseMap();
    configuration.CreateMap<Servicios, ServiciosDTO>().ReverseMap();
    configuration.CreateMap<Servicios, ServiciosCreacionDTO>().ReverseMap();
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.MapType<TimeSpan>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "time-span",
        Example = new OpenApiString("08:00:00")
    });

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Cuentas Individuales",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = $@"JWT Authorization header using the Bearer scheme. 
        \r\n\r\n Enter prefix (Bearer), space, and then your token. Example 'Bearer 13234hh3'"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{ }
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("PermitirBlazor");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
