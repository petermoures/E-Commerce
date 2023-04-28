using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class Cart
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Quantity { get; set; }
       
        public string ?UserId { get; set; }
        public virtual User ?User { get; set; }
        public virtual IList<product> Productss { get; set; }

        //public Cart()
        //{
        //    Productss=new List<product>();
        //}

     
    }
}
