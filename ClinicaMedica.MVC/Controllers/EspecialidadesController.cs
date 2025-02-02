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
        public ActionResult Details(int id)
        {
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EspecialidadesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EspecialidadesCreacionDTO collection)
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

        // GET: EspecialidadesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EspecialidadesController/Delete/5
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
    }
}
