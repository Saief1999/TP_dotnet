using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace tp2_ex2.Models
{
    class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity),Column("id")]
        public int Id { get; set; }

        
        [Column("status")]
        public int Status { get; set; }

        public ICollection<Product> Products { get; set; }

        public override string ToString()
        {
            string result= $"Id= {Id}, Status={Status},\nProducts=[";
            Products.ToList().ForEach(product => result += $"\n({product})");
            result += "]";
            return result;  
        }
    }
}
