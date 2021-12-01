using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIFAIS.Datos;
using SIFAIS.Datos.TipoActivo;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Controllers
{
    [Authorize]
    public class TipoActivoController : Controller
    {
        #region CONSTRUCTOR
        private readonly ApplicationDbContext _context;
        private ITipoActivoBLL _TipoActivo;
        public TipoActivoController(ApplicationDbContext context, ITipoActivoBLL TipoActivo)
        {
            _context = context;
            _TipoActivo = TipoActivo;
        }
        #endregion

        [HttpGet]
        public IActionResult Index(string mensaje)
        {
            if (mensaje != string.Empty)
            {
                ViewBag.exito = mensaje;
            }
            var oRespuesta = _TipoActivo.ListTipoActivo(_context);
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
        public IActionResult Create(TblTipoActivo oTipoActivo)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _TipoActivo.AddTipoActivo(_context, oTipoActivo);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "TipoActivo", new { mensaje = oTipoActivo.Descripcion + " almacenado con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            return View(oTipoActivo);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (Convert.ToInt32(User.Identity.GetUserRolId()) != 1)
            {
                return RedirectToAction("Index", "Home");
            }
            var oResultado = _TipoActivo.GetyById(_context, id);
            if (oResultado.Estado == 1) return View(oResultado.Datos);
            ViewBag.error = oResultado.Mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(TblTipoActivo oTipoActivo)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _TipoActivo.EditTipoActivo(_context, oTipoActivo);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "TipoActivo", new { mensaje = oTipoActivo.Descripcion + " modificada con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            return View(oTipoActivo);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var oResultado = _TipoActivo.DeleteTipoActivo(_context, id);
            if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "TipoActivo", new { mensaje = "Tipo de donación eliminada con éxito!" });
            return RedirectToAction(nameof(Index), "TipoActivo", new { mensaje = oResultado.Mensaje });
        }
    }
}
