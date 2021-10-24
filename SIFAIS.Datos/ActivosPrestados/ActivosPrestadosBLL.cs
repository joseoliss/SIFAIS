using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.ActivosPrestados
{
    public class ActivosPrestadosBLL : IActivosPrestadosBLL
    {
        public Respuesta AddActivosPrestados(ApplicationDbContext context, TblActivosPrestado oActivosPrestados)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                context.TblActivosPrestados.Add(oActivosPrestados);
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

        public Respuesta ChangeStateActivosPrestados(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var ActivosPrestadosDB = context.TblActivosPrestados.Find(id);
                if (ActivosPrestadosDB.Estado)
                {
                    ActivosPrestadosDB.Estado = false;
                }
                else
                {
                    ActivosPrestadosDB.Estado = true;
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

        public Respuesta DeleteActivosPrestados(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var ActivosPrestadosDB = context.TblActivosPrestados.Find(id);
                context.TblActivosPrestados.Remove(ActivosPrestadosDB);
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al eliminar!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public Respuesta EditActivosPrestados(ApplicationDbContext context, TblActivosPrestado oActivosPrestados)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var ActivosPrestadosDB = context.TblActivosPrestados.Find(oActivosPrestados.Id);
                ActivosPrestadosDB.IdActivo = oActivosPrestados.IdActivo;
                ActivosPrestadosDB.IdResponsable = oActivosPrestados.IdResponsable;
                ActivosPrestadosDB.Detalle = oActivosPrestados.Detalle;
                ActivosPrestadosDB.Cantidad = oActivosPrestados.Cantidad;
                ActivosPrestadosDB.LugarPrestamo = oActivosPrestados.LugarPrestamo;
                ActivosPrestadosDB.FechaInicio = oActivosPrestados.FechaInicio;
                ActivosPrestadosDB.FechaFin = oActivosPrestados.FechaFin;
                ActivosPrestadosDB.DiasTranscurridos = oActivosPrestados.DiasTranscurridos;
                ActivosPrestadosDB.Estado = oActivosPrestados.Estado;
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

        public Respuesta ListActivosPrestados(ApplicationDbContext context)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = context.TblActivosPrestados.ToList();
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
