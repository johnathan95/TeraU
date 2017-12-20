using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeraU.Models
{
    [Table("genre")]
    public class Genre
    {
        [Key]
        [Display(Name = "Genre")]
        public int id_genre { get; set; }
        [Required(ErrorMessage = "The name of the genre must be entered")]
        [Display(Name = "Genre")]
        public string name_genre { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}