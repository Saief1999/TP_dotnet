using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tp2_ex2.Models
{
    class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }


        [Column("description")]
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }



        public virtual ICollection<Product> Products { get; set; }

        public override string ToString()
        {
            Products.ToList();
            //string result = $"Id={Id}, Name={Name}, Description={Description}";
            string result = $"Id={Id}, Name={Name}, Description={Description},\n Products=[";
            Products.ToList().ForEach(product => result += $"\n({product})");
            result += "]";
            return result;
        }
    }
}
