using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Table("Inventario")]
    public partial class Inventario
    {
        [Key]
        public int id { get; set; }
        public int produc_idItem { get; set; }
        public int cantidadInicial { get; set; }
        public int cantidadActual { get; set; }
        public int cantidadVendida { get; set; }
        public float valorTotalVendido { get; set; }
        public float ganancia { get; set; }
    }
}
