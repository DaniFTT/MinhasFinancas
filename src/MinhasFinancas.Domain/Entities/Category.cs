using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhasFinancas.Domain.Entities
{
    [Table("Category")]
    public class Category : BaseEntity
    {
        [Key]
        [Column("Category_Id")]
        public override Guid Id { get; protected set; }

        [Required()]
        [MaxLength(100)]
        [Column("Name")]
        public string? Name { get; set; }

        [Required()]
        [Column("Type")]
        public bool Type { get; set; }

        [Required()]
        [ForeignKey("ApplicationUser")]
        [Column("User_Id")]
        public string? UserId { get; set; }
        public virtual ApplicationUser? ApplicationUser { get; set; }

        public ICollection<Movement>? Movements { get; set; }

        public Category() : base() { }

        public Category(string name, bool type, string? userId)
        { 
            Name = name;
            Type = type;
            UserId = userId;
        }
    }
}
