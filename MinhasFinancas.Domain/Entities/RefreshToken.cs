using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("RefreshToken_Id")]
        public override int Id { get; protected set; }
        public string? Token { get; set; }
        public string? JwtId { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevorked { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        [Required()]
        [ForeignKey("ApplicationUser")]
        [Column("User_Id")]
        public string? UserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

    }
}
