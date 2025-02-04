using ClinicaMedica.Model.DTOs.Basic;
using ClinicaMedica.Model.DTOs.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaMedica.MVC.Controllers
{
    public class ServiciosController : Controller
    {
        private readonly HttpClient _httpClient;
        public ServiciosController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
        }

        // GET: ServiciosController
        public async Task<ActionResult> Index()
        {
            var response = await _httpClient.GetAsync("api/Servicios");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsAsync<List<ServiciosDTO>>();
                return View(content);
            }
            return View(null);
        }

        // GET: ServiciosController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"api/Servicios/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsAsync<ServiciosDTO>();
                return View(content);
            }
            return View();
        }

        // GET: ServiciosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiciosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiciosCreacionDTO serviciosCreacionDTO)
        {
            try
            {
                var response = _httpClient.PostAsJsonAsync("api/Servicios", serviciosCreacionDTO);
                if (response.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(serviciosCreacionDTO);
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiciosController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var response =await  _httpClient.GetAsync($"api/Servicios/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsAsync<ServiciosDTO>();
                    return View(content);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        // POST: ServiciosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Edit(int id, ServiciosDTO serviciosDTO)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/Servicios/{id}", serviciosDTO);

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

        // GET: ServiciosController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _httpClient.GetAsync($"api/Servicios/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsAsync<ServiciosDTO>();
                return View(content);
            }
            return View();
        }

        // POST: ServiciosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ServiciosDTO collection)
        {
            try
            {
                var response = _httpClient.DeleteAsync($"api/Servicios/{id}");
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
