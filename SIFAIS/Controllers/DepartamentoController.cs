using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIFAIS.Datos;
using SIFAIS.Datos.Departamentos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Controllers
{
    [Authorize]
    public class DepartamentoController : Controller
    {
        #region CONSTRUCTOR
        private readonly ApplicationDbContext _context;
        private IDepartamentosBLL _DepartamentoBLL;
        public DepartamentoController(ApplicationDbContext context, IDepartamentosBLL DepartamentoBLL)
        {
            _context = context;
            _DepartamentoBLL = DepartamentoBLL;
        }
        #endregion

        [HttpGet]
        public IActionResult Index(string mensaje)
        {
            if (mensaje != string.Empty)
            {
                ViewBag.exito = mensaje;
            }
            var oRespuesta = _DepartamentoBLL.ListDepartamento(_context);
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
        public IActionResult Create(TblDepartamento oDepartamento)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _DepartamentoBLL.AddDepartamento(_context, oDepartamento);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "Departamento", new { mensaje = oDepartamento.Descripcion + " almacenado con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            return View(oDepartamento);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (Convert.ToInt32(User.Identity.GetUserRolId()) != 1)
            {
                return RedirectToAction("Index", "Home");
            }
            var oResultado = _DepartamentoBLL.GetyById(_context, id);
            if (oResultado.Estado == 1) return View(oResultado.Datos);
            ViewBag.error = oResultado.Mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(TblDepartamento oDepartamento)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _DepartamentoBLL.EditDepartamento(_context, oDepartamento);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "Departamento", new { mensaje = oDepartamento.Descripcion + " modificada con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            return View(oDepartamento);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var oResultado = _DepartamentoBLL.DeleteDepartamento(_context, id);
            if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "Departamento", new { mensaje = "Departamento eliminado con éxito!" });
            return RedirectToAction(nameof(Index), "Departamento", new { mensaje = oResultado.Mensaje });
        }
    }
}
