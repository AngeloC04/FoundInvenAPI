using System.ComponentModel.DataAnnotations;

namespace ConInventario.DTO
{
    public class InventarioDTO
    {
        [Required]
        public string SKU { get; set; }
        [Required]
        public string Bodega { get; set; }
        [Required]
        public double DispoNeto { get; set; }
        [Required]
        public double InvCompro { get; set; }
        [Required]
        public double UniPorUbica { get; set; }
    }
}
