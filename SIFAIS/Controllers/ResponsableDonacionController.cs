using Microsoft.AspNetCore.Mvc;
using SIFAIS.Datos;
using SIFAIS.Datos.ResponsableDonacion;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Controllers
{
    public class ResponsableDonacionController : Controller
    {
        #region CONSTRUCTOR
        private readonly ApplicationDbContext _context;
        private IResponsableDonacionBLL _responsableDonacionBLL;
        public ResponsableDonacionController(ApplicationDbContext context, IResponsableDonacionBLL responsableBLL)
        {
            _context = context;
            _responsableDonacionBLL = responsableBLL;
        }
        #endregion

        [HttpGet]
        public IActionResult Index(string mensaje)
        {
            if (mensaje != string.Empty)
            {
                ViewBag.exito = mensaje;
            }
            var oRespuesta = _responsableDonacionBLL.ListResponsableDonacion(_context);
            if (oRespuesta.Estado == 1) return View(oRespuesta.Datos);
            ViewBag.error = oRespuesta.Mensaje;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TblResponsableDonacion oResponsable)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _responsableDonacionBLL.AddResponsableDonacion(_context, oResponsable);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "ResponsableDonacion", new { mensaje = oResponsable.Nombre + " " + oResponsable.Apellido + " almacenado con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            return View(oResponsable);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var oResultado = _responsableDonacionBLL.GetyById(_context, id);
            if (oResultado.Estado == 1) return View(oResultado.Datos);
            ViewBag.error = oResultado.Mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(TblResponsableDonacion oResponsable)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _responsableDonacionBLL.EditResponsableDonacion(_context, oResponsable);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "ResponsableDonacion", new { mensaje = oResponsable.Nombre + " " + oResponsable.Apellido + " modificada con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            return View(oResponsable);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var oResultado = _responsableDonacionBLL.DeleteResponsableDonacion(_context, id);
            if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "ResponsableDonacion", new { mensaje = "Responsable de la donación eliminado con éxito!" });
            return RedirectToAction(nameof(Index), "ResponsableDonacion", new { mensaje = oResultado.Mensaje });
        }
    }
}
