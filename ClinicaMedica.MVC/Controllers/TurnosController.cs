using ClinicaMedica.Model.DTOs.Basic;
using ClinicaMedica.Model.DTOs.Create;
using ClinicaMedica.Model.ViewModel;
using ClinicaMedica.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClinicaMedica.MVC.Controllers
{
    public class TurnosController : Controller
    {
        HttpClient client;

        public TurnosController(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient("MyApiClient");
        }
        
        // GET: TurnosController
        public async Task<ActionResult> Index()
        {
            var response = await client.GetAsync("api/Turnos");
            if (response.IsSuccessStatusCode)
            {
                var des = await response.Content.ReadAsAsync<List<TurnosDTO>>();
                return View(des);
            }
            
            return View(null);
        }

        // GET: TurnosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TurnosController/Create
        public async Task<ActionResult> Create(int id)
        {
            TurnosDTO turnosDTO = new TurnosDTO();
            TurnosVM turno = new TurnosVM();

            try
            {
                var res = await client.GetFromJsonAsync<PacientesDTO>("api/Pacientes/" + id);
                turno.Paciente = await client.GetFromJsonAsync<PacientesDTO>("api/Pacientes/" + id);
                var servicios = await client.GetFromJsonAsync<List<ServiciosDTO>>("api/Servicios");

                ViewBag.Servicios = servicios.ConvertAll(s =>
                {
                    return new SelectListItem()
                    {
                        Text = s.Nombre,
                        Value = s.ServicioId.ToString(),
                        Selected = false
                    };
                });

                return View(turno);
            }
            catch (Exception ex)
            {

                return View(turno);
            }
            
        }

        // POST: TurnosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TurnosDTO collection)
        {
            try
            {
                var response = await client.PostAsJsonAsync("api/Turnos", collection);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                return View();
            }
            catch
            {
                return View();
            }
        }


        //[HttpPost]
        //public async Task<IActionResult> ObtenerPrecios([FromBody] ServiciosDTO serviciosDTO)
        //{
        //    var servicio = await client.GetFromJsonAsync<int>("api/Servicios/" + serviciosDTO.ServicioId);
        //}

        // GET: TurnosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TurnosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TurnosController/Delete/5
        public ActionResult Delete(int id)
        {

            return View();
        }

        // POST: TurnosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Definir()
        {
            var horariosDTOs = await client.GetFromJsonAsync<List<HorariosDTO>>("api/Horarios");
            var medicosDTOs = await client.GetFromJsonAsync<List<MedicosDTO>>("api/Medicos");

            var turnoVM = new TurnoViewModel()
            {
                Horarios = horariosDTOs,
                Medicos = medicosDTOs
            };
            return View(turnoVM);
        }

        [HttpPost]
        public async Task<IActionResult> Definir(TurnoViewModel turnoViewModel)
        {
            var listaTurnos = turnoViewModel.Horarios.Select(h =>
                                    new TurnosCreacionDTO()
                                    {
                                        HorarioId = h.HorarioId,
                                        MedicoId = 1,
                                        Fecha = DateTime.Now,
                                        Asistencia = false,
                                        Estado = "Habilitado"
                                    })
                .Where(h => h.Estado == "Habilitado");

            var response = await client.PostAsJsonAsync("api/Turnos/TurnosMasivos", listaTurnos);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(turnoViewModel);

        }
    }
}
