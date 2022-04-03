using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhasFinancas.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required()]
        [Column("User_Fullname")]
        [MaxLength(50)]
        public string UserFullname { get; set; } = string.Empty;

        [Required()]
        [Column("User_Age")]
        public int UserAge { get; set; }

        public ICollection<Category>? Categories { get; set; }

        public ICollection<Movement>? Movements { get; set; }

        public ICollection<PaymentMethod>? PaymentMethods { get; set; }
    }
}
