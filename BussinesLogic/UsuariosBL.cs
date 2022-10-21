using Dao;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public class UsuariosBL
    {
        public List<Usuario> ConsultarListaUsuarios()
        {
            return new UsuariosDao().ConsultarUsuarios().ToList();
        }

        public Usuario ConsultarUsuarioLogin(string usuario, string clave)
        {
            return new UsuariosDao().ConsultarUsuarioLogin(usuario, clave);
        }

        public bool GuardarUsuario(Usuario usuario)
        {
            return new UsuariosDao().GuardarUsuario(usuario);
        }

        public bool EditarUsuario(Usuario usuario)
        {
            return new UsuariosDao().EditarUsuario(usuario);
        }

        public bool EliminarUsuario(Usuario usuario)
        {
            return new UsuariosDao().EliminarUsuario(usuario.id_usuario);
        }
    }
}
