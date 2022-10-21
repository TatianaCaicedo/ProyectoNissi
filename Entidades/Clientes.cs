using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Table("Clientes")]
    public partial class Clientes
    {
        [Key]
        public int idCliente { get; set; }
        public string cl_tipoDoc { get; set; }
        public string cl_numDoc { get; set; }
        public string cl_nombre { get; set; }
        public string cl_direccion { get; set; }
        public string cl_ciudad { get; set; }
        public string cl_tel { get; set; }
    }  
}
