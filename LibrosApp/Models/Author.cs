using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace LibrosApp.Models
{
    public class Author
    {

        public int AuthorId { get; set; }
        [Required(ErrorMessage = "Es obligatorio el nombre del autor.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Es obligatorio el país del autor.")]
        public string Country { get; set; }
        public List<Book>? Books { get; set; }
    }
}
