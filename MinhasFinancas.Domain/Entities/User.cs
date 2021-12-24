using Microsoft.AspNetCore.Identity;
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
        [Column("User_Fullname")]
        [Required(ErrorMessage = "O Nome é obrigatório")]
        [MaxLength(50)]
        public string? UserFullname { get; set; }

        [Column("User_Age")]
        [Required(ErrorMessage ="A Idade é obrigatória")]
        public int UserAge { get; set; }
    }
}
