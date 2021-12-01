using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIFAIS.Datos;
using SIFAIS.Datos.TipoDonacion;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Controllers
{
    [Authorize]
    public class TipoDonacionController : Controller
    {
        #region CONSTRUCTOR
        private readonly ApplicationDbContext _context;
        private ITipoDonacionBLL _tipoDonacion;
        public TipoDonacionController(ApplicationDbContext context, ITipoDonacionBLL tipoDonacion)
        {
            _context = context;
            _tipoDonacion = tipoDonacion;
        }
        #endregion

        [HttpGet]
        public IActionResult Index(string mensaje)
        {
            if (mensaje != string.Empty)
            {
                ViewBag.exito = mensaje;
            }
            var oRespuesta = _tipoDonacion.ListTipoDonaciones(_context);
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
        public IActionResult Create(TblTipoDonacion oTipoDonacion)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _tipoDonacion.AddTipoDonacion(_context, oTipoDonacion);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "TipoDonacion", new { mensaje = oTipoDonacion.Descripcion + " almacenado con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            return View(oTipoDonacion);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (Convert.ToInt32(User.Identity.GetUserRolId()) != 1)
            {
                return RedirectToAction("Index", "Home");
            }
            var oResultado = _tipoDonacion.GetyById(_context, id);
            if (oResultado.Estado == 1) return View(oResultado.Datos);
            ViewBag.error = oResultado.Mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(TblTipoDonacion oTipoDonacion)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _tipoDonacion.EditTipoDonacion(_context, oTipoDonacion);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "TipoDonacion", new { mensaje = oTipoDonacion.Descripcion + " modificada con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            return View(oTipoDonacion);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var oResultado = _tipoDonacion.DeleteTipoDonacion(_context, id);
            if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "TipoDonacion", new { mensaje = "Tipo de donación eliminada con éxito!" });
            return RedirectToAction(nameof(Index), "TipoDonacion", new { mensaje = oResultado.Mensaje });
        }
    }
}
