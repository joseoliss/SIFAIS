using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIFAIS.Datos;
using SIFAIS.Datos.EstadoActivos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Controllers
{
    [Authorize]
    public class EstadoActivosController : Controller
    {
        #region CONSTRUCTOR
        private readonly ApplicationDbContext _context;
        private IEstadoActivosBLL _estadoActivo;
        public EstadoActivosController(ApplicationDbContext context, IEstadoActivosBLL estadoActivo)
        {
            _context = context;
            _estadoActivo = estadoActivo;
        }
        #endregion

        [HttpGet]
        public IActionResult Index(string mensaje)
        {
            if (mensaje != string.Empty)
            {
                ViewBag.exito = mensaje;
            }
            var oRespuesta = _estadoActivo.ListEstadoActivo(_context);
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
        public IActionResult Create(TblEstadoActivo oestadoActivo)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _estadoActivo.AddEstadoActivo(_context, oestadoActivo);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "EstadoActivos", new { mensaje = oestadoActivo.Descripcion + " almacenado con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            return View(oestadoActivo);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (Convert.ToInt32(User.Identity.GetUserRolId()) != 1)
            {
                return RedirectToAction("Index", "Home");
            }
            var oResultado = _estadoActivo.GetyById(_context, id);
            if (oResultado.Estado == 1) return View(oResultado.Datos);
            ViewBag.error = oResultado.Mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(TblEstadoActivo oestadoActivo)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _estadoActivo.EditEstadoActivo(_context, oestadoActivo);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "EstadoActivos", new { mensaje = oestadoActivo.Descripcion + " modificada con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            return View(oestadoActivo);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var oResultado = _estadoActivo.DeleteEstadoActivo(_context, id);
            if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "EstadoActivos", new { mensaje = "Tipo de donación eliminada con éxito!" });
            return RedirectToAction(nameof(Index), "EstadoActivos", new { mensaje = oResultado.Mensaje });
        }
    }
}
