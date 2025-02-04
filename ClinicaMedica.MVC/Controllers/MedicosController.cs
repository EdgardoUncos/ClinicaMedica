using ClinicaMedica.Model.DTOs.Basic;
using ClinicaMedica.Model.DTOs.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaMedica.MVC.Controllers
{
    public class MedicosController : Controller
    {
        private readonly HttpClient _httpClient;

        public MedicosController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
        }

        // GET: MedicosController
        public async Task<ActionResult> Index()
        {
            var response = await _httpClient.GetAsync("api/Medicos");
            if (response.IsSuccessStatusCode)
            {
                var medicos = await response.Content.ReadFromJsonAsync<List<MedicosDTO>>();
                return View(medicos);
            }
            return View();
        }

        // GET: MedicosController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var response = _httpClient.GetAsync($"api/Medicos/{id}");
            if (response.Result.IsSuccessStatusCode)
            {
                var medicos = await response.Result.Content.ReadFromJsonAsync<MedicosDTO>();
                return View(medicos);
            }
            return View();
        }

        // GET: MedicosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MedicosCreacionDTO medicosCreacionDTO)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Medicos", medicosCreacionDTO);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(medicosCreacionDTO);
            }
            catch
            {
                return View();
            }
        }

        // GET: MedicosController/Edit/5
        public ActionResult Edit(int id)
        {
            var response = _httpClient.GetAsync($"api/Medicos/{id}");
            if (response.Result.IsSuccessStatusCode)
            {
                var medicos = response.Result.Content.ReadFromJsonAsync<MedicosDTO>().Result;
                return View(medicos);
            }
            return View();
        }

        // POST: MedicosController/Edit/5
        // Faltaria crea un nuevo Put para que modifique a la persona

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MedicosDTO collection)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/Medicos/{id}", collection);
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

        // GET: MedicosController/Delete/5
        public ActionResult Delete(int id)
        {
            var response = _httpClient.GetAsync($"api/Medicos/{id}");
            if (response.Result.IsSuccessStatusCode)
            {
                var medicos = response.Result.Content.ReadFromJsonAsync<MedicosDTO>().Result;
                return View(medicos);
            }
            return View();
        }

        // POST: MedicosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MedicosDTO collection)
        {
            try
            {
                var response = _httpClient.DeleteAsync($"api/Medicos/{id}");
                if (response.Result.IsSuccessStatusCode)
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
