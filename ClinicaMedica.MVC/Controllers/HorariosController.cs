using ClinicaMedica.Model.DTOs.Basic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CookieManager;
using ClinicaMedica.Model.DTOs.Create;

namespace ClinicaMedica.MVC.Controllers
{
    public class HorariosController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ICookieManager _cookieManager;

        public HorariosController(IHttpClientFactory httpClientFactory, ICookieManager cookieManager)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
            _cookieManager = cookieManager;
        }
        // GET: HorariosController
        public async Task<ActionResult> Index()
        {
            // Obtener el token de la cookie
            var token = _cookieManager.Get<string>("Token");
            //if (string.IsNullOrEmpty(token))
            //{
            //    // Manejar el caso en que el token no se encuentre
            //    return RedirectToAction("Login", "Usuarios");
            //}

            //// Agregar el token al encabezado de autorización
            //_httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            // Hacer la Peticion al API Protegida
            var response = await _httpClient.GetAsync("api/Horarios");
            if (!response.IsSuccessStatusCode)
            {
                // Manejar el caso en que la autenticación falla
                return Unauthorized();
            }

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
        public async Task< ActionResult> Create(HorariosCreacionDTO collection)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Horarios", collection);


                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: HorariosController/Edit/5
        public ActionResult Edit(int id)
        {
            var response = _httpClient.GetAsync($"api/Horarios/{id}").Result;
            var horarioDTO = response.Content.ReadFromJsonAsync<HorariosDTO>().Result;
            return View(horarioDTO);
        }

        // POST: HorariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HorariosDTO collection)
        {
            try
            {
                var response = _httpClient.PutAsJsonAsync($"api/Horarios/{id}", collection).Result;
                if(response.IsSuccessStatusCode)
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

        // GET: HorariosController/Delete/5
        public ActionResult Delete(int id)
        {
            var response = _httpClient.GetAsync($"api/Horarios/{id}").Result;
            var HorariosDTO = response.Content.ReadFromJsonAsync<HorariosDTO>().Result;
            return View(HorariosDTO);
        }

        // POST: HorariosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, HorariosDTO collection)
        {
            try
            {
                var response = _httpClient.DeleteAsync($"api/Horarios/{id}").Result;
                if(response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(collection);
                }
                
            }
            catch
            {
                return View();
            }
        }
    }
}
