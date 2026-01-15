using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace simiulationraul.ViewModels.Account
{
    public class RegisterVM
    {
        [MaxLength(30, ErrorMessage = "Max 30 symbol")]
        public string FullName { get; set; }

        [MaxLength(15, ErrorMessage = "Max 15 symbol")]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords must be same!")]
        public string ConfirmPassword { get; set; }
    }
}