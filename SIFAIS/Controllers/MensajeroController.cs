using Microsoft.AspNetCore.Mvc;
using SIFAIS.Datos;
using SIFAIS.Datos.Mensajero;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Controllers
{
    public class MensajeroController : Controller
    {
        #region CONSTRUCTOR
        private readonly ApplicationDbContext _context;
        private IMensajeroBLL _mensajeroBLL;
        public MensajeroController(ApplicationDbContext context, IMensajeroBLL mensajeroBLL)
        {
            _context = context;
            _mensajeroBLL = mensajeroBLL;
        }
        #endregion

        [HttpGet]
        public IActionResult Index(string mensaje)
        {
            if (mensaje != string.Empty)
            {
                ViewBag.exito = mensaje;
            }
            var oRespuesta = _mensajeroBLL.ListMensajero(_context);
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
        public IActionResult Create(TblMensajero oMensajero)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _mensajeroBLL.AddMensajero(_context, oMensajero);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "Mensajero", new { mensaje = oMensajero.Nombre + " " + oMensajero.Apellido + " almacenado con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            return View(oMensajero);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var oResultado = _mensajeroBLL.GetyById(_context, id);
            if (oResultado.Estado == 1) return View(oResultado.Datos);
            ViewBag.error = oResultado.Mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(TblMensajero oMensajero)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _mensajeroBLL.EditMensajero(_context, oMensajero);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "Mensajero", new { mensaje = oMensajero.Nombre + " " + oMensajero.Apellido + " modificada con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            return View(oMensajero);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var oResultado = _mensajeroBLL.DeleteMensajero(_context, id);
            if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "Mensajero", new { mensaje = "Mensajero eliminado con éxito!" });
            return RedirectToAction(nameof(Index), "Mensajero", new { mensaje = oResultado.Mensaje });
        }
    }
}
