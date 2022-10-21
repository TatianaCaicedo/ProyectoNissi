using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Table("Productos")]
    public partial class Productos
    {
        [Key]
        public int idItem { get; set; }
        public string p_nombre { get; set; }
        public string p_descripcion { get; set; }
        public string talla { get; set; }
        public int unidades { get; set; }
        public float valorUnidadNeto { get; set; }
        public float valorUnidadPublico { get; set; }
        public int prov_idProveedor { get; set; }
    }
}
