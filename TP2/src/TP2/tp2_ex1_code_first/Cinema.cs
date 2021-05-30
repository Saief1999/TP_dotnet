using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace tp2_code_first
{
    [Table("cinemas")]
    class Cinema
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        public String Name { get; set; }

        [Column("description")]
        public String Description { get; set; }


        [Column("opening_time")]
        public string OpeningTime { get; set; }

        [Column("closing_time")]
        public string ClosingTime { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
