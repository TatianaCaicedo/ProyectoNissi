using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public bool estado { get; set; }
        public int id_rol { get; set; }
        public string identificacion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string apellido { get; set; }
        public string avatar { get; set; }
        
        [NotMapped]
        public string rol { get; set; }
    }
}
