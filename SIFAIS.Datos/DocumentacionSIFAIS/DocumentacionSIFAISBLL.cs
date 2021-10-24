using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.DocumentacionSIFAIS
{
    public class DocumentacionSIFAISBLL : IDocumentacionSIFAISBLL
    {
        public Respuesta AddDocumentacionSIFAIS(ApplicationDbContext context, TblDocumentacionSifai oDocumentacionSIFAIS)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                context.TblDocumentacionSifais.Add(oDocumentacionSIFAIS);
                context.SaveChanges();
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error agregar!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public Respuesta ChangeStateDocumentacionSIFAIS(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var documentacionSIFAISDB = context.TblDocumentacionSifais.Find(id);
                if (documentacionSIFAISDB.Estado)
                {
                    documentacionSIFAISDB.Estado = false;
                }
                else
                {
                    documentacionSIFAISDB.Estado = true;
                }
                context.SaveChanges();
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al actualizar el estado!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public Respuesta DeleteDocumentacionSIFAIS(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var documentacionSIFAISDB = context.TblDocumentacionSifais.Find(id);
                context.TblDocumentacionSifais.Remove(documentacionSIFAISDB);
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al eliminar!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public Respuesta EditDocumentacionSIFAIS(ApplicationDbContext context, TblDocumentacionSifai oDocumentacionSIFAIS)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var documentacionSIFAISDB = context.TblDocumentacionSifais.Find(oDocumentacionSIFAIS.Id);
                documentacionSIFAISDB.Descripcion = oDocumentacionSIFAIS.Descripcion;
                documentacionSIFAISDB.Estado = oDocumentacionSIFAIS.Estado;
                context.SaveChanges();
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al actualizar!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public IEnumerable<SelectListItem> GetListDocumentacionSIFAIS(ApplicationDbContext context)
        {
            return context.TblDocumentacionSifais.Select(i => new SelectListItem()
            {
                Text = i.Descripcion,
                Value = i.Id.ToString()
            });
        }

        public Respuesta ListDocumentacionSIFAIS(ApplicationDbContext context)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = context.TblDocumentacionSifais.ToList();
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al cargar los datos!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }
    }
}
