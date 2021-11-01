using Microsoft.AspNetCore.Mvc;
using SIFAIS.Datos;
using SIFAIS.Datos.Donante;
using SIFAIS.Datos.TipoDonante;
using SIFAIS.Modelos.Datos;
using SIFAIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Views
{
    public class DonanteController : Controller
    {
        #region CONSTRUCTOR
        private readonly ApplicationDbContext _context;
        private IDonanteBLL _Donante;
        private ITipoDonanteBLL _tipoDonante;
        public DonanteController(ApplicationDbContext context, IDonanteBLL Donante, ITipoDonanteBLL tipoDonante)
        {
            _context = context;
            _Donante = Donante;
            _tipoDonante = tipoDonante;
        }
        #endregion

        [HttpGet]
        public IActionResult Index(string mensaje)
        {
            if (mensaje != null)
            {
                ViewBag.exito = mensaje;
            }
            var oRespuesta = _Donante.ListDonante(_context);
            if (oRespuesta.Estado == 1) return View(oRespuesta.Datos);
            ViewBag.error = oRespuesta.Mensaje;
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var oResultado = _Donante.GetyById(_context, id);
            DonanteVM oDonanteVM = new DonanteVM()
            {
                Donante = new TblDonante(),
                LstTipoDonante = _tipoDonante.GetListTipoDonante(_context)
            };
            oDonanteVM.Donante = (TblDonante)oResultado.Datos;
            if (oResultado.Estado == 1) return View(oDonanteVM);
            ViewBag.error = oResultado.Mensaje;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            DonanteVM oDonanteVM = new DonanteVM()
            {
                Donante = new TblDonante(),
                LstTipoDonante = _tipoDonante.GetListTipoDonante(_context)
            };
            return View(oDonanteVM);
        }

        [HttpPost]
        public IActionResult Create(DonanteVM oDonanteVM)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _Donante.AddDonante(_context, oDonanteVM.Donante);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "Donante", new { mensaje = oDonanteVM.Donante.Nombre + " almacenado con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            oDonanteVM.LstTipoDonante = _tipoDonante.GetListTipoDonante(_context);
            return View(oDonanteVM);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var oResultado = _Donante.GetyById(_context, id);
            DonanteVM oDonanteVM = new DonanteVM()
            {
                Donante = new TblDonante(),
                LstTipoDonante = _tipoDonante.GetListTipoDonante(_context)
            };
            oDonanteVM.Donante = (TblDonante)oResultado.Datos;
            if (oResultado.Estado == 1) return View(oDonanteVM);
            ViewBag.error = oResultado.Mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(DonanteVM oDonanteVM)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _Donante.EditDonante(_context, oDonanteVM.Donante);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "Donante", new { mensaje = oDonanteVM.Donante.Nombre + " modificado con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            oDonanteVM.LstTipoDonante = _tipoDonante.GetListTipoDonante(_context);
            return View(oDonanteVM);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var oResultado = _Donante.DeleteDonante(_context, id);
            if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "Donante", new { mensaje = "Donante eliminado con éxito!" });
            ViewBag.error = oResultado.Mensaje;
            return View();
        }
    }
}
