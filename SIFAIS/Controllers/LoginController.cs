using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SIFAIS.Datos;
using SIFAIS.Datos.Login;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SIFAIS.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILoginBLL _login;
        public LoginController(
            ApplicationDbContext context,
            ILoginBLL login
        )
        {
            _context = context;
            _login = login;
        }


        public async Task<IActionResult> Index(string mensaje)
        {
            await HttpContext.SignOutAsync();
            if (mensaje != string.Empty)
            {
                ViewBag.error = mensaje;
            }
            return View();
        }

        public async Task<IActionResult> LogOut(string mensaje)
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Login(TblUsuario oUsuario)
        {
            var oRespuesta = _login.Login(_context, oUsuario);
            if (oRespuesta.Estado == 1)
            {
                oUsuario = (TblUsuario)oRespuesta.Datos;
                if (oUsuario != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim("UserId", oUsuario.Id.ToString()),
                        new Claim("UserName", oUsuario.Nombre + " " + oUsuario.Apellido),
                        new Claim("UserRole", oUsuario.IdRolUsuario.ToString())
                    };

                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);

                    return RedirectToAction("Index", "Donacion");
                }
                else
                {
                    return RedirectToAction(nameof(Index), "Login", new { mensaje = "Correo electrónico o contraseña incorrectos" });
                }
            }
            
            return RedirectToAction(nameof(Index), "Login", new { mensaje = oRespuesta.Mensaje });
        }
    }
}
