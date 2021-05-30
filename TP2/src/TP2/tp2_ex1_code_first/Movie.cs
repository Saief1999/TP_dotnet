using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tp2_code_first
{
    [Table("movies")]

    class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("global_rating")]
        public int globalRating { get; set; }

        [Column("price")]
        public int Price { get;set; }

        public virtual ICollection<Cinema> Cinemas { get; set; }
            
    }
}
