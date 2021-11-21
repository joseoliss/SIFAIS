using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.TipoResponsable
{
    public class TipoResponsableBLL : ITipoResponsableBLL
    {
        public Respuesta AddTipoResponsable(ApplicationDbContext context, TblTipoResponsable oTipoResponsable)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                context.TblTipoResponsables.Add(oTipoResponsable);
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
                oRespuesta.Datos = (from d in context.TblTipoResponsables
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
        public Respuesta ChangeStateTipoResponsable(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var tipoResponsableDB = context.TblTipoResponsables.Find(id);
                if (tipoResponsableDB.Estado)
                {
                    tipoResponsableDB.Estado = false;
                }
                else
                {
                    tipoResponsableDB.Estado = true;
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

        public Respuesta DeleteTipoResponsable(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var tipoResponsableDB = context.TblTipoResponsables.Find(id);
                context.TblTipoResponsables.Remove(tipoResponsableDB);
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

        public Respuesta EditTipoResponsable(ApplicationDbContext context, TblTipoResponsable oTipoResponsable)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var tipoResponsableDB = context.TblTipoResponsables.Find(oTipoResponsable.Id);
                tipoResponsableDB.Descripcion = oTipoResponsable.Descripcion;
                tipoResponsableDB.Detalles = oTipoResponsable.Detalles;
                tipoResponsableDB.Estado = oTipoResponsable.Estado;
                context.Update(tipoResponsableDB).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public IEnumerable<SelectListItem> GetListTipoResponsable(ApplicationDbContext context)
        {
            return (from d in context.TblTipoResponsables
                    where d.Estado == true
                    select d).Select(i => new SelectListItem()
                    {
                Text = i.Descripcion,
                Value = i.Id.ToString()
            });
        }

        public Respuesta ListTipoResponsable(ApplicationDbContext context)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = context.TblTipoResponsables.ToList();
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
