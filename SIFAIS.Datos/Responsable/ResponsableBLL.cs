using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.Responsable
{
    public class ResponsableBLL : IResponsableBLL
    {
        public Respuesta AddResponsable(ApplicationDbContext context, TblResponsable oResponsable)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                context.TblResponsables.Add(oResponsable);
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

        public Respuesta ChangeStateResponsable(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var responsableDB = context.TblResponsables.Find(id);
                if (responsableDB.Estado)
                {
                    responsableDB.Estado = false;
                }
                else
                {
                    responsableDB.Estado = true;
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

        public Respuesta DeleteResponsable(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var responsableDB = context.TblResponsables.Find(id);
                context.TblResponsables.Remove(responsableDB);
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al eliminar!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public Respuesta EditResponsable(ApplicationDbContext context, TblResponsable oResponsable)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var responsableDB = context.TblResponsables.Find(oResponsable.Id);
                responsableDB.Nombre = oResponsable.Nombre;
                responsableDB.Apellido = oResponsable.Apellido;
                responsableDB.Cedula = oResponsable.Cedula;
                responsableDB.Celular = oResponsable.Celular;
                responsableDB.CorreoElectronico = oResponsable.CorreoElectronico;
                responsableDB.Estado = oResponsable.Estado;
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

        public IEnumerable<SelectListItem> GetListResponsable(ApplicationDbContext context)
        {
            return context.TblResponsables.Select(i => new SelectListItem()
            {
                Text = i.Nombre + " " + i.Apellido,
                Value = i.Id.ToString()
            });
        }

        public Respuesta ListResponsable(ApplicationDbContext context)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = context.TblResponsables.ToList();
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
