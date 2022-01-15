﻿using System.ComponentModel.DataAnnotations;

namespace MinhasFinancas.Application.ViewModels.User
{
    public class RegisterViewModel
    {
        [Required]
        public string UserFullname { get; set; } = string.Empty;

        [Required]
        public int UserAge { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; } = string.Empty;

        [Required]
        public string UserSenha { get; set; } = string.Empty;
    }
}
