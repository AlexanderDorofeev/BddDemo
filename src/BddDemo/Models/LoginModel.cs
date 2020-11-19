using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BddDemo.Models
{
    public class LoginModel
    {
        [DisplayName("Имя пользователя")]
        [Required(ErrorMessage="Укажите имя пользователя")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Укажите пароль")]
        [DisplayName("Пароль")]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}