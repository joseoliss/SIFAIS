using Microsoft.AspNetCore.Mvc;
using SIFAIS.Datos;
using SIFAIS.Datos.ActivosFisicos;
using SIFAIS.Datos.Departamentos;
using SIFAIS.Datos.EstadoActivos;
using SIFAIS.Datos.Sede;
using SIFAIS.Datos.TipoActivo;
using SIFAIS.Modelos.Datos;
using SIFAIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Controllers
{
    public class ActivosController : Controller
    {
        #region CONSTRUCTOR
        private readonly ApplicationDbContext _context;
        private IActivosFisicosBLL _Activo;
        private IEstadoActivosBLL _estadoActivo;
        private IDepartamentosBLL _departamento;
        private ISedeBLL _sede;
        private ITipoActivoBLL _tipoActivo;

        public ActivosController(
            ApplicationDbContext context,
            IActivosFisicosBLL activo,
            IEstadoActivosBLL estadoActivos,
            IDepartamentosBLL departamento,
            ISedeBLL sede,
            ITipoActivoBLL tipoActivo
            )
        {
            _context = context;
            _Activo = activo;
            _estadoActivo = estadoActivos;
            _departamento = departamento;
            _sede = sede;
            _tipoActivo = tipoActivo;
        }
        #endregion

        [HttpGet]
        public IActionResult Index(string mensaje)
        {
            if (mensaje != null)
            {
                ViewBag.exito = mensaje;
            }
            var oRespuesta = _Activo.ListActivosFisicos(_context);
            if (oRespuesta.Estado == 1) return View(oRespuesta.Datos);
            ViewBag.error = oRespuesta.Mensaje;
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var oResultado = _Activo.GetyById(_context, id);
            ActivoVM oActivoVM = new ActivoVM()
            {
                Activos = new TblActivosFisico(),
                lstDepartamento = _departamento.GetListDepartamento(_context),
                lstEstadoActivo = _estadoActivo.GetListEstadoActivo(_context),
                lstTipoActivo = _tipoActivo.GetListTipoActivo(_context),
                lstSede = _sede.GetListSede(_context)
            };
            oActivoVM.Activos = (TblActivosFisico)oResultado.Datos;
            if (oResultado.Estado == 1) return View(oActivoVM);
            ViewBag.error = oResultado.Mensaje;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (Convert.ToInt32(User.Identity.GetUserRolId()) != 1)
            {
                return RedirectToAction("Index", "Home");
            }
            ActivoVM oActivoVM = new ActivoVM()
            {
                Activos = new TblActivosFisico(),
                lstDepartamento = _departamento.GetListDepartamento(_context),
                lstEstadoActivo = _estadoActivo.GetListEstadoActivo(_context),
                lstTipoActivo = _tipoActivo.GetListTipoActivo(_context),
                lstSede = _sede.GetListSede(_context)
            };
            oActivoVM.Activos.FechaDeIngreso = DateTime.Now;
            return View(oActivoVM);
        }

        [HttpPost]
        public IActionResult Create(ActivoVM oActivoVM)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _Activo.AddActivosFisicos(_context, oActivoVM.Activos);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "Activos", new { mensaje = oActivoVM.Activos.Nombre + " almacenado con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            oActivoVM.lstDepartamento = _departamento.GetListDepartamento(_context);
            oActivoVM.lstEstadoActivo = _estadoActivo.GetListEstadoActivo(_context);
            oActivoVM.lstTipoActivo = _tipoActivo.GetListTipoActivo(_context);
            oActivoVM.lstSede = _sede.GetListSede(_context);
            return View(oActivoVM);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (Convert.ToInt32(User.Identity.GetUserRolId()) != 1)
            {
                return RedirectToAction("Index", "Home");
            }
            var oResultado = _Activo.GetyById(_context, id);
            ActivoVM oActivoVM = new ActivoVM()
            {
                Activos = new TblActivosFisico(),
                lstDepartamento = _departamento.GetListDepartamento(_context),
                lstEstadoActivo = _estadoActivo.GetListEstadoActivo(_context),
                lstTipoActivo = _tipoActivo.GetListTipoActivo(_context),
                lstSede = _sede.GetListSede(_context)
            };
            oActivoVM.Activos = (TblActivosFisico)oResultado.Datos;
            if (oResultado.Estado == 1) return View(oActivoVM);
            ViewBag.error = oResultado.Mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(ActivoVM oActivoVM)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _Activo.EditActivosFisicos(_context, oActivoVM.Activos);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "Activos", new { mensaje = oActivoVM.Activos.Nombre + " modificado con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            oActivoVM.lstDepartamento = _departamento.GetListDepartamento(_context);
            oActivoVM.lstEstadoActivo = _estadoActivo.GetListEstadoActivo(_context);
            oActivoVM.lstTipoActivo = _tipoActivo.GetListTipoActivo(_context);
            oActivoVM.lstSede = _sede.GetListSede(_context);
            return View(oActivoVM);
        }

    }
}
