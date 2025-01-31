using ClinicaMedica.Model.DTOs.Basic;
using ClinicaMedica.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaMedica.MVC.Controllers
{
    public class TurnosController : Controller
    {
        HttpClient client;

        public TurnosController(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient("MyApiClient");
        }
)
        {
            
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
        public async Task<ActionResult> Create()
        {
            TurnosDTO turnosDTO = new TurnosDTO();
            TurnosVM turno = new TurnosVM();
            
            return View(turno);
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
    }
}
