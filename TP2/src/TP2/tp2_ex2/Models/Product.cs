using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace tp2_ex2.Models
{
    class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        /* We need to add image also */
        
        [Column("title")]
        public string Title { get; set; }

        [Column("editor")]
        public string Editor { get; set; }

        [Column("price")]
        public double Price { get; set; }


        public virtual Order Order { get; set; }

        public virtual Category Category { get; set; }

        public override string ToString()
        {
            return $"Id={Id}, Title={Title}, Editor= {Editor}, Price= {Price}";
        }
    }
}
