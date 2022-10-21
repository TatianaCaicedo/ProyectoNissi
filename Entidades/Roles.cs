using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Table("Roles")]
    public partial class Roles
    {
        [Key]
        public int id_rol { get; set; }
        public string descripcion { get; set; }
    }
}
