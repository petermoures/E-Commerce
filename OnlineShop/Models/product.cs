using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required,MaxLength(150)]
        public string ?ProName { get; set; }
        [Required]
        public int ProPrice { get; set; }
        public string ?Image { get; set; }
        public string ?Color { get; set; }
        [Required]
        public bool Available { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category ?category { get; set; }
        public virtual ICollection<Cart> Cartss { get; set; }

        public virtual ICollection<Order> ?Orders { get; set; }
        

    }
}
