using AutoMapper;
using ClinicaMedica.DTOs.Basic;
using ClinicaMedica.DTOs.Create;
using ClinicaMedica.Entities;

namespace ClinicaMedica.Utilities
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile() 
        {
            CreateMap<Especialidades, EspecialidadesCreacionDTO>().ReverseMap();
            CreateMap<Especialidades, EspecialidadesDTO>().ReverseMap();
            CreateMap<Medicos, MedicosDTO>().ReverseMap();
            CreateMap<Personas, PersonasDTO>().ReverseMap();
            CreateMap<Medicos, MedicosCreacionDTO>().ReverseMap();
            CreateMap<Personas, PersonasCreacionDTO>().ReverseMap();
            CreateMap<Pacientes, PacientesCreacionDTO>().ReverseMap();
            CreateMap<Pacientes, PacientesDTO>().ReverseMap();
            CreateMap<CitasMedicas, CitasMedicasCreacionDTO>();
            CreateMap<Servicios, ServiciosCreacionDTO>().ReverseMap();
            CreateMap<Servicios, ServiciosDTO>().ReverseMap();
            CreateMap<CitasMedicas, CitasMedicasCreacionDTO>().ReverseMap();
            CreateMap<CitasMedicas, CitasMedicasDTO>().ReverseMap();
            CreateMap<DetalleCitas, DetalleCitasDTO>().ReverseMap();
            CreateMap<DetalleCitas, DetalleCitasCreacionDTO>().ReverseMap();
            CreateMap<Horarios, HorariosCreacionDTO>().ReverseMap();
            CreateMap<Horarios, HorariosDTO>().ReverseMap();
            CreateMap<Turnos, TurnosDTO>().ReverseMap();
            CreateMap<Turnos, TurnosCreacionDTO>().ReverseMap();
            CreateMap<Servicios, ServiciosDTO>().ReverseMap();
            CreateMap<Servicios, ServiciosCreacionDTO>().ReverseMap();
        }
    }
}
