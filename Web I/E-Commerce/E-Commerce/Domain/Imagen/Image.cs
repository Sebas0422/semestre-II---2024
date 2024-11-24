using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Domain.Imagen
{
    public class Image
    {
        [Key]
        public int ImagenId { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(200)]
        [Required]
        public string FileName { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(1000)]
        [Required]
        public string Path { get; set; }

        public bool Temporal { get; set; }

        public DateTime FechaSubida { get; set; }


    }
}
