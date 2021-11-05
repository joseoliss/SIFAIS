using Microsoft.AspNetCore.Mvc;
using SIFAIS.Datos;
using SIFAIS.Datos.TipoDonante;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Controllers
{
    public class TipoDonanteController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ITipoDonanteBLL _tipoDonante;
        public TipoDonanteController(ApplicationDbContext context, ITipoDonanteBLL tipoDonante)
        {
            _context = context;
            _tipoDonante = tipoDonante;
        }

        [HttpGet]
        public IActionResult Index(string mensaje)
        {
            if (mensaje != string.Empty)
            {
                ViewBag.exito = mensaje;
            }
            var oRespuesta = _tipoDonante.ListTipoDonante(_context);
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
        public IActionResult Create(TblTipoDonante oTipoDonante)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _tipoDonante.AddTipoDonante(_context, oTipoDonante);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "TipoDonante", new { mensaje = oTipoDonante.Descripcion + " almacenado con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            return View(oTipoDonante);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var oResultado = _tipoDonante.GetyById(_context, id);
            if (oResultado.Estado == 1) return View(oResultado.Datos);
            ViewBag.error = oResultado.Mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(TblTipoDonante oTipoDonante)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _tipoDonante.EditTipoDonante(_context, oTipoDonante);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "TipoDonante", new { mensaje = oTipoDonante.Descripcion + " modificada con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            return View(oTipoDonante);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var oResultado = _tipoDonante.DeleteTipoDonante(_context, id);
            if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "TipoDonante", new { mensaje = "Tipo de donante eliminada con éxito!" });
            return RedirectToAction(nameof(Index), "TipoDonante", new { mensaje = oResultado.Mensaje });
        }
    }
}
