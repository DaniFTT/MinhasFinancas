using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Domain.Entities
{
    [Table("Wallet")]
    public class Wallet : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Wallet_Id")]
        public override int Id { get; protected set; }

        [Required()]
        [Column("Total_Value")]
        public Decimal TotalValue { get; set; }

        [Required()]
        [Column("User_Id")]
        public string? UserId { get; set; }
        public User? User { get; set; }

        public ICollection<PaymentMethod>? PaymentMethods { get; set; }
    }
}
