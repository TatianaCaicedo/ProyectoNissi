using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public partial class RolesDao : IDisposable
    {
        CustomContext oContext { get; set; }

        public RolesDao(CustomContext oCustomContext)
        {
            this.oContext = oCustomContext;
        }

        public RolesDao()
        {
            oContext = new CustomContext();
        }

        //Guardar Rol
        public void GuardarUnidad(Roles Rol)
        {
            using (CustomContext oContext = new CustomContext())
            {
                oContext.RolesGet.Add(Rol);
                oContext.SaveChanges();
            }
        }

        //Actualizar Rol
        public void ActualizarRol(Roles Rol)
        {
            using (CustomContext oContext = new CustomContext())
            {
                var item = (from i in oContext.RolesGet
                            where i.id_rol == Rol.id_rol
                            select i).FirstOrDefault();

                item.descripcion = Rol.descripcion;

                oContext.SaveChanges();
            }
        }

        //Eliminar Rol
        public void EliminarUnidad(int id)
        {
            using (CustomContext oContext = new CustomContext())
            {
                Roles Rol = (from i in oContext.RolesGet
                                    where i.id_rol == id
                                    select i).FirstOrDefault();

                oContext.RolesGet.Remove(Rol);
                oContext.SaveChanges();
            }
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
