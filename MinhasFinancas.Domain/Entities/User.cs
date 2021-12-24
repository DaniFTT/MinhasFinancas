using Microsoft.AspNetCore.Identity;
using MinhasFinancas.Domain.Enums;
using MinhasFinancas.Infra.CrossCutting.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Domain.Entities
{
    public class User : IdentityUser
    {
        [Required()]
        [Column("User_Fullname")]
        [MaxLength(50)]
        public string? UserFullname { get; set; }

        [Required()]
        [Column("User_Age")]
        public int UserAge { get; set; }

        [Column("User_Type")]
        public UserType UserType { get; set; }

        public ICollection<Category>? Categories { get; set; }

        public ICollection<Movement>? Movements { get; set; }

        [Required()]
        public int? WalletId { get; set; }
        public Wallet? Wallet { get; set; }


    }
}
