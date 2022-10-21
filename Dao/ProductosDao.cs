using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public partial class ProductosDao : IDisposable
    {
        CustomContext oContext { get; set; }

        public ProductosDao(CustomContext oCustomContext)
        {
            this.oContext = oCustomContext;
        }

        public ProductosDao()
        {
            oContext = new CustomContext();
        }

        //Guardar Producto
        public void GuardarUnidad(Productos Producto)
        {
            using (CustomContext oContext = new CustomContext())
            {
                oContext.ProductosGet.Add(Producto);
                oContext.SaveChanges();
            }
        }

        //Actualizar Producto
        public void ActualizarProducto(Productos Producto)
        {
            using (CustomContext oContext = new CustomContext())
            {
                var item = (from i in oContext.ProductosGet
                            where i.idItem == Producto.idItem
                            select i).FirstOrDefault();

                item.prov_idProveedor = Producto.prov_idProveedor;

                oContext.SaveChanges();
            }
        }

        //Eliminar Producto
        public void EliminarUnidad(int id)
        {
            using (CustomContext oContext = new CustomContext())
            {
                Productos Producto = (from i in oContext.ProductosGet
                                    where i.idItem == id
                                    select i).FirstOrDefault();

                oContext.ProductosGet.Remove(Producto);
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
