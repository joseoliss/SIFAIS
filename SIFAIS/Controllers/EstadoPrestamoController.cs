using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIFAIS.Datos;
using SIFAIS.Datos.EstadoPrestamo;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Controllers
{
    [Authorize]
    public class EstadoPrestamoController : Controller
    {
        #region CONSTRUCTOR
        private readonly ApplicationDbContext _context;
        private IEstadoPrestamoBLL _EstadoPrestamoBLL;
        public EstadoPrestamoController(ApplicationDbContext context, IEstadoPrestamoBLL EstadoPrestamoBLL)
        {
            _context = context;
            _EstadoPrestamoBLL = EstadoPrestamoBLL;
        }
        #endregion

        [HttpGet]
        public IActionResult Index(string mensaje)
        {
            if (mensaje != string.Empty)
            {
                ViewBag.exito = mensaje;
            }
            var oRespuesta = _EstadoPrestamoBLL.ListEstadoPrestamo(_context);
            if (oRespuesta.Estado == 1) return View(oRespuesta.Datos);
            ViewBag.error = oRespuesta.Mensaje;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (Convert.ToInt32(User.Identity.GetUserRolId()) != 1)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(TblEstadoPrestamo oEstadoPrestamo)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _EstadoPrestamoBLL.AddEstadoPrestamo(_context, oEstadoPrestamo);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "EstadoPrestamo", new { mensaje = oEstadoPrestamo.Descripcion + " almacenado con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            return View(oEstadoPrestamo);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (Convert.ToInt32(User.Identity.GetUserRolId()) != 1)
            {
                return RedirectToAction("Index", "Home");
            }
            var oResultado = _EstadoPrestamoBLL.GetyById(_context, id);
            if (oResultado.Estado == 1) return View(oResultado.Datos);
            ViewBag.error = oResultado.Mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(TblEstadoPrestamo oEstadoPrestamo)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _EstadoPrestamoBLL.EditEstadoPrestamo(_context, oEstadoPrestamo);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "EstadoPrestamo", new { mensaje = oEstadoPrestamo.Descripcion + " modificada con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            return View(oEstadoPrestamo);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var oResultado = _EstadoPrestamoBLL.DeleteEstadoPrestamo(_context, id);
            if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "EstadoPrestamo", new { mensaje = "Estado Préstamo eliminado con éxito!" });
            return RedirectToAction(nameof(Index), "EstadoPrestamo", new { mensaje = oResultado.Mensaje });
        }
    }
}
