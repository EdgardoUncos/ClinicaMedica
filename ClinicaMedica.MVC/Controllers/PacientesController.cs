﻿using ClinicaMedica.Model.DTOs.Basic;
using ClinicaMedica.Model.DTOs.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaMedica.MVC.Controllers
{
    public class PacientesController : Controller
    {
        HttpClient client = new HttpClient();
        // GET: PacientesController
        public async Task<ActionResult> Index()
        {
            var response = await client.GetAsync("https://localhost:7268/api/Pacientes");
            var pacientes = await response.Content.ReadFromJsonAsync<List<PacientesDTO>>();
            return View(pacientes);
        } 

        // GET: PacientesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var response = await client.GetAsync($"https://localhost:7268/api/Pacientes/{id}");
            var paciente = await response.Content.ReadFromJsonAsync<PacientesDTO>();
            return View(paciente);
        }

        // GET: PacientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PacientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PacientesCreacionDTO collection)
        {
            try
            {
                var response = await client.PostAsJsonAsync("https://localhost:7268/api/Pacientes", collection);
                
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

        // GET: PacientesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var response = await client.GetAsync($"https://localhost:7268/api/Pacientes/{id}");
            var paciente = await response.Content.ReadFromJsonAsync<PacientesDTO>();
            return View(paciente);
        }

        // POST: PacientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, PacientesDTO collection)
        {
            try
            {
                collection.PacienteId = id;
                var response = await client.PutAsJsonAsync($"https://localhost:7268/api/Pacientes/{id}", collection);
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

        // GET: PacientesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PacientesController/Delete/5
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
