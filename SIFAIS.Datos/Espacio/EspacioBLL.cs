using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.Espacio
{
    public class EspacioBLL : IEspacioBLL
    {
        public Respuesta AddEspacio(ApplicationDbContext context, TblEspacio oEspacio)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                context.TblEspacios.Add(oEspacio);
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
                oRespuesta.Datos = (from d in context.TblEspacios
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

        public Respuesta ChangeStateEspacio(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var EspacioDB = context.TblEspacios.Find(id);
                if (EspacioDB.Estado)
                {
                    EspacioDB.Estado = false;
                }
                else
                {
                    EspacioDB.Estado = true;
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

        public Respuesta DeleteEspacio(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var EspacioDB = context.TblEspacios.Find(id);
                context.TblEspacios.Remove(EspacioDB);
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

        public Respuesta EditEspacio(ApplicationDbContext context, TblEspacio oEspacio)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var EspacioDB = context.TblEspacios.Find(oEspacio.Id);
                EspacioDB.Descripcion = oEspacio.Descripcion;
                EspacioDB.Detalles = oEspacio.Detalles;
                EspacioDB.Direccion = oEspacio.Direccion;
                EspacioDB.Estado = oEspacio.Estado;
                context.Update(EspacioDB).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public IEnumerable<SelectListItem> GetListEspacio(ApplicationDbContext context)
        {
            return (from s in context.TblEspacios
                    where s.Estado == true
                    select s).Select(i => new SelectListItem()
                    {
                Text = i.Descripcion,
                Value = i.Id.ToString()
            });
        }

        public Respuesta ListEspacio(ApplicationDbContext context)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = context.TblEspacios.ToList();
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
