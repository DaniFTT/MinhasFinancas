using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("User")]
        [Column("User_Id")]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public ICollection<PaymentMethod>? PaymentMethods { get; set; }
    }
}
