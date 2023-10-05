using System.ComponentModel.DataAnnotations;

namespace AUG30.Portfolio.Web.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
    public class SignupModel : UserModel
    {
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
