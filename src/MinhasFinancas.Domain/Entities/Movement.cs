using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhasFinancas.Domain.Entities
{
    [Table("Movement")]
    public class Movement : BaseEntity
    {
        [Key]
        [Column("Movement_Id")]
        public override Guid Id { get; protected set; }

        [Required()]
        [MaxLength(200)]
        [Column("Description")]
        public string? Description { get; set; }

        [Required()]
        [Column("Type")]
        public bool Type { get; set; }

        [Required()]
        [Column("Value")]
        public Decimal Value { get; set; }

        [ForeignKey("PaymentMethod")]
        [Column("Payment_Method_Id")]
        public Guid? PaymentMethodId { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }

        [ForeignKey("Category")]
        [Column("Category_Id")]
        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required()]
        [Column("Date_Of_Movement")]
        public DateTime DateOfMovement { get; set; }

        [Required()]
        [ForeignKey("User")]
        [Column("User_Id")]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public Movement(string? description, bool type, decimal value, Guid? paymentMethodId, Guid? categoryId, DateTime dateOfMovement, string? userId)
        {
            Description = description;
            Type = type;
            Value = value;
            PaymentMethodId = paymentMethodId;
            CategoryId = categoryId;
            DateOfMovement = dateOfMovement;
            UserId = userId;
        }
    }
}
