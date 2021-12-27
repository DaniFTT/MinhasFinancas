using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhasFinancas.Domain.Entities
{
    [Table("Category")]
    public class Category : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Category_Id")]
        public override int Id { get; protected set; }

        [Required()]
        [MaxLength(100)]
        [Column("Name")]
        public string? Name { get; set; }

        [Required()]
        [Column("Type")]
        public bool Type { get; set; }

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

        public ICollection<Movement>? Movements { get; set; }
    }
}
