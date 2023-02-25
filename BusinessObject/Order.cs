using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;
using System.ComponentModel;

namespace BusinessObject
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required, DisplayName("Member")]
        public int MemberId { get; set; }
        public Member Member { get; set; }

        [Required]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        private DateTime _requiredDate;
        [Required]
        [Display(Name = "Required Date")]
        public DateTime RequiredDate
        {
            get => _requiredDate;
            set
            {
                if (value < OrderDate)
                {
                    throw new ValidationException("Required date must be greater than or equal to order date.");
                }
                _requiredDate = value;
            }
        }

        private DateTime _shippedDate;
        [Required]
        [Display(Name = "Shipped Date")]
        public DateTime ShippedDate
        {
            get => _shippedDate;
            set
            {
                if (value < OrderDate)
                {
                    throw new ValidationException("Shipped date must be greater than or equal to order date.");
                }
                _shippedDate = value;
            }
        }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
