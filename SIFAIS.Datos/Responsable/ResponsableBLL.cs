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

        public Respuesta GetyById(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = (from d in context.TblResponsables
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
                context.Update(responsableDB).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            return (from s in context.TblResponsables
                    where s.Estado == true
                    select s).Select(i => new SelectListItem()
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
                oRespuesta.Datos = context.ResponsableActivoViews.ToList();
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al cargar los datos!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public List<SelectListItem> GetListResponsableRep(ApplicationDbContext context)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            SelectListItem lstItem = new SelectListItem()
            {
                Text = "-Todos-",
                Value = "%%"
            };

            lst = (from s in context.TblResponsables
                   where s.Estado == true
                   select s).Select(i => new SelectListItem()
                   {
                       Text = i.Nombre,
                       Value = i.Nombre
                   }).ToList();

            lst.Insert(0, lstItem);
            return lst;
        }
    }
}
