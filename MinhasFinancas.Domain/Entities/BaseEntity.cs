using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhasFinancas.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; protected set; }

        [Required()]
        [Column("Creation_Date")]
        public DateTime CreationDate { get; set; }

        [Required()]
        [Column("Last_Edition")]
        public DateTime LastEdtion { get; set; }

        [Column("Is_Deleted")]
        public bool isDeleted { get; set; }
    }
}
