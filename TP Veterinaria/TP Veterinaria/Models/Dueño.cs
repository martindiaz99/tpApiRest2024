using System.ComponentModel.DataAnnotations;

namespace TP_Veterinaria.Models
{
    public class Dueño
    {
        [Key]
        public string Dni { get; set; }
        public string Nombre { get; set; }
    }
}
