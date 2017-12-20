using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeraU.Models
{
    [Table("actor")]
    public class Actor
    {
        [Key]
        public int id_actor { get; set; }
        public string name_actor { get; set; }
        public string actor_nationnality { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
