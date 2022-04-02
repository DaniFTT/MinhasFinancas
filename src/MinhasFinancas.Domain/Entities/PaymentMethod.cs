using MinhasFinancas.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhasFinancas.Domain.Entities
{
    [Table("Payment_Method")]
    public class PaymentMethod : BaseEntity
    {
        [Key]
        [Column("Payment_Method_Id")]
        public override Guid Id { get; protected set; }

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
        [ForeignKey("User")]
        [Column("User_Id")]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public ICollection<Movement>? Movements { get; set; }

        public PaymentMethod(string? name, decimal value, PaymentType paymentType, string? userId)
        {
            Name = name;
            Value = value;
            PaymentType = paymentType;
            UserId = userId;
        }
    }
}
