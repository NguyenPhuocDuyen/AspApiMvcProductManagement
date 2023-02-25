using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BusinessObject
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        
        [Required, DisplayName("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Weight must be at least 1")]
        public int Weight { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Unit price must be at least 1")]
        public int UnitPrice { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Unit In Stock must be at least 1")]
        public int UnitsInStock { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
