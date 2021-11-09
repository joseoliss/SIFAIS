using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIFAIS.Datos;
using SIFAIS.Datos.RolUsuario;
using SIFAIS.Datos.Sede;
using SIFAIS.Datos.Usuario;
using SIFAIS.Modelos.Datos;
using SIFAIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        #region CONSTRUCTOR
        private readonly ApplicationDbContext _context;
        private IUsuarioBLL _usuarioBLL;
        private IRolUsuarioBLL _rolBLL;
        private ISedeBLL _sede;
        public UsuarioController(ApplicationDbContext context, IUsuarioBLL usuarioBLL, IRolUsuarioBLL rolBLL, ISedeBLL sede)
        {
            _context = context;
            _usuarioBLL = usuarioBLL;
            _rolBLL = rolBLL;
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
            var oRespuesta = _usuarioBLL.ListUsuario(_context);
            if (oRespuesta.Estado == 1) return View(oRespuesta.Datos);
            ViewBag.error = oRespuesta.Mensaje;
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var oResultado = _usuarioBLL.GetyById(_context, id);
            UsuarioVM oUsuarioVM = new UsuarioVM()
            {
                Usuario = new TblUsuario(),
                LstRolUsuario = _rolBLL.GetListRolUsuario(_context),
                LstSede = _sede.GetListSede(_context)
            };
            oUsuarioVM.Usuario = (TblUsuario)oResultado.Datos;
            if (oResultado.Estado == 1) return View(oUsuarioVM);
            ViewBag.error = oResultado.Mensaje;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            UsuarioVM oUsuarioVM = new UsuarioVM()
            {
                Usuario = new TblUsuario(),
                LstRolUsuario = _rolBLL.GetListRolUsuario(_context),
                LstSede = _sede.GetListSede(_context)
            };
            return View(oUsuarioVM);
        }

        [HttpPost]
        public IActionResult Create(UsuarioVM oUsuarioVM)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _usuarioBLL.AddUsuario(_context, oUsuarioVM.Usuario);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "Usuario", new { mensaje = oUsuarioVM.Usuario.Nombre + " " + oUsuarioVM.Usuario.Apellido + " almacenado con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            oUsuarioVM.LstRolUsuario = _rolBLL.GetListRolUsuario(_context);
            oUsuarioVM.LstSede = _sede.GetListSede(_context);
            return View(oUsuarioVM);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var oResultado = _usuarioBLL.GetyById(_context, id);
            UsuarioVM oUsuarioVM = new UsuarioVM()
            {
                Usuario = new TblUsuario(),
                LstRolUsuario = _rolBLL.GetListRolUsuario(_context),
                LstSede = _sede.GetListSede(_context)
            };
            oUsuarioVM.Usuario = (TblUsuario)oResultado.Datos;
            if (oResultado.Estado == 1) return View(oUsuarioVM);
            ViewBag.error = oResultado.Mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(UsuarioVM oUsuarioVM)
        {
            if (ModelState.IsValid)
            {
                if (oUsuarioVM.NewPassword != null)
                {
                    oUsuarioVM.Usuario.Contraseña = oUsuarioVM.NewPassword;
                }
                var oResultado = _usuarioBLL.EditUsuario(_context, oUsuarioVM.Usuario);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "Usuario", new { mensaje = oUsuarioVM.Usuario.Nombre + " " + oUsuarioVM.Usuario.Apellido + " modificado con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            oUsuarioVM.LstRolUsuario = _rolBLL.GetListRolUsuario(_context);
            oUsuarioVM.LstSede = _sede.GetListSede(_context);
            return View(oUsuarioVM);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var oResultado = _usuarioBLL.DeleteUsuario(_context, id);
            if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "Usuario", new { mensaje = "Usuario eliminado con éxito!" });
            return RedirectToAction(nameof(Index), "Usuario", new { mensaje = oResultado.Mensaje });
        }
    }
}
