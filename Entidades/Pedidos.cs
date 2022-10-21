using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Table("Pedidos")]
    public partial class Pedidos
    {
        [Key]
        public int numPedido { get; set; }
        public DateTime fechaSolicitud { get; set; }
        public int cl_idCliente { get; set; }
    }
}
