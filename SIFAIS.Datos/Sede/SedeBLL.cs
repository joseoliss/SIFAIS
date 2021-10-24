using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.Sede
{
    public class SedeBLL : ISedeBLL
    {
        public Respuesta AddSede(ApplicationDbContext context, TblSede oSede)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                context.TblSedes.Add(oSede);
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

        public Respuesta ChangeStateSede(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var SedeDB = context.TblSedes.Find(id);
                if (SedeDB.Estado)
                {
                    SedeDB.Estado = false;
                }
                else
                {
                    SedeDB.Estado = true;
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

        public Respuesta DeleteSede(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var SedeDB = context.TblSedes.Find(id);
                context.TblSedes.Remove(SedeDB);
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al eliminar!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public Respuesta EditSede(ApplicationDbContext context, TblSede oSede)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var SedeDB = context.TblSedes.Find(oSede.Id);
                SedeDB.Nombre = oSede.Nombre;
                SedeDB.Detalles = oSede.Detalles;
                SedeDB.Direccion = oSede.Direccion;
                SedeDB.CorreoElectronico = oSede.CorreoElectronico;
                SedeDB.Telefono = oSede.Telefono;
                SedeDB.Estado = oSede.Estado;
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

        public IEnumerable<SelectListItem> GetListSede(ApplicationDbContext context)
        {
            return context.TblSedes.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Id.ToString()
            });
        }

        public Respuesta ListSede(ApplicationDbContext context)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = context.TblSedes.ToList();
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
