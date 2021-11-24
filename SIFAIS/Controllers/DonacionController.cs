using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIFAIS.Datos;
using SIFAIS.Datos.DocumentacionSIFAIS;
using SIFAIS.Datos.Donaciones;
using SIFAIS.Datos.Donante;
using SIFAIS.Datos.Espacio;
using SIFAIS.Datos.Mensajero;
using SIFAIS.Datos.ResponsableDonacion;
using SIFAIS.Datos.Sede;
using SIFAIS.Datos.TipoDonacion;
using SIFAIS.Modelos.Datos;
using SIFAIS.Modelos.Views;
using SIFAIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Controllers
{
    [Authorize]
    public class DonacionController : Controller
    {
        #region CONSTRUCTOR
        private readonly ApplicationDbContext _context;
        private IDonacionesBLL _donacion;
        private ITipoDonacionBLL _tipoDonacion;
        private IDocumentacionSIFAISBLL _documentacionSIFAIS;
        private IMensajeroBLL _mensajero;
        private IEspacioBLL _espacio;
        private IResponsableDonacionBLL _responsable;
        private IDonanteBLL _donante;
        private ISedeBLL _sede;
        public DonacionController(
            ApplicationDbContext context,
            IDonacionesBLL donacion, 
            ITipoDonacionBLL tipoDonacion,
            IDocumentacionSIFAISBLL documentacionSIFAIS,
            IMensajeroBLL mensajero,
            IEspacioBLL espacio,
            IResponsableDonacionBLL responsable,
            IDonanteBLL donante,
            ISedeBLL sede)
        {
            _context = context;
            _donacion = donacion;
            _tipoDonacion = tipoDonacion;
            _documentacionSIFAIS = documentacionSIFAIS;
            _mensajero = mensajero;
            _espacio = espacio;
            _responsable = responsable;
            _donante = donante;
            _sede = sede;
        }
        #endregion

        [HttpGet]
        public IActionResult Index(string mensaje)
        {
            if (mensaje != null)
            {
                ViewBag.exito = mensaje;
            }
            var oRespuesta = _donacion.ListDonaciones(_context);
            if (oRespuesta.Estado == 1) return View(oRespuesta.Datos);
            ViewBag.error = oRespuesta.Mensaje;
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var oResultado = _donacion.GetById(_context, id);
            DonacionVM oDoncionVM = new DonacionVM()
            {
                Donacion = new TblDonacione(),
                lstTipoDonacion = _tipoDonacion.GetListTipoDonaciones(_context),
                lstDocumentacionSifais = _documentacionSIFAIS.GetListDocumentacionSIFAIS(_context),
                lstMensajero = _mensajero.GetListMensajero(_context),
                lstEspacio = _espacio.GetListEspacio(_context),
                lstResponsable = _responsable.GetListResponsableDonacion(_context),
                lstDonante = _donante.GetListDonante(_context),
                lstSede = _sede.GetListSede(_context)
            };
            oDoncionVM.Donacion = (TblDonacione)oResultado.Datos;
            if (oResultado.Estado == 1) return View(oDoncionVM);
            ViewBag.error = oResultado.Mensaje;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            DonacionVM oDoncionVM = new DonacionVM()
            {
                Donacion = new TblDonacione(),
                lstTipoDonacion = _tipoDonacion.GetListTipoDonaciones(_context),
                lstDocumentacionSifais = _documentacionSIFAIS.GetListDocumentacionSIFAIS(_context),
                lstMensajero = _mensajero.GetListMensajero(_context),
                lstEspacio = _espacio.GetListEspacio(_context),
                lstResponsable = _responsable.GetListResponsableDonacion(_context),
                lstDonante = _donante.GetListDonante(_context),
                lstSede = _sede.GetListSede(_context)
            };
            oDoncionVM.Donacion.FechaDonacion = DateTime.Now;
            return View(oDoncionVM);
        }

        [HttpPost]
        public IActionResult Create(DonacionVM oDonacionVM)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _donacion.AddDonacion(_context, oDonacionVM.Donacion);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "Donacion", new { mensaje = oDonacionVM.Donacion.Descripcion + " almacenado con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            oDonacionVM.lstTipoDonacion = _tipoDonacion.GetListTipoDonaciones(_context);
            oDonacionVM.lstDocumentacionSifais = _documentacionSIFAIS.GetListDocumentacionSIFAIS(_context);
            oDonacionVM.lstMensajero = _mensajero.GetListMensajero(_context);
            oDonacionVM.lstEspacio = _espacio.GetListEspacio(_context);
            oDonacionVM.lstResponsable = _responsable.GetListResponsableDonacion(_context);
            oDonacionVM.lstDonante = _donante.GetListDonante(_context);
            oDonacionVM.lstSede = _sede.GetListSede(_context);
            return View(oDonacionVM);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var oResultado = _donacion.GetById(_context, id);
            DonacionVM oDoncionVM = new DonacionVM()
            {
                Donacion = new TblDonacione(),
                lstTipoDonacion = _tipoDonacion.GetListTipoDonaciones(_context),
                lstDocumentacionSifais = _documentacionSIFAIS.GetListDocumentacionSIFAIS(_context),
                lstMensajero = _mensajero.GetListMensajero(_context),
                lstEspacio = _espacio.GetListEspacio(_context),
                lstResponsable = _responsable.GetListResponsableDonacion(_context),
                lstDonante = _donante.GetListDonante(_context),
                lstSede = _sede.GetListSede(_context)
            };
            oDoncionVM.Donacion = (TblDonacione)oResultado.Datos;
            if (oResultado.Estado == 1) return View(oDoncionVM);
            ViewBag.error = oResultado.Mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(DonacionVM oDonacionVM)
        {

            if (ModelState.IsValid)
            {
                var oResultado = _donacion.EditDonacion(_context, oDonacionVM.Donacion);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "Donacion", new { mensaje = oDonacionVM.Donacion.Descripcion + " modificado con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            oDonacionVM.lstTipoDonacion = _tipoDonacion.GetListTipoDonaciones(_context);
            oDonacionVM.lstDocumentacionSifais = _documentacionSIFAIS.GetListDocumentacionSIFAIS(_context);
            oDonacionVM.lstMensajero = _mensajero.GetListMensajero(_context);
            oDonacionVM.lstEspacio = _espacio.GetListEspacio(_context);
            oDonacionVM.lstResponsable = _responsable.GetListResponsableDonacion(_context);
            oDonacionVM.lstDonante = _donante.GetListDonante(_context);
            oDonacionVM.lstSede = _sede.GetListSede(_context);
            return View(oDonacionVM);
        }

    }
}
