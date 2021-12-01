using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIFAIS.Datos;
using SIFAIS.Datos.TipoResponsable;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Controllers
{
    [Authorize]
    public class TipoResponsableController : Controller
    {
        #region CONSTRUCTOR
        private readonly ApplicationDbContext _context;
        private ITipoResponsableBLL _tipoResponsable;
        public TipoResponsableController(ApplicationDbContext context, ITipoResponsableBLL tipoResponsable)
        {
            _context = context;
            _tipoResponsable = tipoResponsable;
        }
        #endregion

        [HttpGet]
        public IActionResult Index(string mensaje)
        {
            if (mensaje != string.Empty)
            {
                ViewBag.exito = mensaje;
            }
            var oRespuesta = _tipoResponsable.ListTipoResponsable(_context);
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
        public IActionResult Create(TblTipoResponsable oTipoResponsable)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _tipoResponsable.AddTipoResponsable(_context, oTipoResponsable);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "TipoResponsable", new { mensaje = oTipoResponsable.Descripcion + " almacenado con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            return View(oTipoResponsable);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (Convert.ToInt32(User.Identity.GetUserRolId()) != 1)
            {
                return RedirectToAction("Index", "Home");
            }
            var oResultado = _tipoResponsable.GetyById(_context, id);
            if (oResultado.Estado == 1) return View(oResultado.Datos);
            ViewBag.error = oResultado.Mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(TblTipoResponsable oTipoResponsable)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _tipoResponsable.EditTipoResponsable(_context, oTipoResponsable);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "TipoResponsable", new { mensaje = oTipoResponsable.Descripcion + " modificada con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            return View(oTipoResponsable);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var oResultado = _tipoResponsable.DeleteTipoResponsable(_context, id);
            if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "TipoResponsable", new { mensaje = "Tipo de donación eliminada con éxito!" });
            return RedirectToAction(nameof(Index), "TipoResponsable", new { mensaje = oResultado.Mensaje });
        }
    }
}
