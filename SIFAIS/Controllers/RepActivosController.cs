using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using SIFAIS.Datos;
using SIFAIS.Datos.ActivosFisicos;
using SIFAIS.Datos.ActivosPrestados;
using SIFAIS.Datos.EstadoActivos;
using SIFAIS.Datos.RepActivos;
using SIFAIS.Datos.TipoActivo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Controllers
{
    public class RepActivosController : Controller
    {
        #region CONSTRUCTOR
        private readonly ApplicationDbContext _context;
        private IRepActivosBLL _repActivosBLL;
        private IEstadoActivosBLL _EstadoActivo;
        private ITipoActivoBLL _tipoActivo;
        private IActivosFisicosBLL _activosFisicosBLL; 
        private IActivosPrestadosBLL _ActivosPrestadosBLL; 
        public RepActivosController(
            ApplicationDbContext context,
            IRepActivosBLL repActivosBLL,
            IEstadoActivosBLL estadoActivo,
            ITipoActivoBLL tipoActivo,
            IActivosFisicosBLL activosFisicosBLL,
            IActivosPrestadosBLL ActivosPrestadosBLL
        )
        {
            _context = context;
            _repActivosBLL = repActivosBLL;
            _EstadoActivo = estadoActivo;
            _tipoActivo = tipoActivo;
            _activosFisicosBLL = activosFisicosBLL;
            _ActivosPrestadosBLL = ActivosPrestadosBLL;
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult IndexListadoActivos()
        {
            SIFAIS.Models.RepPreviewListadoActivosVM RepPreviewListadoActivosVM = new Models.RepPreviewListadoActivosVM()
            {
                Activos = new Modelos.Datos.TblActivosFisico(),
                TipoActivo = new Modelos.Datos.TblTipoActivo(),
                EstadoActivo = new Modelos.Datos.TblEstadoActivo(),
                Desde = DateTime.Now.AddMonths(-1),
                Hasta = DateTime.Now,
                lstEstadoActivo = _EstadoActivo.GetListEstadoActivoRep(_context),
                lstTipoActivo = _tipoActivo.GetListTipoActivoRep(_context)
            };

            return View(RepPreviewListadoActivosVM);
        }

        [HttpGet]
        public IActionResult IndexListadoPrestamos()
        {
            SIFAIS.Models.RepPreviewListadoActivosVM RepPreviewListadoActivosVM = new Models.RepPreviewListadoActivosVM()
            {
                Activos = new Modelos.Datos.TblActivosFisico(),
                TipoActivo = new Modelos.Datos.TblTipoActivo(),
                EstadoActivo = new Modelos.Datos.TblEstadoActivo(),
                Desde = DateTime.Now.AddMonths(-1),
                Hasta = DateTime.Now,
                lstEstadoActivo = _EstadoActivo.GetListEstadoActivoRep(_context),
                lstTipoActivo = _tipoActivo.GetListTipoActivoRep(_context)
            };

            return View(RepPreviewListadoActivosVM);
        }

        [HttpGet]
        public IActionResult IndexHistorialPrestamos()
        {
            SIFAIS.Models.RepPreviewListadoActivosVM RepPreviewListadoActivosVM = new Models.RepPreviewListadoActivosVM()
            {
                Activos = new Modelos.Datos.TblActivosFisico(),
                TipoActivo = new Modelos.Datos.TblTipoActivo(),
                EstadoActivo = new Modelos.Datos.TblEstadoActivo(),
                Desde = DateTime.Now.AddMonths(-1),
                Hasta = DateTime.Now,
                lstEstadoActivo = _EstadoActivo.GetListEstadoActivoRep(_context),
                lstTipoActivo = _tipoActivo.GetListTipoActivoRep(_context)
            };

            return View(RepPreviewListadoActivosVM);
        }

        #region VISTAS QUE GENERAN REPORTES
        [HttpGet]
        public IActionResult IndexRepTotales()
        {
            var resultado = _repActivosBLL.ListRepTotalesActivo(_context);
            return new ViewAsPdf("IndexRepTotales", resultado.Datos)
            {

            };
        }

        [HttpPost]
        public IActionResult ListadoActivosRep(SIFAIS.Models.RepPreviewListadoActivosVM RepPreviewListadoActivosVM)
        {
            RepPreviewListadoActivosVM.lstActivos = (IEnumerable<Modelos.Views.ActivosFisicosView>)_activosFisicosBLL.ListActivosFisicosRep(
                                                                                                                                                _context, RepPreviewListadoActivosVM.TipoActivo.Descripcion, 
                                                                                                                                                RepPreviewListadoActivosVM.EstadoActivo.Descripcion, 
                                                                                                                                                RepPreviewListadoActivosVM.Desde, 
                                                                                                                                                RepPreviewListadoActivosVM.Hasta
                                                                                                                                            ).Datos;
            return new ViewAsPdf("ListadoActivosRep", RepPreviewListadoActivosVM)
            {

            };
        }

        [HttpPost]
        public IActionResult ListadoPrestamosRep(SIFAIS.Models.RepPreviewListadoActivosVM RepPreviewListadoActivosVM)
        {
            RepPreviewListadoActivosVM.lstPrestamos = (IEnumerable<Modelos.Views.ActivosPrestadosView>)_ActivosPrestadosBLL.ListActivosPrestadosRep(
                                                                                                                                                _context, RepPreviewListadoActivosVM.TipoActivo.Descripcion,
                                                                                                                                                RepPreviewListadoActivosVM.EstadoActivo.Descripcion,
                                                                                                                                                RepPreviewListadoActivosVM.Desde,
                                                                                                                                                RepPreviewListadoActivosVM.Hasta
                                                                                                                                            ).Datos;
            return new ViewAsPdf("ListadoPrestamosRep", RepPreviewListadoActivosVM)
            {

            };
        }

        [HttpPost]
        public IActionResult HistorialPrestamosRep(SIFAIS.Models.RepPreviewListadoActivosVM RepPreviewListadoActivosVM)
        {
            RepPreviewListadoActivosVM.lstPrestamos = (IEnumerable<Modelos.Views.ActivosPrestadosView>)_ActivosPrestadosBLL.ListActivosPrestadosRep(
                                                                                                                                                _context, RepPreviewListadoActivosVM.TipoActivo.Descripcion,
                                                                                                                                                RepPreviewListadoActivosVM.EstadoActivo.Descripcion,
                                                                                                                                                RepPreviewListadoActivosVM.Desde,
                                                                                                                                                RepPreviewListadoActivosVM.Hasta
                                                                                                                                            ).Datos;
            return new ViewAsPdf("HistorialPrestamosRep", RepPreviewListadoActivosVM)
            {

            };
        }
        #endregion
    }
}
