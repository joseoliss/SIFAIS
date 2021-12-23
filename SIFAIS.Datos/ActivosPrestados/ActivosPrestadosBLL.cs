using SIFAIS.Datos.ActivosFisicos;
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
        private IActivosFisicosBLL _activo;
        public ActivosPrestadosBLL(IActivosFisicosBLL activo)
        {
            _activo = activo;
        }

        public Respuesta AddActivosPrestados(ApplicationDbContext context, TblActivosPrestado oActivosPrestados)
        {
            Respuesta oRespuesta = new Respuesta();
            bool estadoTransaccion = false;
            try
            {
                using (var dbTransacction = context.Database.BeginTransaction())
                {
                    if (oActivosPrestados.FechaInicio.Year < 1900 || oActivosPrestados.FechaInicio.Year > 9999 || oActivosPrestados.FechaFin.Year < 1900 || oActivosPrestados.FechaFin.Year > 9999)
                    {
                        oRespuesta.Mensaje = "¡Las fechas deben estar entre el año 1900 y 9999!";
                        oRespuesta.Estado = 0;
                    }
                    else
                    {
                        if (oActivosPrestados.FechaInicio > oActivosPrestados.FechaFin)
                        {
                            oRespuesta.Estado = 0;
                            oRespuesta.Mensaje = "¡La fecha de inicio debe ser menor a la fecha final!";
                        }
                        else
                        {
                            if (oActivosPrestados.Cantidad < 1)
                            {
                                oRespuesta.Estado = 0;
                                oRespuesta.Mensaje = "¡La cantidad a prestar debe ser mayor a 0!";
                            }
                            else
                            {
                                var activoCount = (TblActivosFisico)_activo.GetyById(context,oActivosPrestados.IdActivo).Datos;
                                if (activoCount.Cantidad < oActivosPrestados.Cantidad)
                                {
                                    oRespuesta.Estado = 0;
                                    oRespuesta.Mensaje = "¡La cantidad a prestar es mayor que las existencias totales!";
                                }
                                else
                                {
                                    context.TblActivosPrestados.Add(oActivosPrestados);
                                    context.SaveChanges();
                                    oRespuesta.Estado = 1;
                                    estadoTransaccion = oRespuesta.Estado == 1 ? true : false;

                                    if (estadoTransaccion)
                                    {
                                        var resActivo = _activo.PrestarDevolverActivo(context, oActivosPrestados.IdActivo, oActivosPrestados.Cantidad, "restar");
                                        estadoTransaccion = resActivo.Estado == 1 ? true : false;
                                    }
                                }                                
                            }
                        }
                    }

                    if (estadoTransaccion)
                    {
                        dbTransacction.Commit();
                    }
                    else
                    {
                        dbTransacction.Rollback();
                        if (oRespuesta.Mensaje == "")
                        {
                            oRespuesta.Mensaje = "¡Ha ocurrido un error agregar!";
                            oRespuesta.Estado = 0;
                        }
                    }
                }
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
                oRespuesta.Datos = (from d in context.TblActivosPrestados
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
        public Respuesta DevolverActivoPrestado(ApplicationDbContext context, string data)
        {
            var IdActivo = Convert.ToInt32(data.Split("~")[0]);
            var IdPrestado = Convert.ToInt32(data.Split("~")[1]);
            bool estadoTransaccion = false;
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (var dbTransacction = context.Database.BeginTransaction())
                {
                    var ActivosPrestadosDB = context.TblActivosPrestados.Find(IdPrestado);
                    ActivosPrestadosDB.Estado = false;
                    context.SaveChanges();
                    oRespuesta.Estado = 1;
                    estadoTransaccion = oRespuesta.Estado == 1 ? true : false;

                    if (estadoTransaccion)
                    {
                        var resActivo = _activo.PrestarDevolverActivo(context, IdActivo, ActivosPrestadosDB.Cantidad, "sumar");
                        estadoTransaccion = resActivo.Estado == 1 ? true : false;
                    }

                    if (estadoTransaccion)
                    {
                        dbTransacction.Commit();
                    }
                    else
                    {
                        dbTransacction.Rollback();
                        if (oRespuesta.Mensaje == "")
                        {
                            oRespuesta.Mensaje = "¡Ha ocurrido un error agregar!";
                            oRespuesta.Estado = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al devolver el activo!";
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

        public Respuesta EditActivosPrestados(ApplicationDbContext context, TblActivosPrestado oActivosPrestados)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                if (oActivosPrestados.FechaInicio.Year < 1900 || oActivosPrestados.FechaInicio.Year > 9999 || oActivosPrestados.FechaFin.Year < 1900 || oActivosPrestados.FechaFin.Year > 9999)
                {
                    oRespuesta.Mensaje = "¡Las fechas deben estar entre el año 1900 y 9999!";
                    oRespuesta.Estado = 0;
                }
                else
                {
                    if (oActivosPrestados.FechaInicio > oActivosPrestados.FechaFin)
                    {
                        oRespuesta.Estado = 0;
                        oRespuesta.Mensaje = "¡La fecha de inicio debe ser menor a la fecha final!";
                    }
                    else
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
                        context.Update(ActivosPrestadosDB).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        context.SaveChanges();
                        oRespuesta.Estado = 1;
                    }
                }
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
                oRespuesta.Datos = (from a in context.ActivosPrestadosViews
                                    where a.Estado == true
                                    select a).ToList();
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al cargar los datos!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public Respuesta ListHistorialPrestamos(ApplicationDbContext context)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = (from a in context.ActivosPrestadosViews
                                    where a.Estado == false
                                    select a).ToList();
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al cargar los datos!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public Respuesta ListActivosPrestadosRep(ApplicationDbContext context, string Tipo, string Estado, string Responsable, DateTime Desde, DateTime Hasta)
        {
            string TipoActivo = Tipo == "%%" ? "" : Tipo;
            string EstadoActivo = Estado == "%%" ? "" : Estado;
            string ResponsablePrestamo = Responsable == "%%" ? "" : Responsable;
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = (from a in context.ActivosPrestadosViews
                                    where a.Estado == true
                                    && a.TipoActivo.Contains(TipoActivo)
                                    && a.EstadoActivo.Contains(EstadoActivo)
                                    && a.Responsable.Contains(ResponsablePrestamo)
                                    && a.FechaInicio >= Desde
                                    && a.FechaInicio <= Hasta
                                    select a).ToList();
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al cargar los datos!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public Respuesta ListHistorialPrestamosRep(ApplicationDbContext context, string Tipo, string Estado, string Responsable, DateTime Desde, DateTime Hasta)
        {
            string TipoActivo = Tipo == "%%" ? "" : Tipo;
            string EstadoActivo = Estado == "%%" ? "" : Estado;
            string ResponsablePrestamo = Responsable == "%%" ? "" : Responsable;
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = (from a in context.ActivosPrestadosViews
                                    where a.Estado == false
                                    && a.TipoActivo.Contains(TipoActivo)
                                    && a.EstadoActivo.Contains(EstadoActivo)
                                    && a.Responsable.Contains(ResponsablePrestamo)
                                    && a.FechaInicio >= Desde
                                    && a.FechaInicio <= Hasta
                                    select a).ToList();
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
