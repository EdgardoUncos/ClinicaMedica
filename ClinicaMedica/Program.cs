using ClinicaMedica.Data;
using ClinicaMedica.DTOs.Basic;
using ClinicaMedica.DTOs.Create;
using ClinicaMedica.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

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
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("PermitirBlazor");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
