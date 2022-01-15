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
        [ForeignKey("ApplicationUser")]
        [Column("User_Id")]
        public string? UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public ICollection<Movement>? Movements { get; set; }

        public Category()
        {
        }

        public Category (Category category)
        {
            Name = category.Name;
            Type = category.Type;
            CreationDate = DateTime.Now;
            LastEdtion = DateTime.Now;
            ApplicationUser = new ApplicationUser();
            Movements = new List<Movement>();
        }

        public Category(int id, string name, bool type)
        {
            Id = id;
            Name = name;
            Type = type;
            CreationDate = DateTime.Now;
            LastEdtion = DateTime.Now;
            ApplicationUser = new ApplicationUser();
            UserId = id.ToString();
            Movements = new List<Movement>();
        }
    }
}
