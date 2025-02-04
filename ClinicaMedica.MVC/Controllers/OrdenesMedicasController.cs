using ClinicaMedica.Model.DTOs.Basic;
using ClinicaMedica.Model.DTOs.Create;
using ClinicaMedica.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClinicaMedica.MVC.Controllers
{
    public class OrdenesMedicasController : Controller
    {
        private readonly HttpClient _httpClient;

        public OrdenesMedicasController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
        }

        // GET: OrdenesMedicasController
        public async Task<ActionResult> Index()
        {
            var response = await _httpClient.GetAsync("api/CitasMedicas");
            if (response.IsSuccessStatusCode)
            {
                var ordenesMedicas = await response.Content.ReadFromJsonAsync<IEnumerable<CitasMedicasDTO>>();
                return View(ordenesMedicas);
            }
            return View();
        }

        // GET: OrdenesMedicasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdenesMedicasController/Create
        public async Task<ActionResult> Create(int id)
        {
            OrdenesVM ordenVM = new OrdenesVM();

            try
            {
                var res = await _httpClient.GetFromJsonAsync<PacientesDTO>($"api/Pacientes/{id}");
                ordenVM.Paciente = res;
                var servicios = await _httpClient.GetFromJsonAsync<List<ServiciosDTO>>("api/Servicios");
                var medicos = await _httpClient.GetFromJsonAsync<List<MedicosDTO>>("api/Medicos");
                ordenVM.Medicos = medicos;

                ViewBag.Servicios = servicios.ConvertAll(s =>
                {
                    return new SelectListItem()
                    {
                        Text = s.Nombre,
                        Value = s.ServicioId.ToString(),
                        Selected = false
                    };
                });

                return View(ordenVM);


            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOM([FromBody]CitasMedicasCreacionDTO citaMedicaCreacionDTO)
        {
            try
            {
                

                var response = await _httpClient.PostAsJsonAsync("api/CitasMedicas", citaMedicaCreacionDTO);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // POST: OrdenesMedicasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: OrdenesMedicasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdenesMedicasController/Edit/5
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

        // GET: OrdenesMedicasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdenesMedicasController/Delete/5
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

        // Metodos complementarios
        [HttpPost]
        public async Task<IActionResult> GetPrice([FromBody] int id)
        {
            var urlService = $"api/Servicios/{id}";

            var servicio = await _httpClient.GetFromJsonAsync<ServiciosDTO>(urlService);

            return Ok(servicio.Precio);
        }
    }
}
