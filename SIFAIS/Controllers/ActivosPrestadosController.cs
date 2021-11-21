using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIFAIS.Datos;
using SIFAIS.Datos.ActivosFisicos;
using SIFAIS.Datos.ActivosPrestados;
using SIFAIS.Datos.EstadoPrestamo;
using SIFAIS.Datos.Responsable;
using SIFAIS.Modelos.Datos;
using SIFAIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Controllers
{
    [Authorize]
    public class ActivosPrestadosController : Controller
    {
        #region CONSTRUCTOR
        private readonly ApplicationDbContext _context;
        private IActivosPrestadosBLL _ActivoPrestado;
        private IResponsableBLL _responsable;
        private IEstadoPrestamoBLL _estadoPrestamo;
        private IActivosFisicosBLL _activosBLL;
        public ActivosPrestadosController(
            ApplicationDbContext context,
            IActivosPrestadosBLL ActivoPrestado,
            IResponsableBLL responsable,
            IEstadoPrestamoBLL estadoPrestamo
            )
        {
            _context = context;
            _ActivoPrestado = ActivoPrestado;
            _responsable = responsable;
            _estadoPrestamo = estadoPrestamo;
        }
        #endregion

        [HttpGet]
        public IActionResult Index(string mensaje)
        {
            if (mensaje != null)
            {
                ViewBag.exito = mensaje;
            }
            var oRespuesta = _ActivoPrestado.ListActivosPrestados(_context);
            if (oRespuesta.Estado == 1) return View(oRespuesta.Datos);
            ViewBag.error = oRespuesta.Mensaje;
            return View();
        }

        [HttpGet]
        public IActionResult Create(int Id)
        {
            ActivoPrestadoVM oActivoPrestadoVM = new ActivoPrestadoVM()
            {
                ActivosPrestados = new TblActivosPrestado(),
                lstResponsable = _responsable.GetListResponsable(_context),
                lstEstadoPrestamo = _estadoPrestamo.GetListEstadoPrestamo(_context),
                IdActivo = Id
            };
            return View(oActivoPrestadoVM);
        }

        [HttpPost]
        public IActionResult Create(ActivoPrestadoVM oActivoPrestadoVM)
        {
            oActivoPrestadoVM.ActivosPrestados.Estado = true;
            oActivoPrestadoVM.ActivosPrestados.IdActivo = oActivoPrestadoVM.IdActivo;
            if (ModelState.IsValid)
            {
                var oResultado = _ActivoPrestado.AddActivosPrestados(_context, oActivoPrestadoVM.ActivosPrestados);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "Activos", new { mensaje = "Prestamo almacenado con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            oActivoPrestadoVM.lstResponsable = _responsable.GetListResponsable(_context);
            oActivoPrestadoVM.lstEstadoPrestamo = _estadoPrestamo.GetListEstadoPrestamo(_context);
            return View(oActivoPrestadoVM);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var oResultado = _ActivoPrestado.GetyById(_context, id);
            ActivoPrestadoVM oActivoPrestadoVM = new ActivoPrestadoVM()
            {
                ActivosPrestados = new TblActivosPrestado(),
                lstResponsable = _responsable.GetListResponsable(_context),
                lstEstadoPrestamo = _estadoPrestamo.GetListEstadoPrestamo(_context)
            };
            oActivoPrestadoVM.ActivosPrestados = (TblActivosPrestado)oResultado.Datos;
            if (oResultado.Estado == 1) return View(oActivoPrestadoVM);
            ViewBag.error = oResultado.Mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(ActivoPrestadoVM oActivoPrestadoVM)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _ActivoPrestado.EditActivosPrestados(_context, oActivoPrestadoVM.ActivosPrestados);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "ActivosPrestados", new { mensaje = "Prestamo modificado con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            oActivoPrestadoVM.lstResponsable= _responsable.GetListResponsable(_context);
            oActivoPrestadoVM.lstEstadoPrestamo = _estadoPrestamo.GetListEstadoPrestamo(_context);

            return View(oActivoPrestadoVM);
        }

        [HttpGet]
        public IActionResult Devolver(string data)
        {
            var oRespuesta = _ActivoPrestado.DevolverActivoPrestado(_context, data);
            if (oRespuesta.Estado == 1) return RedirectToAction(nameof(Index), "ActivosPrestados", new { mensaje = "Devolución realizada con éxito!" });
            ViewBag.error = oRespuesta.Mensaje;
            return View();
        }

    }
}
