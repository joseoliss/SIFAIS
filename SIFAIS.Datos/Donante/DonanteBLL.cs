﻿using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.Donante
{
    public class DonanteBLL : IDonanteBLL
    {
        public Respuesta AddDonante(ApplicationDbContext context, TblDonante oDonante)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                context.TblDonantes.Add(oDonante);
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

        public Respuesta ChangeStateDonante(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var DonanteDB = context.TblDonantes.Find(id);
                if (DonanteDB.Estado)
                {
                    DonanteDB.Estado = false;
                }
                else
                {
                    DonanteDB.Estado = true;
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

        public Respuesta DeleteDonante(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var DonanteDB = context.TblDonantes.Find(id);
                context.TblDonantes.Remove(DonanteDB);
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al eliminar!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public Respuesta EditDonante(ApplicationDbContext context, TblDonante oDonante)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var DonanteDB = context.TblDonantes.Find(oDonante.Id);
                DonanteDB.IdTipoDonante = oDonante.IdTipoDonante;
                DonanteDB.CodigoExterno = oDonante.CodigoExterno;
                DonanteDB.Nombre = oDonante.Nombre;
                DonanteDB.Descripcion = oDonante.Descripcion;
                DonanteDB.Direccion = oDonante.Direccion;
                DonanteDB.CorreoElectronico = oDonante.CorreoElectronico;
                DonanteDB.Telefono = oDonante.Telefono;
                DonanteDB.Celular = oDonante.Celular;
                DonanteDB.Estado = oDonante.Estado;
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

        public IEnumerable<SelectListItem> GetListDonante(ApplicationDbContext context)
        {
            return context.TblDonantes.Select(i => new SelectListItem()
            {
                Text = i.Descripcion,
                Value = i.Id.ToString()
            });
        }

        public Respuesta ListDonante(ApplicationDbContext context)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = context.TblDonantes.ToList();
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
