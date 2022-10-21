using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public partial class PedidosDao : IDisposable
    {
        CustomContext oContext { get; set; }

        public PedidosDao(CustomContext oCustomContext)
        {
            this.oContext = oCustomContext;
        }

        public PedidosDao()
        {
            oContext = new CustomContext();
        }

        //Guardar Pedido
        public void GuardarUnidad(Pedidos Pedido)
        {
            using (CustomContext oContext = new CustomContext())
            {
                oContext.PedidosGet.Add(Pedido);
                oContext.SaveChanges();
            }
        }

        //Actualizar Pedido
        public void ActualizarPedido(Pedidos Pedido)
        {
            using (CustomContext oContext = new CustomContext())
            {
                var item = (from i in oContext.PedidosGet
                            where i.numPedido == Pedido.numPedido
                            select i).FirstOrDefault();

                item.cl_idCliente = Pedido.cl_idCliente;

                oContext.SaveChanges();
            }
        }

        //Eliminar Pedido
        public void EliminarUnidad(int id)
        {
            using (CustomContext oContext = new CustomContext())
            {
                Pedidos Pedido = (from i in oContext.PedidosGet
                                  where i.numPedido == id
                                  select i).FirstOrDefault();

                oContext.PedidosGet.Remove(Pedido);
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
