using Microsoft.AspNetCore.Mvc;
using SIFAIS.Datos;
using SIFAIS.Datos.Sede;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Controllers
{
    public class SedeController : Controller
    {
        #region CONSTRUCTOR
        private readonly ApplicationDbContext _context;
        private ISedeBLL _sedeBLL;
        public SedeController(ApplicationDbContext context, ISedeBLL sedeBLL)
        {
            _context = context;
            _sedeBLL = sedeBLL;
        }
        #endregion

        [HttpGet]
        public IActionResult Index(string mensaje)
        {
            if (mensaje != string.Empty)
            {
                ViewBag.exito = mensaje;
            }
            var oRespuesta = _sedeBLL.ListSede(_context);
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
        public IActionResult Create(TblSede oSede)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _sedeBLL.AddSede(_context, oSede);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "Sede", new { mensaje = oSede.Nombre + " almacenado con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            return View(oSede);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var oResultado = _sedeBLL.GetyById(_context, id);
            if (oResultado.Estado == 1) return View(oResultado.Datos);
            ViewBag.error = oResultado.Mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(TblSede oSede)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _sedeBLL.EditSede(_context, oSede);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "Sede", new { mensaje = oSede.Nombre + " modificada con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            return View(oSede);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var oResultado = _sedeBLL.DeleteSede(_context, id);
            if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "Sede", new { mensaje = "Sede de la donación eliminado con éxito!" });
            return RedirectToAction(nameof(Index), "Sede", new { mensaje = oResultado.Mensaje });
        }
    }
}
