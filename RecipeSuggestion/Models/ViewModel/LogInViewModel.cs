using System.ComponentModel.DataAnnotations;

namespace RecipeSuggestion.Models.ViewModel
{
	public class LogInViewModel
	{
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email address is not valid.")]
        [MaxLength(50, ErrorMessage = "Maximum character allowed is 50.")]
        public string EmailAddress { get; set; }
        
        [Required(ErrorMessage = "Please enter a password.")]
        [MaxLength(50, ErrorMessage = "Maximum character allowed is 50.")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        public bool RememberMe { get; set; }
    }
}
