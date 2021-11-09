using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIFAIS.Datos;
using SIFAIS.Datos.DocumentacionSIFAIS;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Controllers
{
    [Authorize]
    public class DocumentacionSifaisController : Controller
    {
        #region CONSTRUCTOR
        private readonly ApplicationDbContext _context;
        private IDocumentacionSIFAISBLL _documentacionSIFAISBLL;
        public DocumentacionSifaisController(ApplicationDbContext context, IDocumentacionSIFAISBLL documentacionSIFAISBLL)
        {
            _context = context;
            _documentacionSIFAISBLL = documentacionSIFAISBLL;
        }
        #endregion

        [HttpGet]
        public IActionResult Index(string mensaje)
        {
            if (mensaje != string.Empty)
            {
                ViewBag.exito = mensaje;
            }
            var oRespuesta = _documentacionSIFAISBLL.ListDocumentacionSIFAIS(_context);
            if (oRespuesta.Estado == 1) return View(oRespuesta.Datos);
            ViewBag.error = oRespuesta.Mensaje;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TblDocumentacionSifai oDocumentacion)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _documentacionSIFAISBLL.AddDocumentacionSIFAIS(_context, oDocumentacion);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "DocumentacionSifais", new { mensaje = oDocumentacion.Descripcion + " almacenado con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            return View(oDocumentacion);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var oResultado = _documentacionSIFAISBLL.GetyById(_context, id);
            if (oResultado.Estado == 1) return View(oResultado.Datos);
            ViewBag.error = oResultado.Mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(TblDocumentacionSifai oDocumentacion)
        {
            if (ModelState.IsValid)
            {
                var oResultado = _documentacionSIFAISBLL.EditDocumentacionSIFAIS(_context, oDocumentacion);
                if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "DocumentacionSifais", new { mensaje = oDocumentacion.Descripcion + " modificada con éxito!" });
                ViewBag.error = oResultado.Mensaje;
            }
            return View(oDocumentacion);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var oResultado = _documentacionSIFAISBLL.DeleteDocumentacionSIFAIS(_context, id);
            if (oResultado.Estado == 1) return RedirectToAction(nameof(Index), "DocumentacionSifais", new { mensaje = "Documentación eliminada con éxito!" });
            return RedirectToAction(nameof(Index), "DocumentacionSifais", new { mensaje = oResultado.Mensaje });
        }
    }
}
