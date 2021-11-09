using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIFAIS.Datos;
using SIFAIS.Datos.Espacio;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Controllers
{
    [Authorize]
    public class EspacioController : Controller
    {
        #region CONSTRUCTOR
        private readonly ApplicationDbContext _context;
        private IEspacioBLL _espacioBLL;
        public EspacioController(ApplicationDbContext context, IEspacioBLL espacioBLL)
        {
            _context = context;
            _espacioBLL = espacioBLL;
        }
        #endregion

        [HttpGet]
        public IActionResult Index(string mensaje)
        {
            if (mensaje != string.Empty)
            {
                ViewBag.exito = mensaje;
            }
            var oRespuesta = _espacioBLL.ListEspacio(_context);
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
        public IActionResult Create(TblEspacio oEspacio)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _espacioBLL.AddEspacio(_context, oEspacio);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "Espacio", new { mensaje = oEspacio.Descripcion + " almacenado con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            return View(oEspacio);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var oResultado = _espacioBLL.GetyById(_context, id);
            if (oResultado.Estado == 1) return View(oResultado.Datos);
            ViewBag.error = oResultado.Mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(TblEspacio oEspacio)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _espacioBLL.EditEspacio(_context, oEspacio);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "Espacio", new { mensaje = oEspacio.Descripcion + " modificada con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            return View(oEspacio);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var oResultado = _espacioBLL.DeleteEspacio(_context, id);
            if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "Espacio", new { mensaje = "Espacio eliminado con éxito!" });
            return RedirectToAction(nameof(Index), "Espacio", new { mensaje = oResultado.Mensaje });
        }
    }
}
