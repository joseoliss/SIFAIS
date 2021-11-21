using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.Usuario
{
    public class UsuarioBLL : IUsuarioBLL
    {
        public Respuesta AddUsuario(ApplicationDbContext context, TblUsuario oUsuario)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var correoUnico = (from u in context.TblUsuarios
                                   where u.CorreoElectronico == oUsuario.CorreoElectronico
                                   select u.CorreoElectronico).FirstOrDefault();

                if (correoUnico != null)
                {
                    throw new UriFormatException();
                }

                context.TblUsuarios.Add(oUsuario);
                context.SaveChanges();
                oRespuesta.Estado = 1;
            }
            catch (UriFormatException ex)
            {
                oRespuesta.Mensaje = "¡El correo electrónico ya existe!";
                oRespuesta.Estado = 0;
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
                oRespuesta.Datos = (from d in context.TblUsuarios
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

        public Respuesta ChangeStateUsuario(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var usuarioDB = context.TblUsuarios.Find(id);
                if (usuarioDB.Estado)
                {
                    usuarioDB.Estado = false;
                }
                else
                {
                    usuarioDB.Estado = true;
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

        public Respuesta DeleteUsuario(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                if (id != 1)
                {
                    var usuarioDB = context.TblUsuarios.Find(id);
                    context.TblUsuarios.Remove(usuarioDB);
                    context.SaveChanges();
                    oRespuesta.Estado = 1;
                }
                else
                {
                    oRespuesta.Mensaje = "¡No puede eliminar el usuario por defecto!";
                    oRespuesta.Estado = 0;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al eliminar!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public Respuesta EditUsuario(ApplicationDbContext context, TblUsuario oUsuario)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var usuarioDB = context.TblUsuarios.Find(oUsuario.Id);
                usuarioDB.IdRolUsuario = oUsuario.IdRolUsuario;
                usuarioDB.IdSede = oUsuario.IdSede;
                usuarioDB.CodigoExterno = oUsuario.CodigoExterno;
                usuarioDB.Nombre = oUsuario.Nombre;
                usuarioDB.Apellido = oUsuario.Apellido;
                usuarioDB.Edad = oUsuario.Edad;
                usuarioDB.CorreoElectronico = oUsuario.CorreoElectronico;
                usuarioDB.Contraseña = oUsuario.Contraseña;
                usuarioDB.Telefono = oUsuario.Telefono;
                usuarioDB.Celular = oUsuario.Celular;
                usuarioDB.Estado = oUsuario.Estado;
                context.Update(usuarioDB).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public Respuesta ListUsuario(ApplicationDbContext context)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = context.UsuarioViews.ToList();
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
