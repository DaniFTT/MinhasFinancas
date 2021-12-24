using MinhasFinancas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Domain.Entities
{
    [Table("Payment_Method")]
    public class PaymentMethod : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Payment_Method_Id")]
        public override int Id { get; protected set; }

        [Required()]
        [MaxLength(100)]
        [Column("Name")]
        public string? Name { get; set; }

        [Required()]
        [Column("Value")]
        public Decimal Value { get; set; }

        [Required()]
        [Column("Payment_Type")]
        public PaymentType PaymentType { get; set; }

        [Required()]
        [Column("Creation_Date")]
        public DateTime CreationDate { get; set; }

        [Required()]
        [Column("Last_Edition")]
        public DateTime LastEdtion { get; set; }

        [Required()]
        public int WalletId { get; set; }
        public Wallet? Wallet { get; set; }

        public ICollection<Movement>? Movements { get; set; }
    }
}
