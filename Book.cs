using System.ComponentModel.DataAnnotations;

namespace DESAISIV
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "this filed can't be empty")]
        public string Title { get; set; }
        [Required(ErrorMessage = "this filed can't be empty")]
        public string Author { get; set; }
        [Required (ErrorMessage ="only accepte numbers years dates only")]
        public int PublicationYear { get; set; }



    }
}
