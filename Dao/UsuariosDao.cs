using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public partial class UsuariosDao : IDisposable
    {
        CustomContext oContext { get; set; }

        public UsuariosDao(CustomContext oCustomContext)
        {
            this.oContext = oCustomContext;
        }

        public UsuariosDao()
        {
            oContext = new CustomContext();
        }

        //Consultar Ubicaciones
        public IQueryable<Usuario> ConsultarUsuarios()
        {
            var unidad = from i in oContext.UsuariosGet
                         select i;
            return unidad;
        }

        public Usuario ConsultarUsuarioLogin(string usuario, string clave)
        {
            var usuarioLogin = oContext.UsuariosGet
                                       .FirstOrDefault(p => p.usuario.Equals(usuario)
                                            && p.contraseña.Equals(clave)
                                            && p.estado == true);

            if (usuarioLogin != null)
            {
                var rol = oContext.RolesGet.FirstOrDefault(x => x.id_rol == usuarioLogin.id_rol);

                if (rol != null)
                {
                    usuarioLogin.rol = rol.descripcion;
                }
            }
            return usuarioLogin;
        }

        public Usuario ConsultarUsuarioPorId(int idUsuario)
        {
            return oContext.UsuariosGet.FirstOrDefault(p => p.id_usuario.Equals(idUsuario));
        }

        //Guardar usuario
        public bool GuardarUsuario(Usuario usuario)
        {
            bool resultado = false;
            using (CustomContext oContext = new CustomContext())
            {
                usuario.estado = true;
                usuario.id_rol = 1;//Administrador

                oContext.UsuariosGet.Add(usuario);
                oContext.SaveChanges();
                resultado = true;
            }
            return resultado;
        }

        //Actualizar usuario
        public bool EditarUsuario(Usuario usuario)
        {
            bool resultado = false;
            using (CustomContext oContext = new CustomContext())
            {
                var item = (from i in oContext.UsuariosGet
                            where i.id_usuario == usuario.id_usuario
                            select i).FirstOrDefault();

                if (item != null)
                {
                    item.nombre = usuario.nombre;
                    item.usuario = usuario.usuario;
                    item.contraseña = usuario.contraseña;
                    item.identificacion = usuario.identificacion;
                    item.telefono = usuario.telefono;
                    item.email = usuario.email;
                    item.apellido = usuario.apellido;
                    item.avatar = usuario.avatar;

                    oContext.SaveChanges();
                    resultado = true;
                }
            }
            return resultado;
        }

        //Eliminar usuario
        public bool EliminarUsuario(int id)
        {
            bool resultado = false;
            using (CustomContext oContext = new CustomContext())
            {
                Usuario usuario = (from i in oContext.UsuariosGet
                                    where i.id_usuario == id
                                    select i).FirstOrDefault();

                if (usuario != null)
                {
                    oContext.UsuariosGet.Remove(usuario);
                    oContext.SaveChanges();
                    resultado = true;
                }
            }

            return resultado;
        }
        public void Dispose()
        {
            if (oContext != null)
            {
                oContext.Dispose();
            }
        }
    }
}
