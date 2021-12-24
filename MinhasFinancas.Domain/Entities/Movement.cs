using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [Column("Payment_Method_Id")]
        public int? PaymentMethodId { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }

        [Required()]
        public ICollection<Category>? Categories { get; set; }

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
        [Column("User_Id")]
        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}
