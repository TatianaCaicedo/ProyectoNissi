using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Table("Proveedores")]
    public partial class Proveedores
    {
        [Key]
        public int idProv { get; set; }
        public string prov_tipoDoc { get; set; }
        public int prov_numDoc { get; set; }
        public string prov_nombre { get; set; }
        public string prov_direccion { get; set; }
        public string prov_ciudad { get; set; }
        public int prov_tel { get; set; }
    }
}
