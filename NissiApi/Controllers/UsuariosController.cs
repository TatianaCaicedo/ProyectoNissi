using BussinesLogic;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace NissiApi.Controllers
{
    public class UsuariosController : ApiController
    {
        [HttpGet]
        public IHttpActionResult ConsultarListaUsuarios()
        {
            try
            {
                UsuariosBL oUnidadBl = new UsuariosBL();
                var result = oUnidadBl.ConsultarListaUsuarios();
                return Ok(new { success = true, Usuario = result });

            }
            catch (Exception ex)
            {
                //General.LogManager.WriteLog(ex);
                return Ok(new { success = false, exc = ex.Message });
            }
        }

        [HttpGet]
        public IHttpActionResult Login(string value)
        {
            var item = Newtonsoft.Json.JsonConvert.DeserializeObject<Usuario>(value);
            UsuariosBL oUsuarioBL = new UsuariosBL();

            try
            {
                var usuario = oUsuarioBL.ConsultarUsuarioLogin(item.usuario, item.contraseña);

                return Ok(new { success = true, usuario });
            }
            catch (Exception exc)
            {
                //General.LogManager.WriteLog(exc);
                return Ok(new { success = false, exc = exc.Message });
            }
        }

        [HttpGet]
        public IHttpActionResult GuardarUsuario(string value)
        {
            var item = Newtonsoft.Json.JsonConvert.DeserializeObject<Usuario>(value);
            UsuariosBL oUsuarioBL = new UsuariosBL();

            try
            {
                var resultado = oUsuarioBL.GuardarUsuario(item);

                return Ok(new { success = true, resultado });
            }
            catch (Exception exc)
            {
                //General.LogManager.WriteLog(exc);
                return Ok(new { success = false, exc = exc.Message });
            }
        }

        [HttpGet]
        public IHttpActionResult EditarUsuario(string value)
        {
            var item = Newtonsoft.Json.JsonConvert.DeserializeObject<Usuario>(value);
            UsuariosBL oUsuarioBL = new UsuariosBL();

            try
            {
                var resultado = oUsuarioBL.EditarUsuario(item);

                return Ok(new { success = true, resultado });
            }
            catch (Exception exc)
            {
                //General.LogManager.WriteLog(exc);
                return Ok(new { success = false, exc = exc.Message });
            }
        }

        [HttpGet]
        public IHttpActionResult EliminarUsuario(string value)
        {
            var item = Newtonsoft.Json.JsonConvert.DeserializeObject<Usuario>(value);
            UsuariosBL oUsuarioBL = new UsuariosBL();

            try
            {
                var resultado = oUsuarioBL.EliminarUsuario(item);

                return Ok(new { success = true, resultado });
            }
            catch (Exception exc)
            {
                //General.LogManager.WriteLog(exc);
                return Ok(new { success = false, exc = exc.Message });
            }
        }
    }
}