using ClinicaMedica.Model.DTOs.Basic;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaMedica.MVC.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly HttpClient _httpClient;

        public UsuariosController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
        }
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(UsuariosDTO usuariosDTO)
        {
            if(!ModelState.IsValid)
            {
                return View(usuariosDTO);
            }

            var response = await _httpClient.PostAsJsonAsync("api/Usuarios", usuariosDTO);

            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Exito");
            }

            return View(usuariosDTO);
        }

        public IActionResult Exito()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUsuario loginUsuario)
        {
            if(!ModelState.IsValid)
            {
                return View(loginUsuario);
            }

            var response = await _httpClient.PostAsJsonAsync("api/Usuarios/Login", loginUsuario);

            if(response.IsSuccessStatusCode)
            {
                try
                {
                    var tokenResponse = await response.Content.ReadAsStringAsync();
                    
                    // Guardar el token en una cookie
                    HttpContext.Response.Cookies.Append("Token", tokenResponse, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = DateTime.UtcNow.AddMinutes(30) // Tiempo de expiración del token
                    });
                }
                catch (Exception ex)
                {
                    return View();
                }
                
                return RedirectToAction("Exito");
            }

            ModelState.AddModelError(string.Empty, "Credenciales inválidas");

            return View(loginUsuario);
        }
    }
}
