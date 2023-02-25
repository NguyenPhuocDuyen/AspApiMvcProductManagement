using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class MemberRegister : Member
    {
        [NotMapped]
        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public bool IsValid(string confirmPassword)
        {
            if (Password != confirmPassword)
            {
                return false;
            }

            return true;
        }
    }
}
