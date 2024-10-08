using DESAISIV.customValidtion;
using System.ComponentModel.DataAnnotations;

namespace DESAISIV
{
    // The Book Model
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "this filed can't be empty")]
        public string Title { get; set; }
        [Required(ErrorMessage = "this filed can't be empty")]
        public string Author { get; set; }
        

        [ValidPublicationYear(1000, ErrorMessage = "Publication year must be between 1000 and the current year.")]
        public int PublicationYear { get; set; }



    }
}
