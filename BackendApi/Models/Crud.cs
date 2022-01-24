using System.ComponentModel.DataAnnotations;

namespace BackendApi.Models
{
    public class Crud
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public string Telefono { get; set; }

    }
}
