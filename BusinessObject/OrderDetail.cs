using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class OrderDetail
    {
        //[Key, Column(Order = 1)]
        [Required, DisplayName("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        //[Key, Column(Order = 2)]
        [Required, DisplayName("Product")] public int ProductId { get; set;}
        public Product Product { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Unit Price must be at least 1")]
        public int UnitPrice{ get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity{ get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Discount must be at least 1")]
        public int Discount { get; set; }
    }
}
