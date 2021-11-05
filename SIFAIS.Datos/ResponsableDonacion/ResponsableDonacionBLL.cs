using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.ResponsableDonacion
{
    public class ResponsableDonacionBLL : IResponsableDonacionBLL
    {
        public Respuesta AddResponsableDonacion(ApplicationDbContext context, TblResponsableDonacion oResponsableDonacion)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                context.TblResponsableDonacions.Add(oResponsableDonacion);
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

        public Respuesta GetyById(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = (from d in context.TblResponsableDonacions
                                    where d.Id == id
                                    select d).FirstOrDefault();
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al filtrar!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public Respuesta ChangeStateResponsableDonacion(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var ResponsableDonacionDB = context.TblResponsableDonacions.Find(id);
                if (ResponsableDonacionDB.Estado)
                {
                    ResponsableDonacionDB.Estado = false;
                }
                else
                {
                    ResponsableDonacionDB.Estado = true;
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

        public Respuesta DeleteResponsableDonacion(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var ResponsableDonacionDB = context.TblResponsableDonacions.Find(id);
                context.TblResponsableDonacions.Remove(ResponsableDonacionDB);
                context.SaveChanges();
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al eliminar!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public Respuesta EditResponsableDonacion(ApplicationDbContext context, TblResponsableDonacion oResponsableDonacion)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var ResponsableDonacionDB = context.TblResponsableDonacions.Find(oResponsableDonacion.Id);
                ResponsableDonacionDB.Nombre = oResponsableDonacion.Nombre;
                ResponsableDonacionDB.Apellido = oResponsableDonacion.Apellido;
                ResponsableDonacionDB.Cedula = oResponsableDonacion.Cedula;
                ResponsableDonacionDB.Celular = oResponsableDonacion.Celular;
                ResponsableDonacionDB.CorreoElectronico = oResponsableDonacion.CorreoElectronico;
                ResponsableDonacionDB.Estado = oResponsableDonacion.Estado;
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

        public IEnumerable<SelectListItem> GetListResponsableDonacion(ApplicationDbContext context)
        {
            return context.TblResponsableDonacions.Select(i => new SelectListItem()
            {
                Text = i.Nombre + " " + i.Apellido,
                Value = i.Id.ToString()
            });
        }

        public Respuesta ListResponsableDonacion(ApplicationDbContext context)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = context.TblResponsableDonacions.ToList();
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
