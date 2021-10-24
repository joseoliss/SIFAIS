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
                context.Add(oDonacion);
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

        public Respuesta GetDonacionById(ApplicationDbContext context, int id)
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

        public Respuesta ListDonaciones(ApplicationDbContext context)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = context.TblDonaciones.ToList();
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
