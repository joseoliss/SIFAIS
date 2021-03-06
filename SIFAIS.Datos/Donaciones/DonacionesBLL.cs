using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.Donaciones
{
    public class DonacionesBLL : IDonacionesBLL
    {
        public Respuesta AddDonacion(ApplicationDbContext context, TblDonacione oDonacion)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                if (oDonacion.FechaDonacion.Year < 1900 || oDonacion.FechaDonacion.Year > 9999)
                {
                    throw new Exception();
                }
                oDonacion.Estado = true;
                context.Add(oDonacion);
                context.SaveChanges();
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error agregar!";
                if (oDonacion.FechaDonacion.Year < 1900 || oDonacion.FechaDonacion.Year > 9999)
                {
                    oRespuesta.Mensaje = "¡La fecha debe estar entre el año 1900 y 9999!";
                }
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public Respuesta GetById(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = (from d in context.TblDonaciones
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

        public Respuesta DeleteDonacion(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var oDonacionDB = context.TblDonaciones.FirstOrDefault(x => x.Id == id);
                context.TblDonaciones.Remove(oDonacionDB);
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

        public Respuesta EditDonacion(ApplicationDbContext context, TblDonacione oDonacion)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var oDonacionDB = context.TblDonaciones.FirstOrDefault(x => x.Id == oDonacion.Id);
                oDonacionDB.IdTipoDonacion = oDonacion.IdTipoDonacion;
                oDonacionDB.IdDonante = oDonacion.IdDonante;
                oDonacionDB.IdSede = oDonacion.IdSede;
                oDonacionDB.IdDocSifais = oDonacion.IdDocSifais;
                oDonacionDB.IdMensajero = oDonacion.IdMensajero;
                oDonacionDB.IdEspacio = oDonacion.IdEspacio;
                oDonacionDB.IdResponsableDonacion = oDonacion.IdResponsableDonacion;
                oDonacionDB.Descripcion = oDonacion.Descripcion;
                oDonacionDB.Detalles = oDonacion.Detalles;
                oDonacionDB.FechaDonacion = oDonacion.FechaDonacion;
                oDonacionDB.Cantidad = oDonacion.Cantidad;
                oDonacionDB.Estado = oDonacion.Estado;
                context.Update(oDonacionDB).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public Respuesta ListDonaciones(ApplicationDbContext context)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = (from d in context.DonacionesView
                                    orderby d.FechaDonacion descending
                                    select d).ToList();
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al cargar los datos!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }


        public Respuesta ListRepDonaciones(ApplicationDbContext context, string Origen, string Tipo, DateTime Desde, DateTime Hasta)
        {
            string tipoDonacion = Tipo == "%%" ? "" : Tipo; 
            string Donador = Origen == "%%" ? "" : Origen; 
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = (from r in context.ReporteDonacionesView
                                    where r.TipoDonacion.Contains(tipoDonacion)
                                    && r.Origen.Contains(Donador)
                                    && r.FechaDonacion >= Desde
                                    && r.FechaDonacion <= Hasta
                                    select r).ToList();
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
