using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public partial class ClientesDao : IDisposable
    {
        CustomContext oContext { get; set; }

        public ClientesDao(CustomContext oCustomContext)
        {
            this.oContext = oCustomContext;
        }

        public ClientesDao()
        {
            oContext = new CustomContext();
        }

        //Guardar Clientes
        public void GuardarClientes(Clientes Clientes)
        {
            using (CustomContext oContext = new CustomContext())
            {
                oContext.ClientesGet.Add(Clientes);
                oContext.SaveChanges();
            }
        }

        //Actualizar Clientes
        public void ActualizarClientes(Clientes Clientes)
        {
            using (CustomContext oContext = new CustomContext())
            {
                var item = (from i in oContext.ClientesGet
                            where i.idCliente == Clientes.idCliente
                            select i).FirstOrDefault();

                item.cl_nombre = Clientes.cl_nombre;

                oContext.SaveChanges();
            }
        }

        //Eliminar Clientes
        public void EliminarClientes(int id)
        {
            using (CustomContext oContext = new CustomContext())
            {
                Clientes Clientes = (from i in oContext.ClientesGet
                                    where i.idCliente == id
                                    select i).FirstOrDefault();

                oContext.ClientesGet.Remove(Clientes);
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
