using Microsoft.AspNetCore.Mvc;
using SIFAIS.Datos;
using SIFAIS.Datos.Responsable;
using SIFAIS.Datos.TipoResponsable;
using SIFAIS.Modelos.Datos;
using SIFAIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Controllers
{
    public class ResponsableActivoController : Controller
    {
        #region CONSTRUCTOR
        private readonly ApplicationDbContext _context;
        private IResponsableBLL _responsableBLL;
        private ITipoResponsableBLL _tipoResponsableBLL;
        public ResponsableActivoController(ApplicationDbContext context, IResponsableBLL responsableBLL, ITipoResponsableBLL tipoResponsableBLL)
        {
            _context = context;
            _responsableBLL = responsableBLL;
            _tipoResponsableBLL = tipoResponsableBLL;
        }
        #endregion

        [HttpGet]
        public IActionResult Index(string mensaje)
        {
            if (mensaje != string.Empty)
            {
                ViewBag.exito = mensaje;
            }
            var oRespuesta = _responsableBLL.ListResponsable(_context);
            if (oRespuesta.Estado == 1) return View(oRespuesta.Datos);
            ViewBag.error = oRespuesta.Mensaje;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ResponsableVM oResponsableVM = new ResponsableVM()
            {
                Responsable = new TblResponsable(),
                lstTipoResponsable = _tipoResponsableBLL.GetListTipoResponsable(_context)
            };
            return View(oResponsableVM);
        }

        [HttpPost]
        public IActionResult Create(ResponsableVM oResponsableVM)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _responsableBLL.AddResponsable(_context, oResponsableVM.Responsable);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "ResponsableActivo", new { mensaje = oResponsableVM.Responsable.Nombre + " " + oResponsableVM.Responsable.Apellido + " almacenado con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            oResponsableVM.lstTipoResponsable = _responsableBLL.GetListResponsable(_context);
            return View(oResponsableVM);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var oResultado = _responsableBLL.GetyById(_context, id);
            ResponsableVM oResponsableVM = new ResponsableVM()
            {
                Responsable = new TblResponsable(),
                lstTipoResponsable = _tipoResponsableBLL.GetListTipoResponsable(_context)
            };
            oResponsableVM.Responsable = (TblResponsable)oResultado.Datos;
            if (oResultado.Estado == 1) return View(oResponsableVM);
            ViewBag.error = oResultado.Mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(ResponsableVM oResponsableVM)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _responsableBLL.EditResponsable(_context, oResponsableVM.Responsable);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "ResponsableActivo", new { mensaje = oResponsableVM.Responsable.Nombre + " " + oResponsableVM.Responsable.Apellido + " modificada con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            oResponsableVM.lstTipoResponsable = _responsableBLL.GetListResponsable(_context);
            return View(oResponsableVM);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var oResultado = _responsableBLL.DeleteResponsable(_context, id);
            if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "ResponsableActivo", new { mensaje = "Responsable de activo eliminado con éxito!" });
            return RedirectToAction(nameof(Index), "ResponsableActivo", new { mensaje = oResultado.Mensaje });
        }
    }
}
