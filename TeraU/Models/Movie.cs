using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace TeraU.Models
{
    [Table("film")]
    public class Movie
    {
        [Key]
        [Column("id_film")]
        public int id_movie { get; set; }
        [Column("title_film")]
        [Required(ErrorMessage = "The name of the movie must be entered")]
        [Display(Name = "Movie")]
        public string movie { get; set; }
        [Required(ErrorMessage = "The name of the genre must be selected")]
        [Display(Name = "Genre")]
        public int id_genre { get; set; }
        [Required(ErrorMessage = "The name of the actor must be selected")]
        [Display(Name = "Actor")]
        public int id_actor { get; set; }
        [Required(ErrorMessage = "The name of the director must be entered")]
        [Display(Name = "Director")]
        [Column("director")]
        public string director { get; set; }
        [Required(ErrorMessage = "The release year of the movie must be entered (4 numbers)")]
        [Display(Name = "Year")]
        [Column("release_year")]
        public int year { get; set; }
        [Required(ErrorMessage = "A description of the movie must be entered")]
        [Display(Name = "Description")]
        [Column("description")]
        public string description { get; set; }
        [Required(ErrorMessage = "The poster of the movie must be entered")]
        [Display(Name = "Poster")]
        [Column("poster")]
        public Byte[] poster { get; set; }
        [NotMapped]
        public List<HttpPostedFileBase> Files { get; set; }
        

        public virtual Actor Actor { get; set; }
        public virtual Genre Genre { get; set; }

        public Movie()
        {
            Files = new List<HttpPostedFileBase>();
        }
    }
}