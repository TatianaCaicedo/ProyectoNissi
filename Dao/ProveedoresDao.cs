using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public partial class ProveedoresDao : IDisposable
    {
        CustomContext oContext { get; set; }

        public ProveedoresDao(CustomContext oCustomContext)
        {
            this.oContext = oCustomContext;
        }

        public ProveedoresDao()
        {
            oContext = new CustomContext();
        }

        //Guardar Proveedor
        public void GuardarUnidad(Proveedores Proveedor)
        {
            using (CustomContext oContext = new CustomContext())
            {
                oContext.ProveedoresGet.Add(Proveedor);
                oContext.SaveChanges();
            }
        }

        //Actualizar Proveedor
        public void ActualizarProveedor(Proveedores Proveedor)
        {
            using (CustomContext oContext = new CustomContext())
            {
                var item = (from i in oContext.ProveedoresGet
                            where i.idProv == Proveedor.idProv
                            select i).FirstOrDefault();

                item.prov_ciudad = Proveedor.prov_ciudad;

                oContext.SaveChanges();
            }
        }

        //Eliminar Proveedor
        public void EliminarUnidad(int id)
        {
            using (CustomContext oContext = new CustomContext())
            {
                Proveedores Proveedor = (from i in oContext.ProveedoresGet
                                    where i.idProv== id
                                    select i).FirstOrDefault();

                oContext.ProveedoresGet.Remove(Proveedor);
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
