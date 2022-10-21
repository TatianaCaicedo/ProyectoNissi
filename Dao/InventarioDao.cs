using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public partial class InventarioDao : IDisposable
    {
        CustomContext oContext { get; set; }

        public InventarioDao(CustomContext oCustomContext)
        {
            this.oContext = oCustomContext;
        }

        public InventarioDao()
        {
            oContext = new CustomContext();
        }

        //Guardar Inventario
        public void GuardarUnidad(Inventario Inventario)
        {
            using (CustomContext oContext = new CustomContext())
            {
                oContext.InventarioGet.Add(Inventario);
                oContext.SaveChanges();
            }
        }

        //Actualizar Inventario
        public void ActualizarInventario(Inventario Inventario)
        {
            using (CustomContext oContext = new CustomContext())
            {
                var item = (from i in oContext.InventarioGet
                            where i.id == Inventario.id
                            select i).FirstOrDefault();

                item.produc_idItem = Inventario.produc_idItem;

                oContext.SaveChanges();
            }
        }

        //Eliminar Inventario
        public void EliminarUnidad(int id)
        {
            using (CustomContext oContext = new CustomContext())
            {
                Inventario Inventario = (from i in oContext.InventarioGet
                                    where i.id == id
                                    select i).FirstOrDefault();

                oContext.InventarioGet.Remove(Inventario);
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
