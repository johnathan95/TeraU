using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeraU.Models
{
    [Table("actor")]
    public class Actor
    {
        [Key]
        [Display(Name = "Actor")]
        public int id_actor { get; set; }
        [Required(ErrorMessage = "The name of the actor must be entered")]
        [Display(Name = "Actor")]
        public string name_actor { get; set; }
        [Required(ErrorMessage = "The nationnality of the actor must be entered")]
        [Display(Name = "Actor nationnality")]
        public string actor_nationnality { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
