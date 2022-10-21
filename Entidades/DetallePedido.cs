using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Table("DetallePedido")]
    public partial class DetallePedido
    {
        [Key]
        public int id_detallePedido { get; set; }
        public int ped_numPedido { get; set; }
        public int p_idItem { get; set; }
        public int cantidad { get; set; }
        public float subtotal { get; set; }
        public float descuento { get; set; }
        public float total { get; set; }
    }
}
