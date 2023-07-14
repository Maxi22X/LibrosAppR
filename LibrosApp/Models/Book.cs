using System.ComponentModel.DataAnnotations;

namespace LibrosApp.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "El título es requerido")]
        public string Title { get; set; }

        [Required(ErrorMessage = "El año de publicación es requerido")]
        public string PublicationYear { get; set; }

        [Required(ErrorMessage = "El autor es requerido")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }


        // Otras propiedades del libro
    }
}
