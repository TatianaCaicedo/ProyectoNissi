using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public partial class DetallePedidoDao : IDisposable
    {
        CustomContext oContext { get; set; }

        public DetallePedidoDao(CustomContext oCustomContext)
        {
            this.oContext = oCustomContext;
        }

        public DetallePedidoDao()
        {
            oContext = new CustomContext();
        }

        //Guardar DetallePedido
        public void GuardarUnidad(DetallePedido DetallePedido)
        {
            using (CustomContext oContext = new CustomContext())
            {
                oContext.DetallePedidoGet.Add(DetallePedido);
                oContext.SaveChanges();
            }
        }

        //Actualizar DetallePedido
        public void ActualizarDetallePedido(DetallePedido DetallePedido)
        {
            using (CustomContext oContext = new CustomContext())
            {
                var item = (from i in oContext.DetallePedidoGet
                            where i.id_detallePedido == DetallePedido.id_detallePedido
                            select i).FirstOrDefault();

                item.ped_numPedido = DetallePedido.ped_numPedido;

                oContext.SaveChanges();
            }
        }

        //Eliminar DetallePedido
        public void EliminarUnidad(int id)
        {
            using (CustomContext oContext = new CustomContext())
            {
                DetallePedido DetallePedido = (from i in oContext.DetallePedidoGet
                                               where i.id_detallePedido == id
                                               select i).FirstOrDefault();

                oContext.DetallePedidoGet.Remove(DetallePedido);
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
