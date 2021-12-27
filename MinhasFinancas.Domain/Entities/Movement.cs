using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhasFinancas.Domain.Entities
{
    [Table("Movement")]
    public class Movement : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Movement_Id")]
        public override int Id { get; protected set; }

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
        public int? PaymentMethodId { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }

        [ForeignKey("Category")]
        [Column("Category_Id")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required()]
        [Column("Date_Of_Movement")]
        public DateTime DateOfMovement { get; set; }

        [Required()]
        [Column("Creation_Date")]
        public DateTime CreationDate { get; set; }

        [Required()]
        [Column("Last_Edition")]
        public DateTime LastEdtion { get; set; }

        [Required()]
        [ForeignKey("User")]
        [Column("User_Id")]
        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}
