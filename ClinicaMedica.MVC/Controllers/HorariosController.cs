using ClinicaMedica.Model.DTOs.Basic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaMedica.MVC.Controllers
{
    public class HorariosController : Controller
    {
        private readonly HttpClient _httpClient;

        public HorariosController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
        }
        // GET: HorariosController
        public async Task<ActionResult> Index()
        {

            var response = await _httpClient.GetAsync("api/Horarios");
            var horariosDTO = await response.Content.ReadFromJsonAsync<List<HorariosDTO>>();
            return View(horariosDTO);
        }

        // GET: HorariosController/Details/5
        public ActionResult Details(int id)
        {
            var response = _httpClient.GetAsync($"api/Horarios/{id}").Result;
            var horarioDTO = response.Content.ReadFromJsonAsync<HorariosDTO>().Result;
            return View(horarioDTO);
        }

        // GET: HorariosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HorariosController/Create
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

        // GET: HorariosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HorariosController/Edit/5
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

        // GET: HorariosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HorariosController/Delete/5
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
