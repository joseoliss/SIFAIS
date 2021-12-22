using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using SIFAIS.Datos;
using SIFAIS.Datos.Donaciones;
using SIFAIS.Datos.Donante;
using SIFAIS.Datos.RepDonaciones;
using SIFAIS.Datos.TipoDonacion;
using SIFAIS.Modelos.Views;
using SIFAIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Controllers
{
    [Authorize]
    public class RepDonacionesController : Controller
    {
        #region CONSTRUCTOR
        private readonly ApplicationDbContext _context;
        private IDonacionesBLL _donacionBLL;
        private IDonanteBLL _donanteBLL;
        private IRepDonacionesBLL _repDonacionBLL;
        private IDonanteBLL _Donante;
        private ITipoDonacionBLL _tipDonacion;
        public RepDonacionesController(
            ApplicationDbContext context,
            IDonacionesBLL donacionBLL,
            IDonanteBLL donanteBLL,
            IRepDonacionesBLL repDonacionBLL,
            IDonanteBLL Donante,
            ITipoDonacionBLL tipDonacion
        )
        {
            _context = context;
            _donacionBLL = donacionBLL;
            _donanteBLL = donanteBLL;
            _repDonacionBLL = repDonacionBLL;
            _Donante = Donante;
            _tipDonacion = tipDonacion;
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexDonaciones()
        {
            RepPreviewDonacionesVM repPreviewDonacionesVM = new RepPreviewDonacionesVM();
            repPreviewDonacionesVM.Donacion = new Modelos.Datos.TblDonacione();
            repPreviewDonacionesVM.Donante = new Modelos.Datos.TblDonante();
            repPreviewDonacionesVM.Desde = DateTime.Now.AddMonths(-1);
            repPreviewDonacionesVM.Hasta = DateTime.Now;
            repPreviewDonacionesVM.lstTipoDonacion = _tipDonacion.GetListTipoDonacionesRep(_context);     
            repPreviewDonacionesVM.lstDonante = _donanteBLL.GetListDonanteRep(_context);     

            return View(repPreviewDonacionesVM);
        }


        #region VISTAS QUE GENERAN REPORTES
        [HttpGet]
        public IActionResult IndexRepGeneral()
        {
            RepDonacionGenVM RepDonacionVM = new RepDonacionGenVM()
            {
                Creador = User.Identity.GetUserName(),
                FechaCreacion = DateTime.Now,
                lstDonacionesXTipo = (IEnumerable<Modelos.Views.DonacionesXTipoView>)_repDonacionBLL.ListDonacionesXTipo(_context).Datos,
                lstDonantesXTipo = (IEnumerable<Modelos.Views.DonantesXTipoView>)_repDonacionBLL.ListDonantesXTipo(_context).Datos
            };

            return new ViewAsPdf("IndexRepGeneral", RepDonacionVM)
            {

            };
        }

        [HttpGet]
        public IActionResult IndexRepDonaciones()
        {
            RepDonantesVM repDonantesVM = new RepDonantesVM()
            {
                Creador = User.Identity.GetUserName(),
                FechaCreacion = DateTime.Now,
                lstDonantes = (IEnumerable<Modelos.Views.DonanteView>)_Donante.ListDonante(_context).Datos
            };

            return new ViewAsPdf("IndexRepDonaciones", repDonantesVM)
            {

            };
        }

        [HttpPost]
        public IActionResult ReporteDonaciones(RepPreviewDonacionesVM repDonaciones)
        {
            repDonaciones.lstDonaciones = (IEnumerable<ReporteDonacionesView>)_donacionBLL.ListRepDonaciones(_context, repDonaciones.Donante.Nombre, repDonaciones.Donacion.Descripcion, repDonaciones.Desde, repDonaciones.Hasta).Datos;

            return new ViewAsPdf("ReporteDonaciones", repDonaciones)
            {

            };
        }

        #endregion

    }
}
