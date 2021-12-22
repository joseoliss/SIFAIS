using Microsoft.AspNetCore.Mvc.Rendering;
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

        public Respuesta GetyById(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = context.TblDonantes.Find(id);
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al filtrar!";
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
                context.SaveChanges();
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al eliminar! " ;
                if (ex.GetType().ToString() == "Microsoft.EntityFrameworkCore.DbUpdateException")
                {
                    oRespuesta.Mensaje = "¡No se puede eliminar ya que existe una relación con otra entidad! ";
                }
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
                context.Update(DonanteDB).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            return (from s in context.TblDonantes
                    where s.Estado == true
                    select s).Select(i => new SelectListItem()
                    {
                Text = i.Nombre,
                Value = i.Id.ToString()
            });
        }

        public List<SelectListItem> GetListDonanteRep(ApplicationDbContext context)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            SelectListItem lstItem = new SelectListItem()
            {
                Text = "-Todos-",
                Value = "%%"
            };
            lst = (from s in context.TblDonantes
                    where s.Estado == true
                    select s).Select(i => new SelectListItem()
                    {
                        Text = i.Nombre,
                        Value = i.Nombre
                    }).ToList();
            lst.Insert(0,lstItem);
            return lst;
        }

        public Respuesta ListDonante(ApplicationDbContext context)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = (from d in context.DonanteView
                                    orderby d.TipoDonante
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
    }
}
