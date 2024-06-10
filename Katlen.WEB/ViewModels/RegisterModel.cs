using System.ComponentModel.DataAnnotations;

namespace Katlen.WEB.ViewModels
{
    public class RegisterModel
    {
        public string Phone { get; set; }
       
        [Required(ErrorMessage = "Не указан Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Необходим пароль подтверждения")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Не указано имя пользователя")]
        public string Name { get; set; }

    }
}
