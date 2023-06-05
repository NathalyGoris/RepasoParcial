using System.ComponentModel.DataAnnotations;

public class Libros
    {
        [Key]
        public int LibroId { get; set; }

        [Required (ErrorMessage = "El titulo del libro es obligatorio")]
        public string? Titulo{ get; set; }

        [Required (ErrorMessage = "El precio del libro es oligatorio")]
        public string? Precio{ get; set; }
    }