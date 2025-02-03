using ClinicaMedica.Model.DTOs.Basic;
using ClinicaMedica.Model.DTOs.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;

namespace ClinicaMedica.MVC.Controllers
{
    public class EspecialidadesController : Controller
    {
        private readonly HttpClient _httpClient;

        public EspecialidadesController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient("MyApiClient");
        }
        // GET: EspecialidadesController
        public async Task<ActionResult> Index()
        {
            var response = await _httpClient.GetAsync("api/Especialidades");
            if( response.IsSuccessStatusCode)
            {
                var especialidades = await response.Content.ReadFromJsonAsync<List<EspecialidadesDTO>>();
                return View(especialidades);
            }
            return View();
        }

        // GET: EspecialidadesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var especialidad = await _httpClient.GetFromJsonAsync<EspecialidadesDTO>($"api/Especialidades/{id}");

            if(especialidad != null)
            {
                return View(especialidad);
            }
            
            return View();
        }

        // GET: EspecialidadesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EspecialidadesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EspecialidadesCreacionDTO especialidadesCreacionDTO)
        {
            try
            {
                var response = _httpClient.PostAsJsonAsync("api/Especialidades", especialidadesCreacionDTO);
                if(response.Result.IsSuccessStatusCode)
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

        // GET: EspecialidadesController/Edit/5
        public async Task< ActionResult> Edit(int id)
        {
            var especialidad = await _httpClient.GetFromJsonAsync<EspecialidadesDTO>($"api/Especialidades/{id}");

            if(especialidad != null)
            {
                return View(especialidad);
            }
            return View();
        }

        // POST: EspecialidadesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EspecialidadesDTO collection)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/Especialidades/{id}", collection);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: EspecialidadesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var especialidad = await _httpClient.GetFromJsonAsync<EspecialidadesDTO>($"api/Especialidades/{id}");

            if (especialidad != null)
            {
                return View(especialidad);
            }
            return View();
        }

        // POST: EspecialidadesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Especialidades/{id}");
                if (response.IsSuccessStatusCode)
                { 
                    return RedirectToAction(nameof(Index));
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }
    }
}
