using Entidades;
using General;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public partial class CustomContext : DbContext
    {
        public DbModelBuilder DBModelBuilder { get; set; }
        public CustomContext()
            : base(new SqlConnection(PropiedadesGenerales.Conexion), true)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.DBModelBuilder = modelBuilder;

            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Roles>().ToTable("Roles");
            modelBuilder.Entity<Proveedores>().ToTable("Proveedores");
            modelBuilder.Entity<Clientes>().ToTable("Clientes");
            modelBuilder.Entity<DetallePedido>().ToTable("DetallePedido");
            modelBuilder.Entity<Inventario>().ToTable("Inventario");
            modelBuilder.Entity<Pedidos>().ToTable("Pedidos");
            modelBuilder.Entity<Productos>().ToTable("Productos");
        }

        public DbSet<Usuario> UsuariosGet { get; set; }
        public DbSet<Roles> RolesGet { get; set; }
        public DbSet<Proveedores> ProveedoresGet { get; set; }
        public DbSet<Clientes> ClientesGet { get; set; }
        public DbSet<DetallePedido> DetallePedidoGet { get; set; }
        public DbSet<Inventario> InventarioGet { get; set; }
        public DbSet<Pedidos> PedidosGet { get; set; }
        public DbSet<Productos> ProductosGet { get; set; }
    }
}
